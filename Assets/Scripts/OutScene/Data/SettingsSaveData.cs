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

        public SettingsSaveData()
        {
        }

        public SettingsSaveData(bool isMusicEnable, float musicVolume, bool isSoundsEnable, float soundsVolume)
        {
            IsMusicEnable = isMusicEnable;
            MusicVolume = musicVolume;
            IsSoundsEnable = isSoundsEnable;
            SoundsVolume = soundsVolume;
        }
    }
}
