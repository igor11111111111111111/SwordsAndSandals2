using CustomJson;
using SwordsAndSandals.OutScene;
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
        private SwordsAndSandals.PlayerData _playerData;
        private SwordsAndSandals.PlayerData _aiData;

        private void Awake()
        {
            _playerData = new Json().Load<SwordsAndSandals.PlayerData>();

            _aiData = new AllEnemyData().Get(_playerData.DataLevel.Level);

            var playerInjector = _playerSpawner.Init
                (
                    _playerData,
                    new Vector3(-5.52f, -14.51f, 0),
                    15
                );
            var aiInjector = _playerSpawner.Init
                (
                    _aiData,
                    new Vector3(5.52f, -14.51f, 0),
                    15
                );

            _introductionPanel.Init(_playerData, _aiData);
            _arenaPanel.Init(_fatalityPanel);
            _endBattlePanel.Init(_fatalityPanel);
            _fatalityLogic.Init(playerInjector, aiInjector, _fatalityPrefab, _fatalityPanel, _ourCamera);

            _introductionPanel.OnEnterArena += () => EnterArena(playerInjector, aiInjector);
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
