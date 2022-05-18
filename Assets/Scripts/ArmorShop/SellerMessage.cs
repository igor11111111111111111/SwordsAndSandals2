using TMPro;
using UnityEngine;

namespace SwordsAndSandals.ArmorShop
{
    public class SellerMessage : MonoBehaviour
    {
        [SerializeField] private GameObject _body;
        [SerializeField] private TextMeshProUGUI _text;
        private float _infoTime = 2f;

        public void Init(ArmorListPanel armorListPanel, ArmorPriceHandler armorPriceHandler)
        {
            _body.SetActive(false);

            armorListPanel.OnRequiredLevel += (level) =>
            {
                Message(36, "Need " + level + " level");
            };

            armorPriceHandler.OnRejectPrice += () =>
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