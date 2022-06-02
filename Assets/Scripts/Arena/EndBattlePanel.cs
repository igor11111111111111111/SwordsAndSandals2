using CustomJson;
using SwordsAndSandals.OutScene;
using SwordsAndSandals.Tournament;
using System;
using System.Linq;
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

        public void Init(FatalityPanel fatalityPanel, TournamentDataDontDestroy tournamentDataDontDestroy)
        {
            _tournamentDataDontDestroy = tournamentDataDontDestroy;

            Show(false);

            _accept.onClick.AddListener(Accept);
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

        private async void EndBattle(EndBattleHandler.Info info)
        {
            _endBattleInfo = info;

            if (info.WinningTeam == Enums.Team.Player)
            {
                _aboutCharactersInfo.text = "First blood to " + _playerData.Name + "! " + _aiData.Name + " yields.";
                _goldInfo.text = _aiData.Reward.Money /*+ crowd apprecation*/ + " gold won."/* + "..% crowd apprecation"*/;
                _battleXPInfo.text = _aiData.Reward.XP + " xp won for this fight";

                var playerXP = _playerData.DataLevel.CurrentXP;
                var reward = _aiData.Reward.XP;
                var newXP = playerXP + reward;
                float XPToNewLevel = _playerData.DataLevel.GetXPToNewLevel();

                _percentToNextLevelInfo.text = null;

                Show(true);

                await SliderAnimation(playerXP, newXP, XPToNewLevel);
                
                if (newXP < XPToNewLevel)
                {
                    _percentToNextLevelInfo.text = (int)((1 - newXP / XPToNewLevel) * 100) + "% TO NEXT LEVEL";
                }
                else
                {
                    _percentToNextLevelInfo.text = "YOU HAVE LEVELLED UP !";
                }
            }
            else
            {
                _goldInfo.text = null;
                _battleXPInfo.text = "As a result of the battle, you got ... You didn’t get anything, hello, you lost.";
                _percentToNextLevelInfo.text = null;
                _sliderXP.gameObject.SetActive(false);
                _aboutCharactersInfo.text = "Every defeat makes us stronger (c) Jason Statham ... or Confucius, but the person clearly understood 2d games.";
                Show(true);
            }
        }

        private async Task SliderAnimation(int playerXP, float newXP, float XPToNewLevel)
        {
            float xp = playerXP;
            float speed = (XPToNewLevel - playerXP) / 30;
            
            while (true)
            {
                _sliderXP.value = xp / XPToNewLevel;
                _totalXPInfo.text = (int)xp + " xp / " + XPToNewLevel + " xp";
                xp += speed;

                if(xp > newXP)
                {
                    xp = newXP;
                    _sliderXP.value = xp / XPToNewLevel;
                    _totalXPInfo.text = (int)xp + " xp / " + XPToNewLevel + " xp";
                    break;
                }

                await Task.Delay(30);
            }
        }



        private void Show(bool active)
        {
            _body.SetActive(active);
        }

        private void Accept()
        {
            if(_endBattleInfo.WinningTeam == Enums.Team.Player)
            {
                var playerXP = _playerData.DataLevel.CurrentXP;
                var reward = _aiData.Reward.XP;
                var newXP = playerXP + reward;
                float XPToNewLevel = _playerData.DataLevel.GetXPToNewLevel();

                _playerData.DataLevel.CurrentXP = newXP;
                _playerData.Money += _aiData.Reward.Money; // * coeff apprecation

                if (newXP >= XPToNewLevel)
                {
                    _playerData.DataSkills.AddPointsPerLevel();
                    new Json().Save(_playerData);

                    if (_tournamentDataDontDestroy != null)
                    {
                        _tournamentDataDontDestroy.TournamentData.Participants.Find(ai => ai.PlayerData == _aiData).IsAlive = false;
                        new SceneChanger().MoveTo(Enums.Scene.Tournament);
                    }
                    else
                    {
                        new SceneChanger().MoveTo(Enums.Scene.LevelUp);
                    }
                }
                else
                {
                    new Json().Save(_playerData);

                    if (_tournamentDataDontDestroy != null)
                    {
                        _tournamentDataDontDestroy.TournamentData.Participants.Find(ai => ai.PlayerData == _aiData).IsAlive = false;
                        new SceneChanger().MoveTo(Enums.Scene.Tournament);
                    }
                    else
                    {
                        new SceneChanger().MoveTo(Enums.Scene.Street);
                    }
                }
            }
            else
            {
                //new Json().Save(_playerData); cose data dont change
                new SceneChanger().MoveTo(Enums.Scene.Street);
            }
        }
    }
}
