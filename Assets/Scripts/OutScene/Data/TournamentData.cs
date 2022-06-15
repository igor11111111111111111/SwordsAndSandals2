using CustomJson;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SwordsAndSandals
{
    [Serializable]
    public class TournamentData : IUtilitySaveData
    {
        public LevelCompleteData[] Array;


        public TournamentData()
        {
            // change 10 to count tournaments
            Array = new LevelCompleteData[10];
            for (int i = 0; i < Array.Length; i++)
            {
                Array[i] = new LevelCompleteData(i * 3 + 3, false);
            }
        }

        public LevelCompleteData GetFirstComplete(bool isComplete)
        {
            return Array.Where(a => a.Complete == isComplete).FirstOrDefault();
        }

        public void SetCurrentComplete()
        {
            Array.Where(a => a.Complete == false).FirstOrDefault().Complete = true;
        }
    }
}
