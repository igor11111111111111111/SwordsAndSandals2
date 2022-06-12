using CustomJson;
using System;
using System.Collections.Generic;

namespace SwordsAndSandals
{
    [Serializable]
    public class CurrentSaveData : ISaveIndependentData
    { 
        public string Name;
         
        public CurrentSaveData()
        {
        }

        public CurrentSaveData(string name)
        {
            Name = name;
        }
    }
}
