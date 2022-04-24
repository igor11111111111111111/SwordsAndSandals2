using System;
using UnityEngine;

namespace SwordsAndSandals.Arena
{
    public class ArenaSetupData : MonoBehaviour
    {
        [SerializeField] private CameraMover _cameraMover;
        [SerializeField] private PlayerInput _playerInput;
        [SerializeField] private DamageInfo _damageInfo;

        public void Init(ArenaPanel arenaPanel, PlayerInjector playerInjector, SwordsAndSandals.PlayerData playerData, PlayerInjector aiInjector, SwordsAndSandals.PlayerData aiData, TurnLogic turnLogic)
        {
            var arenaPlayerData = Setup(playerData, playerInjector, Enums.Direction.Left);
            var arenaAiData = Setup(aiData, aiInjector, Enums.Direction.Right);

            arenaPanel.InitPlayers(arenaPlayerData, arenaAiData);
            var arenaHandler = new ArenaHandler(playerInjector, aiInjector);

            playerInjector.InitPlayerArenaInput(_playerInput, turnLogic, arenaHandler);
            _cameraMover.Init(playerInjector, new Vector3(4, 2.5f, 0));

            aiInjector.InitAIArenaInput(new AiInput(), turnLogic, arenaHandler);
            new PlayerRotator().Rotate(aiInjector);

            var playerAttackHandler = new AttackHandler(arenaPlayerData, playerInjector, aiInjector, arenaHandler, _damageInfo);
            playerInjector.InitAttackHandler(playerAttackHandler);

            var aiAttackHandler = new AttackHandler(arenaAiData, aiInjector, playerInjector, arenaHandler, _damageInfo);
            aiInjector.InitAttackHandler(aiAttackHandler);
        }

        private PlayerData Setup(SwordsAndSandals.PlayerData playerData, PlayerInjector injector, Enums.Direction direction)
        {
            int sign = direction == Enums.Direction.Left ? -1 : 1;

            injector.GetComponent<Rigidbody2D>().simulated = true;

            injector.transform.position = new Vector3(4 * sign, -2.5f, 0);

            var sceneScale = new Vector3(3.2f, 3.2f, 3.2f);
            injector.transform.localScale = sceneScale * playerData.DataSkills.Get<Strength>().ScaleCoeff;

            var armorData = new ArmorData(playerData.DataArmors.GetDefence());
            var healthData = new HealthData(playerData.DataSkills.Get<Vitality>());
            var staminaData = new StaminaData(playerData.DataSkills.Get<Stamina>());
            return new PlayerData(armorData, healthData, staminaData, playerData.Name);
        }
    }
}
