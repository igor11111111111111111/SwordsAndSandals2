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
        [SerializeField] private GameObject _filteredImage;

        public void Init(Sprite[] sprites, Armor armor, PlayerData playerData, Action<Armor> onButtonClick)
        {
            _image.sprite = sprites[armor.ID];
            _filteredImage.SetActive(false);

            if (playerData.DataLevel.Level < armor.RequiredLevel)
            {
                _filteredImage.SetActive(true);
            }
            

            _image.transform.localScale = new Vector3(armor.CellScale, armor.CellScale, 1);

            _button.onClick.AddListener(() => onButtonClick(armor));
        }
    }
}