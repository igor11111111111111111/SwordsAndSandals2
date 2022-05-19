using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace SwordsAndSandals.WeaponShop
{
    public class ButtonsPanel : MonoBehaviour
    {
        public GameObject Body => _body;
        [SerializeField] private GameObject _body;
        [SerializeField] private WeaponListPanel _armorListPanel;
        [SerializeField] private SellerMessage _sellerMessage;

        [SerializeField] private Button _hacking;
        [SerializeField] private Button _bashing;

        private AllWeaponData _allWeaponData = new AllWeaponData();

        public void Init(PlayerData playerData, PriceHandler armorPriceHandler)
        {
            _sellerMessage.Init(_armorListPanel, armorPriceHandler);
            _armorListPanel.Init(playerData, () => _body.SetActive(true));

            armorPriceHandler.OnAcceptPrice += () => _body.SetActive(true);

            _hacking.onClick.AddListener(
                () => Show(Weapon.CategoryEnum.Hacking));
            _bashing.onClick.AddListener(
                () => Show(Weapon.CategoryEnum.Bashing));

            _body.SetActive(true);
        }

        private void Show(Weapon.CategoryEnum category)
        {
            _body.SetActive(false);

            List<Weapon> weapons = _allWeaponData.Get(category);
            _armorListPanel.Show(weapons);
        }
    }
}