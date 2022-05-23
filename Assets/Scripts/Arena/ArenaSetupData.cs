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

            Other();
            Player();
            AI();
            LateInit();
        }

        private void Other()
        {
            _arenaPlayerData = Setup(_playerData, _playerInjector, Enums.Direction.Left);
            _arenaAiData = Setup(_aiData, _aiInjector, Enums.Direction.Right);
            _arenaPanel.InitPlayers(_arenaPlayerData, _arenaAiData);
            _arenaHandler = new ArenaHandler(_playerInjector, _aiInjector);
            _cameraMover.Init(_arenaHandler);
        }

        private void Player()
        {
            _playerInjector.InitPlayerArenaInput(_playerInputUI, _turnLogic, _arenaHandler, _aiData);

            _playerAttackHandler = new AttackHandler(_arenaPlayerData, _playerInjector, _aiInjector, _arenaHandler);
            _playerInjector.InitAttackHandler(_playerAttackHandler);
            _damageInfo.Init(_playerAttackHandler);
        }

        private void AI()
        {
            _aiInjector.InitAIArenaInput(_turnLogic, _arenaHandler);

            _aiAttackHandler = new AttackHandler(_arenaAiData, _aiInjector, _playerInjector, _arenaHandler);
            _aiInjector.InitAttackHandler(_aiAttackHandler);
            _damageInfo.Init(_aiAttackHandler);

            new PlayerRotator().Rotate(_aiInjector);
        }

        private void LateInit()
        {
            _playerAttackHandler.InitEnemyAttackHandler(_aiAttackHandler);
            _aiAttackHandler.InitEnemyAttackHandler(_playerAttackHandler);

            var endBattleHandler = new EndBattleHandler(_playerAttackHandler);
            _endBattlePanel.Init(_playerData, _aiData, endBattleHandler);
            _turnLogic.Init(_playerInjector, _aiInjector, endBattleHandler);
            _fatalityLogic.Init(endBattleHandler);
            _playerInputUI.Init(endBattleHandler);

            _aiAttackHandler.Test();//!
        }

        private PlayerData Setup(SwordsAndSandals.PlayerData playerData, PlayerInjector injector, Enums.Direction direction)
        {
            int sign = direction == Enums.Direction.Left ? -1 : 1;

            injector.GetComponent<Rigidbody2D>().simulated = true;

            injector.transform.position = new Vector3(4.89f * sign, -2.5f, 3);

            var sceneScale = new Vector3(3.2f, 3.2f, 3.2f);
            injector.transform.localScale = sceneScale * playerData.DataSkills.Get<Strength>().ScaleCoeff;

            var armorData = new ArmorData(playerData.DataArmors.GetDefence());
            var healthData = new HealthData(playerData.DataSkills.Get<Vitality>());
            var staminaData = new StaminaData(playerData.DataSkills.Get<Stamina>());
            return new PlayerData(armorData, healthData, staminaData, playerData.Name);
        }
    }
}
