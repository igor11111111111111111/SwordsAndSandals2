using UnityEngine;
using UnityEngine.UI;

namespace SwordsAndSandals.ArmorShop
{
    public class ArmorListPanel : MonoBehaviour
    {
        [SerializeField] private GameObject _body;
        [SerializeField] private ArmorCell _armorCell;
        [SerializeField] private Transform _content;
        [SerializeField] private ArmorPricePanel _armorPricePanel;
        [SerializeField] private Button _deny;

        public void Init()
        {
            _armorPricePanel.Init();

            _body.SetActive(false);

            _deny.onClick.AddListener
                (
                () => { _body.SetActive(false); 
                    // armorpanel activate
                });
        }

        public void Show(Armor armor, ClothChanger clothChanger)
        {
            _body.SetActive(true);

            for (int level = 1; level < Armor.COUNT; level++)
            {
                var sprite = clothChanger
                    .GetSpriteResolver(armor)
                    .spriteLibrary
                    .GetSprite(armor.Category, level.ToString());

                Armor armorClone = armor.Clone(level, sprite);

                Instantiate(_armorCell, _content)
                    .Init(armorClone, ArmorCellOnClickAction);
            }
        }

        private void ArmorCellOnClickAction(Armor armor)
        {
            _body.SetActive(false);
            _armorPricePanel.Show(armor);
        }
    }
}