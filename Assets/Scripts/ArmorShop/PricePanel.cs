using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace SwordsAndSandals.ArmorShop
{
    public class PricePanel : MonoBehaviour
    {
        [SerializeField] private GameObject _body;
        [SerializeField] private TextMeshProUGUI _name;
        [SerializeField] private TextMeshProUGUI _info;
        [SerializeField] private Button _accept;
        [SerializeField] private Button _deny;

        public Action<Armor> OnClickAccept;

        private Armor _armor;

        public void Init(UnityAction onClickDeny)
        {
            _body.SetActive(false);

            _accept.onClick.AddListener(() => OnClickAccept(_armor));

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

        public void Show(Armor armor)
        {
            _armor = armor;
            _body.SetActive(true);
            _name.text = armor.Name;

            var price = armor.Price;
            _info.text = null;
            //4 % extra charge distance
            _info.text += "Adds " + armor.Defence + " to your armour";
            _info.text += "\n Required gladiator level " + armor.RequiredLevel;
            _info.text += "\n Original armour cost: " + price.Original + " gold";
            _info.text += "\n Charisma discount : " + price.CharismaDiscount + " gold" + "(" + price.CharismaPercentDiscount + "%)";
            _info.text += "\n Trade~in discount: " + price.TradeInDiscount + " gold";
            _info.text += "\n \n Final armour cost: " + price.Final + " gold";
        }
    }
}