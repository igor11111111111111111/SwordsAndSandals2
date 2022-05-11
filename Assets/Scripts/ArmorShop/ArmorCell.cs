using UnityEngine;
using UnityEngine.UI;

namespace SwordsAndSandals.ArmorShop
{
    public class ArmorCell : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private Image _image;

        public void Init(Sprite sprite, GameObject armorListPanelBody, ArmorPricePanel armorPricePanel)
        {
            _image.sprite = sprite;
            _button.onClick.AddListener(() => 
            {
                armorListPanelBody.SetActive(false);
                armorPricePanel.Show();
            });
        }
    }
}