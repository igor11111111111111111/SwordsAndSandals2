using TMPro;
using UnityEngine;

namespace SwordsAndSandals.ArmorShop
{
    public class ArmorPricePanel : MonoBehaviour
    {
        [SerializeField] private GameObject _body;
        [SerializeField] private TextMeshProUGUI _name;
        [SerializeField] private TextMeshProUGUI _info;

        public void Init()
        {
            _body.SetActive(false);
        }

        public void Show(Armor armor)
        {
            _body.SetActive(true);

            _name.text = armor.Name;

            _info.text = null;
            //4 % extra charge distance
            _info.text += "Adds " + armor.Defence + " to your armour";
            _info.text += "\n Required gladiator level " + armor.RequiredGladiatorLevel;
            _info.text += "\n Original armour cost: " + armor.Cost + " gold";

            //Charisma discount: 365 gold
            //Trade~in discount: 270 gold

            //Final armour cost: 133 gold
        }
    }
}