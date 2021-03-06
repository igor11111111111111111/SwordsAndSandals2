using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SwordsAndSandals
{
    [Serializable]
    public class PlayerDataExperience
    {
        [JsonIgnore]
        public int Level => GetLevel();
        public int CurrentXP;
        [JsonIgnore]
        private int[] _thresholdToLevel;

        public PlayerDataExperience()
        {
            Init();
        }

        public PlayerDataExperience(int level)
        {
            Init();
            CurrentXP = _thresholdToLevel[level];
            Init();
        }

        private void Init()
        {
            _thresholdToLevel = new int[]
{
                0,
                1000,
                2500,
                4000,
                5500,
                7000,
                9000,
                12000,
                15000, 
                20000,
                24000,
                28500
};
        }

        private int GetLevel()
        {
            return Array.FindIndex(_thresholdToLevel, p => CurrentXP < p) - 1;
        }

        public int GetXPToNewLevel()
        {
            return _thresholdToLevel[Level + 1];
        }
    }
}
 