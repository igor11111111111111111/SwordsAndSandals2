using System;
using UnityEngine;
using UnityEngine.UI;

namespace SwordsAndSandals.Shop
{
    public class Cell : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private Image _image;
        [SerializeField] private GameObject _filteredImage;

        public void Init(Sprite[] sprites, IData data, PlayerData playerData, Action<IData> onButtonClick)
        {
            _image.sprite = sprites[data.ID];
            _filteredImage.SetActive(false);

            if(data is Armor)//!
            {
                if (playerData.DataLevel.Level < (data as Armor).RequiredLevel)
                {
                    _filteredImage.SetActive(true);
                }
            }
            else if (data is Weapon)
            {
                if (playerData.DataSkills.Get<Strength>().Value < (data as Weapon).RequiredStrength)
                {
                    _filteredImage.SetActive(true);
                }
            }//

            _image.transform.localScale = new Vector3(data.CellScale, data.CellScale, 1);

            _button.onClick.AddListener(() => onButtonClick(data));
        }
    }
}