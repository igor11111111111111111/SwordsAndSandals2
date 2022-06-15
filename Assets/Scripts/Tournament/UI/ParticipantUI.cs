using TMPro;
using UnityEngine;

namespace SwordsAndSandals.Tournament
{
    public class ParticipantUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;

        public void Init(string name)
        {
            _text.text = name;
        }

        public void Init(string name, Color color)
        {
            _text.text = name;
            _text.color = color;
        }
    }
}
