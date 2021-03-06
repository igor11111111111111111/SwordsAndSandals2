using SwordsAndSandals.Shop;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace SwordsAndSandals.Shop
{
    public class PricePanel : MonoBehaviour
    {
        [SerializeField] private GameObject _body;
        [SerializeField] private TextMeshProUGUI _name;
        [SerializeField] private TextMeshProUGUI _info;
        [SerializeField] private Button _accept;
        [SerializeField] private Button _deny;

        public Action<IData> OnClickAccept;

        private IData _data;

        public void Init(UnityAction onClickDeny)
        {
            _body.SetActive(false);

            _accept.onClick.AddListener(() => OnClickAccept(_data));

            _deny.onClick.AddListener(onClickDeny);
            _deny.onClick.AddListener(() =>
            {
                _body.SetActive(false);
            });
        }

        public void Init(PriceHandler armorPriceHandler)
        {
            armorPriceHandler.OnAcceptPrice += () => _body.SetActive(false);
        }

        public void Show(IData data)
        {
            _data = data;
            _body.SetActive(true);
            _name.text = data.Name;

            var price = data.Price;
            _info.text = null;

            //4 % extra charge distance etc bonuses

            if(data is Weapon)
            {
                _info.text += (data as Weapon).MinDamage + " - " + (data as Weapon).MaxDamage + " Damage";
                _info.text += "\n Required gladiator strength " + (data as Weapon).RequiredStrength;
            }
            if (data is Armor)
            {
                _info.text += "Adds " + (data as Armor).Defence + " to your armour";
                _info.text += "\n Required gladiator level " + (data as Armor).RequiredLevel;
            }

            _info.text += "\n Original armour cost: " + price.Original + " gold";
            _info.text += "\n Charisma discount : " + price.CharismaDiscount + " gold" + "(" + price.CharismaPercentDiscount + "%)";
            _info.text += "\n Trade~in discount: " + price.TradeInDiscount + " gold";
            _info.text += "\n \n Final armour cost: " + price.Final + " gold";
        }
    }
}