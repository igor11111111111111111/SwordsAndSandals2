using SwordsAndSandals.Shop;
using TMPro;
using UnityEngine;

namespace SwordsAndSandals.Shop
{
    public class SellerMessage : MonoBehaviour
    {
        [SerializeField] private GameObject _body;
        [SerializeField] private TextMeshProUGUI _text;
        private float _infoTime = 2f;

        public void Init(DataListPanel dataListPanel, PriceHandler priceHandler)
        {
            _body.SetActive(false);

            dataListPanel.OnRequiredLevel += (level) =>
            {
                Message(36, "Need " + level + " level");
            };

            dataListPanel.OnRequiredStrength += (strength) =>
            {
                Message(36, "Need " + strength + " strength");
            };

            priceHandler.OnRejectPrice += () =>
            {
                Message(22, "Pay or get lost, don't scratch my eyes with your presence");
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