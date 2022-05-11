using TMPro;
using UnityEngine;

namespace SwordsAndSandals.LevelUp
{
    public class LevelUpInfo : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _levelInfo;
        [SerializeField] private TextMeshProUGUI _wiseWordsInfo;

        public void Init(int level)
        {
            _levelInfo.text = "You have risen to gladiator level " + level + ".";
            _wiseWordsInfo.text = "Now is the time. Needs are great, but your possibilities are greater.";
        }
    }
}
