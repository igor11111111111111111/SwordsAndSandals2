using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace SwordsAndSandals.WeaponShop
{
    public class Cell : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private Image _image;
        [SerializeField] private GameObject _filteredImage;

        public void Init(Sprite[] sprites, Weapon weapon, PlayerData playerData, Action<Weapon> onButtonClick)
        {
            _image.sprite = sprites[weapon.ID];
            _filteredImage.SetActive(false);

            if (playerData.DataLevel.Level < weapon.RequiredStrength)
            {
                _filteredImage.SetActive(true);
            }

            _image.transform.localScale = new Vector3(weapon.CellScale, weapon.CellScale, 1);

            _button.onClick.AddListener(() => onButtonClick(weapon));
        }
    }
}