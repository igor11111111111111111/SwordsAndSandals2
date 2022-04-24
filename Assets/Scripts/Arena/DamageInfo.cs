using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SwordsAndSandals.Arena
{
    public class DamageInfo : MonoBehaviour
    {
        [SerializeField] private GameObject _body;
        [SerializeField] private TextMeshProUGUI _text;

        public void Show(int value, PlayerInjector playerInjector)
        {
            _body.SetActive(true);
            var offset = new Vector3(0, 5, 0);
            transform.position = playerInjector.transform.position + offset;

            if (value == 0)
            {
                _text.fontSize = 0.45f;
                _text.text = "Dodge";
            }
            else
            {
                _text.fontSize = 0.9f;
                _text.text = value.ToString();
            }

            Invoke(nameof(Close), 1f);
        }

        private void Close()
        {
            _body.SetActive(false);
        }
    }
}
