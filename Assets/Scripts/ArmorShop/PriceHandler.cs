using System;

namespace SwordsAndSandals.ArmorShop
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

        public void ClickedAcceptPrice(Armor armor)
        {
            var price = armor.Price.Final;
            if (_playerData.Money >= price)
            {
                _playerData.Money -= price;
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