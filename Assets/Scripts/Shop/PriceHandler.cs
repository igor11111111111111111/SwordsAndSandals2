using SwordsAndSandals.ArmorShop;
using System;

namespace SwordsAndSandals.Shop
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

        public void ClickedAcceptPrice(IData data)
        {
            var price = data.Price.Final;
            if (_playerData.Money >= price)
            {
                _playerData.Money -= price;
                _playerData.Set(data);
                _clothChanger.Set(data);
                 
                OnAcceptPrice?.Invoke();
            }
            else
            {
                OnRejectPrice?.Invoke();
            }
        }
    }
} 