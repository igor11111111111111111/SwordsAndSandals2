using UnityEngine;
using UnityEngine.UI;

namespace SwordsAndSandals.Arena
{
    public class FeatureBar : MonoBehaviour
    {
        [SerializeField] private Text _value;

        public void Init(FeatureData featureData)
        {
            featureData.OnValueChanged += Refresh;
        }

        private void Refresh(string currentMaxValue)
        {
            _value.text = currentMaxValue;
        }
    }
}
