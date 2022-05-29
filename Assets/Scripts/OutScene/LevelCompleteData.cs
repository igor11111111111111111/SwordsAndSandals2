using System;

namespace SwordsAndSandals
{
    [Serializable]
    public class LevelCompleteData
    {
        public int Level;
        public bool Complete;

        public LevelCompleteData(int level, bool complete)
        {
            Level = level;
            Complete = complete;
        }
    }
}
