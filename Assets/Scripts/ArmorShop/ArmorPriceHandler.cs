using System;

namespace SwordsAndSandals.ArmorShop
{
    public class ArmorPriceHandler
    {
        public Action OnAcceptPrice;
        public Action OnRejectPrice;

        private PlayerData _playerData;
        private ClothChanger _clothChanger;

        public ArmorPriceHandler(ArmorPricePanel armorPricePanel, PlayerData playerData, ClothChanger clothChanger)
        {
            _playerData = playerData;
            _clothChanger = clothChanger;

            armorPricePanel.Init(this);
            armorPricePanel.OnClickAccept += ClickedAcceptPrice;
        }

        public void ClickedAcceptPrice(Armor armor)
        {
            var cost = armor.Cost; // - discont etc
            if (_playerData.Money >= cost)
            {
                _playerData.Money -= cost;
                _playerData.DataArmors.Set(armor);
                _clothChanger.Set(armor);

                OnAcceptPrice?.Invoke();
            }
            else
            {
                OnRejectPrice?.Invoke();
            }
        }
    }
} 