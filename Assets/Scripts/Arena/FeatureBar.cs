using UnityEngine;
using UnityEngine.UI;

namespace SwordsAndSandals.Arena
{
    public class FeatureBar : MonoBehaviour
    {
        [SerializeField] private Text _value;
        [SerializeField] private Slider _slider;

        public void Init(FeatureData featureData)
        {
            featureData.OnValueChanged += Refresh;
        }

        private void Refresh(int current, int max)
        {
            _slider.value = current / (float)max;
            _value.text = current + " / " + max;
        }
    }
}
