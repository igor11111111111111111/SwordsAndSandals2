using SwordsAndSandals.ArmorShop;
using UnityEngine;
using UnityEngine.UI;

namespace SwordsAndSandals
{
    public class MoneyInfo : MonoBehaviour
    {
        [SerializeField] private Text _text;

        public void Init(float money)
        {
            _text.text = money.ToString();
        }

        public void Init(PlayerData playerData, ArmorPriceHandler armorPriceHandler)
        {
            _text.text = playerData.Money.ToString();

            armorPriceHandler.OnAcceptPrice += () =>
            {
                _text.text = playerData.Money.ToString();
            };
        }
    }
}

