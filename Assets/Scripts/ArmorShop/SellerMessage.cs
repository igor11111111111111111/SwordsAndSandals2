using TMPro;
using UnityEngine;

namespace SwordsAndSandals.ArmorShop
{
    public class SellerMessage : MonoBehaviour
    {
        [SerializeField] private GameObject _body;
        [SerializeField] private TextMeshProUGUI _text;
        private float _infoTime = 2f;

        public void Init(ArmorListPanel armorListPanel)
        {
            _body.SetActive(false);

            armorListPanel.OnRequiredLevel += (level) =>
            {
                _text.text = "Need " + level + " level";
                _body.SetActive(true);
                Invoke(nameof(CloseInfo), _infoTime);
            };
        }

        private void CloseInfo()
        {
            _body.SetActive(false);
        }
    }
}