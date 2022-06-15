using SwordsAndSandals.Arena;
using UnityEngine;
using UnityEngine.UI;

namespace SwordsAndSandals
{
    public class StatsPanel : MonoBehaviour
    {
        [SerializeField] private Slider _crowd;
        [SerializeField] private Text _crowdInfo;

        private enum CrowdState
        {
            Bored, Restless, Agitated, TurnedOn, Raging
        }

        public void Init(AudienceMoodData audienceMoodData)
        {
            Refresh(audienceMoodData.Current, audienceMoodData.Max);

            audienceMoodData.OnValueChanged += Refresh;
        }

        private void Refresh(int cur, int max)
        {
            _crowd.value = cur / (float)max;

            CrowdState crowdState = CrowdState.Bored;
            if (cur > 0 && cur <= 20)// fix later
            {
                crowdState = CrowdState.Bored;
            }
            else if (cur > 20 && cur <= 40)
            {
                crowdState = CrowdState.Restless;
            }
            else if (cur > 40 && cur <= 60)
            {
                crowdState = CrowdState.Agitated;
            }
            else if (cur > 60 && cur <= 80)
            {
                crowdState = CrowdState.TurnedOn;
            }
            else if (cur > 80 && cur <= 100)
            {
                crowdState = CrowdState.Raging;
            }//
            _crowdInfo.text = "crowd: " + crowdState.ToString();
        }
    }
}

