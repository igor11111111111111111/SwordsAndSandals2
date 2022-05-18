using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace SwordsAndSandals.ArmorShop
{
    public class ArmorButtonsPanel : MonoBehaviour
    {
        public GameObject Body => _body;
        [SerializeField] private GameObject _body;
        [SerializeField] private ArmorListPanel _armorListPanel;
        [SerializeField] private SellerMessage _sellerMessage;

        [SerializeField] private Button _helmet;
        [SerializeField] private Button _cuirass;
        [SerializeField] private Button _leggins;
        [SerializeField] private Button _boots;
        [SerializeField] private Button _gaiters;
        [SerializeField] private Button _mittens;
        [SerializeField] private Button _pauldrons;
        [SerializeField] private Button _shorts;
        [SerializeField] private Button _shield;

        private ArmorInit _armorInit = new ArmorInit();

        public void Init(PlayerData playerData, ArmorPriceHandler armorPriceHandler)
        {
            _sellerMessage.Init(_armorListPanel, armorPriceHandler);
            _armorListPanel.Init(playerData, () => _body.SetActive(true));

            armorPriceHandler.OnAcceptPrice += () => _body.SetActive(true);

            _helmet.onClick.AddListener(
                () => Show(playerData.DataArmors.Get(Armor.CategoryEnum.Helmet)));
            _cuirass.onClick.AddListener(
                () => Show(playerData.DataArmors.Get(Armor.CategoryEnum.Cuirass)));
            _shorts.onClick.AddListener(
                () => Show(playerData.DataArmors.Get(Armor.CategoryEnum.Short)));
            _leggins.onClick.AddListener(
                () => Show(playerData.DataArmors.Get(Armor.CategoryEnum.RightLeggin)));
            _boots.onClick.AddListener(
                () => Show(playerData.DataArmors.Get(Armor.CategoryEnum.RightBoot)));
            _gaiters.onClick.AddListener(
                () => Show(playerData.DataArmors.Get(Armor.CategoryEnum.RightGaiter)));
            _mittens.onClick.AddListener(
                () => Show(playerData.DataArmors.Get(Armor.CategoryEnum.RightMitten)));
            _pauldrons.onClick.AddListener(
                () => Show(playerData.DataArmors.Get(Armor.CategoryEnum.RightPauldron)));
            _shield.onClick.AddListener(
                () => Show(playerData.DataArmors.Get(Armor.CategoryEnum.Shield)));

            _body.SetActive(true);
        }

        private void Show(Armor armor)
        {
            _body.SetActive(false);

            List<Armor> armors = _armorInit.Armors.Where(a => a.Category == armor.Category).ToList();
            _armorListPanel.Show(armors);
        }
    }
}