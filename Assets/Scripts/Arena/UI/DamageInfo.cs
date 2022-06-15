using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SwordsAndSandals.Arena
{
    public class DamageInfo : MonoBehaviour
    { 
        [SerializeField] private GameObject _body;
        [SerializeField] private TextMeshProUGUI _text;

        public void Init(AttackHandler attackHandler)
        {
            attackHandler.OnTakeDamage += Show;
            attackHandler.OnBlock += Show;
        }

        public async void Show(int value, Vector3 pos)
        {
            _body.SetActive(true);

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

            await Task.Delay(1000);
            Close();
        }

        private void Close()
        {
            _body.SetActive(false);
        }
    }
}
