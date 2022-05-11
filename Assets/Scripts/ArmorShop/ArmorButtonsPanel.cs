using UnityEngine;
using UnityEngine.UI;

namespace SwordsAndSandals.ArmorShop
{
    public class ArmorButtonsPanel : MonoBehaviour
    {
        public GameObject Body => _body;
        [SerializeField] private GameObject _body;
        [SerializeField] private ArmorListPanel _armorListPanel;

        [SerializeField] private Button _helmet;
        [SerializeField] private Button _cuirass;
        [SerializeField] private Button _leggins;
        [SerializeField] private Button _boots;
        [SerializeField] private Button _gaiters;
        [SerializeField] private Button _mittens;
        [SerializeField] private Button _pauldrons;
        [SerializeField] private Button _shorts;
        [SerializeField] private Button _shield;

        private ClothChanger _clothChanger;

        public void Init(PlayerDataArmors playerDataArmors, ClothChanger clothChanger)
        {
            _clothChanger = clothChanger;
            _armorListPanel.Init();

            _helmet.onClick.AddListener(
                () => Show(playerDataArmors.Get<Helmet>()));
            _cuirass.onClick.AddListener(
                () => Show(playerDataArmors.Get<Cuirass>()));
            _shorts.onClick.AddListener(
                () => Show(playerDataArmors.Get<Shorts>()));
            _leggins.onClick.AddListener(
                () => Show(playerDataArmors.Get<RightLeggins>()));
            _boots.onClick.AddListener(
                () => Show(playerDataArmors.Get<RightFoot>()));
            _gaiters.onClick.AddListener(
                () => Show(playerDataArmors.Get<RightGaiter>()));
            _mittens.onClick.AddListener(
                () => Show(playerDataArmors.Get<RightMitten>()));
            _pauldrons.onClick.AddListener(
                () => Show(playerDataArmors.Get<RightPauldron>()));
            _shield.onClick.AddListener(
                () => Show(playerDataArmors.Get<Shield>()));

            _body.SetActive(true);
        }

        private void Show(Armor armor)
        {
            _body.SetActive(false);
            _armorListPanel.Show(armor, _clothChanger);
        }
    }
}