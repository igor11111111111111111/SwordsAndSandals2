using UnityEngine;

namespace SwordsAndSandals.ArmorShop
{
    public class ArmorListPanel : MonoBehaviour
    {
        [SerializeField] private GameObject _body;
        [SerializeField] private ArmorCell _armorCell;
        [SerializeField] private Transform _content;
        [SerializeField] private ArmorPricePanel _armorPricePanel;

        public void Init()
        {
            _armorPricePanel.Init();

            _body.SetActive(false);
        }

        public void Show(Armor armor, ClothChanger clothChanger)
        {
            _body.SetActive(true);
            for (int i = 1; i < 2; i++) // cause have 1 variant clothes
            {
                var sprite = clothChanger
                    .GetSpriteResolver(armor)
                    .spriteLibrary
                    .GetSprite(armor.Name, i.ToString());

                Instantiate(_armorCell, _content)
                    .Init(sprite, _body, _armorPricePanel);
            }
        }
    }
}