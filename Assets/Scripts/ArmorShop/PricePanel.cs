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

            _info.text = null;
            //4 % extra charge distance
            _info.text += "Adds " + armor.Defence + " to your armour";
            _info.text += "\n Required gladiator level " + armor.RequiredLevel;
            _info.text += "\n Original armour cost: " + armor.Cost + " gold";

            //Charisma discount: 365 gold
            //Trade~in discount: 270 gold

            //Final armour cost: 133 gold
        }
    }
}