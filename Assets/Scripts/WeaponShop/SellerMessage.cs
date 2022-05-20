using TMPro;
using UnityEngine;

namespace SwordsAndSandals.WeaponShop
{
    public class SellerMessage : MonoBehaviour
    {
        [SerializeField] private GameObject _body;
        [SerializeField] private TextMeshProUGUI _text;
        private float _infoTime = 2f;

        public void Init(WeaponListPanel armorListPanel, PriceHandler armorPriceHandler)
        {
            _body.SetActive(false);

            armorListPanel.OnRequiredStrength += (strength) =>
            {
                Message(36, "Need " + strength + " strength");
            };

            armorPriceHandler.OnRejectPrice += () =>
            {
                Message(22, "no no no... This will not work, I accept payment in cash, by card or bitcoins");
            };
        }

        private void Message(int fontSize, string text)
        {
            _text.fontSize = fontSize;
            _text.text = text;
            _body.SetActive(true);
            Invoke(nameof(CloseInfo), _infoTime);
        }

        private void CloseInfo()
        {
            _body.SetActive(false);
        }
    }
}