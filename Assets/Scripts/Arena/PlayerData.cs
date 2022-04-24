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
    }
}
