using UnityEngine;
using UnityEngine.UI;

namespace SwordsAndSandals.Arena
{
    public class FeauturePanel : MonoBehaviour
    {
        [SerializeField] private FeatureBar _energyBar;
        [SerializeField] private FeatureBar _healthBar;
        [SerializeField] private FeatureBar _armorBar;
        [SerializeField] private Text _name;

        public void Init(PlayerData playerData)
        {
            _armorBar.Init(playerData.ArmorData);
            _healthBar.Init(playerData.HealthData);
            _energyBar.Init(playerData.StaminaData);

            playerData.ArmorData.Init();
            playerData.HealthData.Init();
            playerData.StaminaData.Init();

            _name.text = playerData.Name;
        }
    }
}
