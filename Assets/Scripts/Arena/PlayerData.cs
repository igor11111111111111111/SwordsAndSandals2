using UnityEngine;

namespace SwordsAndSandals.Arena
{
    public class PlayerData
    { 
        public string Name => _name;
        private string _name;
        public ArmorData ArmorData => _armorData;
        private ArmorData _armorData; 
        public HealthData HealthData => _healthData;
        private HealthData _healthData;
        public StaminaData StaminaData => _staminaData;
        private StaminaData _staminaData;

        public PlayerData(ArmorData armorData, HealthData healthData, StaminaData staminaData, string name)
        {
            _armorData = armorData;
            _healthData = healthData;
            _staminaData = staminaData;

            _name = name;
        }

        public PlayerData(SwordsAndSandals.PlayerData playerData, PlayerInjector injector, Enums.Direction direction)
        {
            int sign = direction == Enums.Direction.Left ? -1 : 1;

            injector.GetComponent<Rigidbody2D>().simulated = true;

            injector.transform.position = new Vector3(4.89f * sign, -2.5f, 3);

            var sceneScale = new Vector3(3.2f, 3.2f, 3.2f);
            injector.transform.localScale = sceneScale * playerData.DataSkills.Get<Strength>().ScaleCoeff;

            var armorData = new ArmorData(playerData.DataArmors.GetDefence());
            var healthData = new HealthData(playerData.DataSkills.Get<Vitality>());
            var staminaData = new StaminaData(playerData.DataSkills.Get<Stamina>());

            _armorData = armorData;
            _healthData = healthData;
            _staminaData = staminaData;

            _name = playerData.Name;
        }
    }
}
