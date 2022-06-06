using SwordsAndSandals.Shop;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace SwordsAndSandals.ArmorShop
{
    public class ButtonsPanel : AbstractButtonsPanel
    {
        public override GameObject Body => _body;
        [SerializeField] private GameObject _body;
        [SerializeField] private DataListPanel _armorListPanel;
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

        private AllArmorData _allArmorData = new AllArmorData();

        public override void Init(PlayerData playerData, PriceHandler armorPriceHandler)
        {
            _sellerMessage.Init(_armorListPanel, armorPriceHandler);
            _armorListPanel.Init(playerData, () => _body.SetActive(true));

            armorPriceHandler.OnAcceptPrice += () => _body.SetActive(true);

            _helmet.onClick.AddListener(
                () => Show(Armor.CategoryEnum.Helmet));
            _cuirass.onClick.AddListener(
                () => Show(Armor.CategoryEnum.Cuirass));
            _shorts.onClick.AddListener(
                () => Show(Armor.CategoryEnum.Short));
            _leggins.onClick.AddListener(
                () => Show(Armor.CategoryEnum.Leggin));
            _boots.onClick.AddListener(
                () => Show(Armor.CategoryEnum.Boot));
            _gaiters.onClick.AddListener(
                () => Show(Armor.CategoryEnum.Gaiter));
            _mittens.onClick.AddListener(
                () => Show(Armor.CategoryEnum.Mitten));
            _pauldrons.onClick.AddListener(
                () => Show(Armor.CategoryEnum.Pauldron));
            _shield.onClick.AddListener(
                () => Show(Armor.CategoryEnum.Shield));

            _body.SetActive(true);
        }

        private void Show(Armor.CategoryEnum category)
        {
            _body.SetActive(false);

            List<Armor> armors = _allArmorData.Get(category);
            List<IData> datas = armors.Select(a => a as IData).ToList();
            _armorListPanel.Show(datas);
        }
    }
}