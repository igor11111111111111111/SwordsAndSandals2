using System;

namespace SwordsAndSandals.WeaponShop
{
    public class PriceHandler
    {
        public Action OnAcceptPrice;
        public Action OnRejectPrice;

        private PlayerData _playerData;
        private ClothChanger _clothChanger;

        public PriceHandler(PricePanel armorPricePanel, PlayerData playerData, ClothChanger clothChanger)
        {
            _playerData = playerData;
            _clothChanger = clothChanger;

            armorPricePanel.Init(this);
            armorPricePanel.OnClickAccept += ClickedAcceptPrice;
        }

        public void ClickedAcceptPrice(Weapon weapon)
        {
            var cost = weapon.Cost; // - discont etc
            if (_playerData.Money >= cost)
            {
                _playerData.Money -= cost;
                _playerData.DataWeapons.Set(weapon);
                _clothChanger.Set(weapon);

                OnAcceptPrice?.Invoke();
            }
            else
            {
                OnRejectPrice?.Invoke();
            }
        }
    }
} 