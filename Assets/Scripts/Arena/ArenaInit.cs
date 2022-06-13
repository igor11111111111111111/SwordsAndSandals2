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
        [SerializeField] private CameraInit _cameraInit;
        [SerializeField] private FatalityPanel _fatalityPanel;
        [SerializeField] private BossEnterPanel _bossEnterPanel;
        private FatalityLogic _fatalityLogic;
        private SwordsAndSandals.PlayerData _playerData;
        private SwordsAndSandals.PlayerData _aiData;
        private AudienceMoodData _audienceMoodData;

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

            if (TournamentDataDontDestroy.TournamentData != null)
            {
                var participant = TournamentDataDontDestroy.TournamentData.Participants.Where(p => p.IsAlive).FirstOrDefault();
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
                    aiInjector = _playerSpawner.Init
                    (
                        _aiData,
                        new Vector3(5.52f, -14.51f, 0),
                        15
                    );

                    _introductionPanel.Init(_playerData, _aiData);
                    _bossEnterPanel.Show(false);

                    _introductionPanel.OnEnterArena += () => EnterArena(playerInjector, aiInjector);
                }
            }
            else
            {
                _aiData = new AllEnemyData().Get(_playerData.DataLevel.Level);

                aiInjector = _playerSpawner.Init
                (
                    _aiData,
                    new Vector3(5.52f, -14.51f, 0),
                    15
                );

                _introductionPanel.Init(_playerData, _aiData);
                _bossEnterPanel.Show(false);

                _introductionPanel.OnEnterArena += () => EnterArena(playerInjector, aiInjector);
            }

            _audienceMoodData = new AudienceMoodData();

            _arenaPanel.Init(_fatalityPanel);
            _endBattlePanel.Init(_fatalityPanel, _audienceMoodData);
            _fatalityLogic = new FatalityLogic(playerInjector, aiInjector, _fatalityPrefab, _fatalityPanel, _cameraInit.Our);

            MusicDontDestroy.SetClip("ArenaIntroduction", false);
        }

        private void EnterArena(PlayerInjector player, PlayerInjector ai)
        {
            var turnLogic = new TurnLogic();
            var cameraMover = new CameraMover(_cameraInit, player, ai, turnLogic);

            new ArenaSetupData(_arenaPanel, player, _playerData, ai, _aiData, turnLogic, cameraMover, _playerInputUI, _damageInfo, _endBattlePanel, _fatalityLogic, _audienceMoodData);
            _arenaPanel.Show(true);

            MusicDontDestroy.SetClip("Battle" + Random.Range(1, 3), true);
        }
    } 
}
