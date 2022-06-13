using CustomJson;
using System;

namespace SwordsAndSandals
{
    [Serializable]
    public class SettingsSaveData : ISaveIndependentData
    {
        public bool IsMusicEnable;
        public float MusicVolume;

        public bool IsSoundsEnable;
        public float SoundsVolume;
    }
}
