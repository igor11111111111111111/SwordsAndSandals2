using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace SwordsAndSandals.ArmorShop
{
    public class ArmorCell : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private Image _image;

        public void Init(Armor armor, Action<Armor> onClickAction)
        {
            _image.sprite = armor.Sprite; 
            _image.transform.localScale = new Vector3(armor.CellScale, armor.CellScale, 1);

            _button.onClick.AddListener(() => onClickAction(armor));
        }
    }
}