using CustomJson;
using SwordsAndSandals.OutScene;
using SwordsAndSandals.Shop;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace SwordsAndSandals.Shop
{
    public class ShopInit : MonoBehaviour
    {
        [SerializeField] private AbstractButtonsPanel _armorButtonsPanel;
        [SerializeField] private PricePanel _armorPricePanel;
        [SerializeField] private PlayerSpawner _playerSpawner;
        [SerializeField] private MoneyInfo _moneyInfo;
        [SerializeField] private Button _moveToStreet;

        private void Awake()
        {
            var playerData = new Json().Load<PlayerData>();

            var playerInjector = _playerSpawner.Init
                (
                    playerData,
                    new Vector3(4.75f, -3.28f, 0),
                    new Vector3(8, 6.4f, 1)
                );

            var scene = SceneManager.GetActiveScene().name;//!
            if (scene == Enums.Scene.WeaponShop.ToString())
            {
                playerInjector.gameObject.SetActive(false);
            }
            else if(scene == Enums.Scene.ArmorShop.ToString())
            {
                playerInjector.transform.parent = _armorButtonsPanel.Body.transform;
                playerInjector.transform.localPosition = new Vector3(-0.95f, -190.8f, 1f);
                playerInjector.transform.localScale = new Vector3(382.4f, 305.92f, 1f);
            }//

            var armorPriceHandler = new PriceHandler(_armorPricePanel, playerData, playerInjector.ClothChanger);
            _armorButtonsPanel.Init(playerData, armorPriceHandler);
            _moneyInfo.Init(playerData, armorPriceHandler);

            _moveToStreet.onClick.AddListener(() =>
            {
                new Json().Save(playerData);
                new SceneChanger().MoveTo(Enums.Scene.Street);
            });
        }
    }
}