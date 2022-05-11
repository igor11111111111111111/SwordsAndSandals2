using UnityEngine;
using UnityEngine.UI;

namespace SwordsAndSandals
{
    public class MoneyInfo : MonoBehaviour
    {
        [SerializeField] private Text _text;

        public void Init(float money)
        {
            _text.text = money.ToString();
        }
    }
}

