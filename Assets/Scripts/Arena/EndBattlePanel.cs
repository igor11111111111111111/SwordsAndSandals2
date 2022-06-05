using SwordsAndSandals.Tournament;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SwordsAndSandals.Arena
{
    public class EndBattlePanel : MonoBehaviour
    {
        [SerializeField] private GameObject _body;
        [SerializeField] private TextMeshProUGUI _aboutCharactersInfo;
        [SerializeField] private TextMeshProUGUI _goldInfo;
        [SerializeField] private TextMeshProUGUI _battleXPInfo;
        [SerializeField] private TextMeshProUGUI _percentToNextLevelInfo;
        [SerializeField] private TextMeshProUGUI _totalXPInfo;
        [SerializeField] private Slider _sliderXP;
        [SerializeField] private Button _accept;

        private SwordsAndSandals.PlayerData _playerData;
        private SwordsAndSandals.PlayerData _aiData;
        private EndBattleHandler.Info _endBattleInfo;
        private TournamentDataDontDestroy _tournamentDataDontDestroy;
        private XPData _XPData;

        public void Init(FatalityPanel fatalityPanel, TournamentDataDontDestroy tournamentDataDontDestroy)
        {
            _tournamentDataDontDestroy = tournamentDataDontDestroy;

            Show(false);

            _accept.onClick.AddListener(
                () => new AcceptEndBattlePanel
                    (
                        _playerData,
                        _aiData,
                        _endBattleInfo.WinningTeam,
                        _tournamentDataDontDestroy,
                        _XPData
                    )
            );

            fatalityPanel.OnClicked += () => 
            { 
                Show(false);
                _accept.transform.SetParent(transform, true);
            };
        }

        public void Init(SwordsAndSandals.PlayerData playerData, SwordsAndSandals.PlayerData aiData, EndBattleHandler endBattle)
        {
            _playerData = playerData;
            _aiData = aiData;

            endBattle.OnEndBattle += EndBattle;
        }

        private void EndBattle(EndBattleHandler.Info info)
        {
            _endBattleInfo = info;
            CreateXPData();

            if (info.WinningTeam == Enums.Team.Player)
            {
                ShowWinPanel();
            }
            else
            {
                ShowLosePanel();
            }
        }

        private void CreateXPData()
        {
            _XPData = new XPData
            (
                _playerData.DataLevel.Level,
                _playerData.DataLevel.CurrentXP,
                _aiData.Reward.XP,
                _playerData.DataLevel.GetXPToNewLevel()
            );
        }

        private async void ShowWinPanel()
        {
            _aboutCharactersInfo.text = "First blood to " + _playerData.Name + "! " + _aiData.Name + " yields.";
            _goldInfo.text = _aiData.Reward.Money /*+ crowd apprecation*/ + " gold won."/* + "..% crowd apprecation"*/;
            _battleXPInfo.text = _aiData.Reward.XP + " xp won for this fight";

            _percentToNextLevelInfo.text = null;

            Show(true);

            await SliderAnimation();

            if (_XPData.NewXP < _XPData.XPToNewLevel)
            {
                _percentToNextLevelInfo.text = (int)((1 - _XPData.NewXP / _XPData.XPToNewLevel) * 100) + "% TO NEXT LEVEL";
            }
            else
            {
                _percentToNextLevelInfo.text = "YOU HAVE LEVELLED UP !";
            }
        }

        private async Task SliderAnimation()
        {
            float xp = _XPData.PlayerXP;
            float speed = (_XPData.XPToNewLevel - _XPData.PlayerXP) / 30;

            while (true)
            {
                _sliderXP.value = xp / _XPData.XPToNewLevel;
                _totalXPInfo.text = (int)xp + " xp / " + _XPData.XPToNewLevel + " xp";
                xp += speed;

                if (xp > _XPData.NewXP)
                {
                    xp = _XPData.NewXP;
                    _sliderXP.value = xp / _XPData.XPToNewLevel;
                    _totalXPInfo.text = (int)xp + " xp / " + _XPData.XPToNewLevel + " xp";
                    break;
                }

                await Task.Delay(30);
            }
        }

        private void ShowLosePanel()
        {
            _goldInfo.text = null;
            _battleXPInfo.text = "As a result of the battle, you got ... You didn’t get anything, hello, you lost.";
            _percentToNextLevelInfo.text = null;
            _sliderXP.gameObject.SetActive(false);
            _aboutCharactersInfo.text = "Every defeat makes us stronger (c) Jason Statham ... or Confucius, but the person clearly understood 2d games.";
            Show(true);
        }

        private void Show(bool active)
        {
            _body.SetActive(active);
        }

        public class XPData
        {
            public int PlayerXP => _playerXP;
            private int _playerXP;
            private int _reward;
            public int NewXP => _playerXP + _reward;
            public int XPToNewLevel => _XPToNewLevel;
            private int _XPToNewLevel;

            private int _oldLevel;
            private int _newLevel;

            public XPData(int playerLevel, int playerXP, int reward, int xPToNewLevel)
            {
                _oldLevel = playerLevel;
                _playerXP = playerXP;
                _reward = reward;
                _XPToNewLevel = xPToNewLevel;
            }

            public void SetNewLevel(int value)
            {
                _newLevel = value;
            }

            public int GetDeltaLevels()
            {
                return _newLevel - _oldLevel;
            }
        }
    }
}
