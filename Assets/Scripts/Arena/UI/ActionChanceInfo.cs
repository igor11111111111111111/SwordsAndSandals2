using TMPro;
using UnityEngine;

namespace SwordsAndSandals.Arena
{
    public class ActionChanceInfo : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private GameObject _body;

        public void Show(int value, bool active)
        {
            _body.SetActive(active);
            _text.text = value + "%";
        }
    }
}
