using CustomJson;
using SwordsAndSandals.OutScene;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace SwordsAndSandals.Loading
{
    public class LoadingInit : MonoBehaviour
    {
        private void Awake()
        {
            CreateSaveFiles();
            CreateMusic();
            ApplySettings();

            new SceneChanger().MoveTo(Enums.Scene.Menu);
        }

        private void CreateSaveFiles()
        {
            string savesPath = Application.persistentDataPath + "/Saves";
            if (!File.Exists(savesPath))
            {
                Directory.CreateDirectory(savesPath);
            }

            var currentSaveData = new Json().Load<CurrentSaveData>();
            if (currentSaveData == null)
            {
                new Json().Save(new CurrentSaveData());
            }

            var settingsSaveData = new Json().Load<SettingsSaveData>();
            if (settingsSaveData == null)
            {
                new Json().Save(new SettingsSaveData());
            }
        }

        private void CreateMusic()
        {
            new GameObject("Music").AddComponent<MusicDontDestroy>();
        }

        private void ApplySettings()
        {
            var data = new Json().Load<SettingsSaveData>();

            MusicDontDestroy.SetVolume(data.MusicVolume);
            MusicDontDestroy.SetActive(data.IsMusicEnable);

            //SoundsDontDestroy.SetVolume(data.SoundsVolume);
            //SoundsDontDestroy.SetActive(data.IsSoundsEnable);
        }
    }
}
