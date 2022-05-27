using System;
using UnityEngine;

namespace SwordsAndSandals.Arena
{
    public class ArenaSetupData
    {
        private ArenaPanel _arenaPanel;
        private PlayerInjector _playerInjector;
        private SwordsAndSandals.PlayerData _playerData;
        private PlayerData _arenaPlayerData;
        private PlayerInjector _aiInjector;
        private SwordsAndSandals.PlayerData _aiData;
        private PlayerData _arenaAiData;
        private TurnLogic _turnLogic;
        private ArenaHandler _arenaHandler;
        private CameraMover _cameraMover;
        private PlayerInputUI _playerInputUI;
        private DamageInfo _damageInfo;
        private AttackHandler _playerAttackHandler;
        private AttackHandler _aiAttackHandler;
        private EndBattlePanel _endBattlePanel;
        private FatalityLogic _fatalityLogic;
        private EndBattleHandler _endBattleHandler;

        public ArenaSetupData(ArenaPanel arenaPanel, PlayerInjector playerInjector, SwordsAndSandals.PlayerData playerData, PlayerInjector aiInjector, SwordsAndSandals.PlayerData aiData, TurnLogic turnLogic, CameraMover cameraMover, PlayerInputUI playerInputUI, DamageInfo damageInfo, EndBattlePanel endBattlePanel, FatalityLogic fatalityLogic)
        {
            _arenaPanel = arenaPanel; 
            _playerInjector = playerInjector;
            _playerData = playerData;
            _aiInjector = aiInjector;
            _aiData = aiData;
            _turnLogic = turnLogic;
            _cameraMover = cameraMover;
            _playerInputUI = playerInputUI;
            _damageInfo = damageInfo;
            _endBattlePanel = endBattlePanel;
            _fatalityLogic = fatalityLogic;

            Handlers();
            Player();
            AI();
            LateInit();
        }

        private void Handlers()
        {
            _arenaHandler = new ArenaHandler(_playerInjector, _aiInjector);
            _endBattleHandler = new EndBattleHandler();
        }

        private void Player()
        {
            _arenaPlayerData = new PlayerData(_playerData, _playerInjector, Enums.Direction.Left);
            _playerInputUI.Init(_playerInjector, _turnLogic);
            PlayerInput input = new PlayerInput(_playerInjector, _turnLogic, _arenaHandler, _playerInputUI);

            _playerInjector.Init(input);
            _playerAttackHandler = new AttackHandler(_arenaPlayerData, _playerInjector, _aiInjector, _arenaHandler);
            _playerInjector.Init(_playerAttackHandler);

            _playerInputUI.LateInit(_playerInjector.Controller, _aiData);

            _damageInfo.Init(_playerAttackHandler);
            new StaminaLogic(_playerInjector.Controller, _arenaPlayerData);
        }

        private void AI()
        {
            _arenaAiData = new PlayerData(_aiData, _aiInjector, Enums.Direction.Right);
            var aiInput = new AiInput();
            aiInput.Init(_aiInjector, _turnLogic, _arenaHandler);
            _aiInjector.Init(aiInput);

            _aiAttackHandler = new AttackHandler(_arenaAiData, _aiInjector, _playerInjector, _arenaHandler);
            _aiInjector.Init(_aiAttackHandler);
            _damageInfo.Init(_aiAttackHandler);

            new PlayerRotator().Rotate(_aiInjector);
            new StaminaLogic(_aiInjector.Controller, _arenaAiData);
        }

        private void LateInit()
        {
            _playerAttackHandler.Init(_aiAttackHandler);
            _aiAttackHandler.Init(_playerAttackHandler);
            _endBattleHandler.Init(_playerAttackHandler);
            _turnLogic.Init(_playerInjector, _aiInjector, _endBattleHandler);
            _arenaPanel.Init(_arenaPlayerData, _arenaAiData);
            _cameraMover.Init(_arenaHandler);
            _endBattlePanel.Init(_playerData, _aiData, _endBattleHandler);
            _fatalityLogic.Init(_endBattleHandler);
            _playerInputUI.Init(_endBattleHandler);

            _aiAttackHandler.Test();//!
        }
    }
}
