using CustomJson;
using SwordsAndSandals.OutScene;
using UnityEngine;
using UnityEngine.UI;

namespace SwordsAndSandals.ArmorShop
{
    public class ArmorShopInit : MonoBehaviour
    {
        [SerializeField] private ArmorButtonsPanel _armorButtonsPanel;
        [SerializeField] private PlayerSpawner _playerSpawner;
        [SerializeField] private MoneyInfo _moneyInfo;
        [SerializeField] private Button _moveToStreet;

        private void Awake()
        {
            var playerData = new Json().Load<PlayerData>(Enums.SaveFilename.Player);

            var playerInjector = _playerSpawner.Init
                (
                    playerData,
                    new Vector3(4.75f, -3.28f, 0),
                    new Vector3(8, 6.4f, 1)
                );
            playerInjector.Animator.enabled = false;
            playerInjector.transform.parent = _armorButtonsPanel.Body.transform;

            _armorButtonsPanel.Init(playerData.DataArmors, playerInjector.ClothChanger);
            _moneyInfo.Init(playerData.Money);

            _moveToStreet.onClick.AddListener(() =>
            {
                new SceneChanger().MoveTo(Enums.Scene.Street);
            });
        }
    }
}