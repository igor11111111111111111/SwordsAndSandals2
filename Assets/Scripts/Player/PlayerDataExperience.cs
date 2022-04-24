using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace SwordsAndSandals
{
    [Serializable]
    public class PlayerDataExperience
    {
        public int Level => GetLevel();
        public int CurrentExp;
        [JsonIgnore]
        public Dictionary<int, int> ThresholdToLevel;

        public PlayerDataExperience()
        {
            ThresholdToLevel = new Dictionary<int, int>();
            ThresholdToLevel.Add(0, 0);
            ThresholdToLevel.Add(1000, 1);
            ThresholdToLevel.Add(2500, 2);
            ThresholdToLevel.Add(4000, 3);
            ThresholdToLevel.Add(5500, 4);
        }

        private int GetLevel()
        {
            int maxValue = 0;

            foreach (var keyValuePair in ThresholdToLevel)
            {
                if (keyValuePair.Key == 0)
                    continue;

                if (CurrentExp / keyValuePair.Key == 0)
                    return 0;

                if (CurrentExp / keyValuePair.Key == 1)
                    return keyValuePair.Value;

                maxValue = keyValuePair.Value;
            }
            return maxValue;
        }
    }
}
 