using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace SwordsAndSandals.WeaponShop
{
    public class PricePanel : MonoBehaviour
    {
        [SerializeField] private GameObject _body;
        [SerializeField] private TextMeshProUGUI _name;
        [SerializeField] private TextMeshProUGUI _info;
        [SerializeField] private Button _accept;
        [SerializeField] private Button _deny;

        public Action<Weapon> OnClickAccept;

        private Weapon _weapon;

        public void Init(UnityAction onClickDeny)
        {
            _body.SetActive(false);

            _accept.onClick.AddListener(() => OnClickAccept(_weapon));

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

        public void Show(Weapon weapon)
        {
            _weapon = weapon;
            _body.SetActive(true);
            _name.text = weapon.Name;

            var price = weapon.Price;
            _info.text = null;
            _info.text += weapon.MinDamage + " - " + weapon.MaxDamage + " Damage";
            _info.text += "\n Required gladiator strength " + weapon.RequiredStrength;

            _info.text += "\n Original weapon cost: " + price.Original + " gold";
            _info.text += "\n Charisma discount : " + price.CharismaDiscount + " gold" + "(" + price.CharismaPercentDiscount + "%)";
            _info.text += "\n Trade~in discount: " + price.TradeInDiscount + " gold";
            _info.text += "\n \n Final armour cost: " + price.Final + " gold";
        }
    }
}