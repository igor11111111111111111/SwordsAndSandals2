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

            _info.text = null;
            //4 % extra charge distance
            _info.text += "Adds " + weapon.Damage + " to your armour";
            _info.text += "\n Required gladiator level " + weapon.RequiredStrength;
            _info.text += "\n Original armour cost: " + weapon.Cost + " gold";

            //Charisma discount: 365 gold
            //Trade~in discount: 270 gold

            //Final armour cost: 133 gold
        }
    }
}