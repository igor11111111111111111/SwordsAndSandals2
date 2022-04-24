using CustomJson;
using SwordsAndSandals.OutScene;
using UnityEngine;

namespace SwordsAndSandals.Arena
{
    public class ArenaInit : MonoBehaviour
    {
        [SerializeField] private PlayerSpawner _playerSpawner;
        [SerializeField] private IntroductionPanel _introductionPanel;
        [SerializeField] private ArenaPanel _arenaPanel;
        [SerializeField] private ArenaSetupData _setup;
        private SwordsAndSandals.PlayerData _playerData;
        private SwordsAndSandals.PlayerData _aiData;

        private void Awake()
        {
            _playerData = new Json().Load<SwordsAndSandals.PlayerData>(Enums.SaveFilename.Player);
            _aiData = AICreator.GetRandom();

            var playerInjector = _playerSpawner.Init
                (
                    _playerData,
                    new Vector3(-5.52f, -14.51f, 0),
                    15
                );
            var aiInjector = _playerSpawner.Init
                (
                    _aiData,
                    new Vector3(4.25f, -14.51f, 0),
                    15
                );

            _introductionPanel.Init(_playerData, _aiData);
            _arenaPanel.Init();

            _introductionPanel.OnEnterArena += () => EnterArena(playerInjector, aiInjector);
        }

        private void EnterArena(PlayerInjector player, PlayerInjector ai)
        {
            var turnLogic = new TurnLogic();
            _setup.Init(_arenaPanel, player, _playerData, ai, _aiData, turnLogic);
            turnLogic.Init(player, ai);
            _arenaPanel.Show(true);
        }
    } 
}
