using CustomJson;
using SwordsAndSandals.OutScene;
using SwordsAndSandals.Tournament;
using System.Linq;
using UnityEngine;

namespace SwordsAndSandals.Arena
{
    public class ArenaInit : MonoBehaviour
    {
        [SerializeField] private PlayersFatality _fatalityPrefab;
        [SerializeField] private PlayerSpawner _playerSpawner;
        [SerializeField] private IntroductionPanel _introductionPanel;
        [SerializeField] private ArenaPanel _arenaPanel;
        [SerializeField] private EndBattlePanel _endBattlePanel;
        [SerializeField] private PlayerInputUI _playerInputUI;
        [SerializeField] private DamageInfo _damageInfo;
        [SerializeField] private Camera _playerCamera;
        [SerializeField] private Camera _aiCamera;
        [SerializeField] private Camera _ourCamera;
        [SerializeField] private Camera _uiCamera;
        [SerializeField] private FatalityLogic _fatalityLogic;
        [SerializeField] private FatalityPanel _fatalityPanel;
        [SerializeField] private BossEnterPanel _bossEnterPanel;
        private SwordsAndSandals.PlayerData _playerData;
        private SwordsAndSandals.PlayerData _aiData;

        private void Awake()
        {
            _playerData = new Json().Load<SwordsAndSandals.PlayerData>();
            var playerInjector = _playerSpawner.Init
            (
                _playerData,
                new Vector3(-5.52f, -14.51f, 0),
                15
            );

            PlayerInjector aiInjector = null;

            var tournamentDataDontDestroy = FindObjectOfType<TournamentDataDontDestroy>();
            if (tournamentDataDontDestroy != null)
            {
                var participant = tournamentDataDontDestroy.TournamentData.Participants.Where(p => p.IsAlive).FirstOrDefault();
                _aiData = participant.PlayerData;

                if (participant.IsBoss)
                {
                    aiInjector = _playerSpawner.Init
                        (
                            _aiData,
                            Vector3.zero,
                            1
                        );

                    _bossEnterPanel.Init(aiInjector, playerInjector);
                    _bossEnterPanel.Show(true);

                    _bossEnterPanel.OnEnterArena += () => EnterArena(playerInjector, aiInjector);
                }
                else
                {
                    // merge 1 and 2
                    aiInjector = _playerSpawner.Init// 1
                        (
                            _aiData,
                            new Vector3(5.52f, -14.51f, 0),
                            15
                        );

                    _introductionPanel.Init(_playerData, _aiData);
                    _bossEnterPanel.Show(false);

                    _introductionPanel.OnEnterArena += () => EnterArena(playerInjector, aiInjector);// 1
                }
            }
            else
            {
                _aiData = new AllEnemyData().Get(_playerData.DataLevel.Level);
                aiInjector = _playerSpawner.Init// 2
                    (
                        _aiData,
                        new Vector3(5.52f, -14.51f, 0),
                        15
                    );

                _introductionPanel.Init(_playerData, _aiData);
                _bossEnterPanel.Show(false);

                _introductionPanel.OnEnterArena += () => EnterArena(playerInjector, aiInjector);// 2
            }

            _arenaPanel.Init(_fatalityPanel);
            _endBattlePanel.Init(_fatalityPanel, tournamentDataDontDestroy);
            _fatalityLogic.Init(playerInjector, aiInjector, _fatalityPrefab, _fatalityPanel, _ourCamera);
        }

        private void EnterArena(PlayerInjector player, PlayerInjector ai)
        {
            var turnLogic = new TurnLogic();
            var cameraMover = new CameraMover(_playerCamera, _aiCamera, _ourCamera, _uiCamera, player, ai, turnLogic);

            new ArenaSetupData(_arenaPanel, player, _playerData, ai, _aiData, turnLogic, cameraMover, _playerInputUI, _damageInfo, _endBattlePanel, _fatalityLogic);
            _arenaPanel.Show(true);
        }
    } 
}
