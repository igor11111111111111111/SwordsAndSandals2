using CustomJson;
using System;
using System.Collections.Generic;

namespace SwordsAndSandals
{
    [Serializable]
    public class TournamentData : ISaveData
    {
        public Dictionary<int, bool> LevelComplete;

        public TournamentData()
        {
            LevelComplete = new Dictionary<int, bool>();

            for (int i = 1; i < 5; i++)
            {
                LevelComplete.Add(i * 3, false);
            }
        }
    }
}
