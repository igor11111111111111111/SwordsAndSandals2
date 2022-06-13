using CustomJson;
using SwordsAndSandals.OutScene;
using System;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace SwordsAndSandals.Menu
{
    public class MenuUI : MonoBehaviour
    {
        [SerializeField] private Button _new;
        [SerializeField] private Button _save;
        [SerializeField] private Button _load;
        [SerializeField] private Button _settings;
        [SerializeField] private Button _about;
        [SerializeField] private Button _exit;

        [SerializeField] private SettingsUIPanel _settingsUI;
        [SerializeField] private AboutUI _aboutUI;
        [SerializeField] private LoadUI _loadUI;
         
        public void Init()
        { 
            _new.onClick.AddListener(New);
            _save.onClick.AddListener(Save);
            _load.onClick.AddListener(Load);
            _settings.onClick.AddListener(Settings);
            _about.onClick.AddListener(About);
            _exit.onClick.AddListener(Exit);

            _settingsUI.Init();
            _aboutUI.Init();
            _loadUI.Init();
        }

        private void New()
        {
            var saveName = "NewGame " + GetFreeIndex();
            Directory.CreateDirectory(Application.persistentDataPath + "/Saves/" + saveName);
            
            new Json().Save(new CurrentSaveData(saveName));

            new SceneChanger().MoveTo(Enums.Scene.Editor);
        }

        private int GetFreeIndex()
        {
            int index = Directory
                .GetDirectories(Application.persistentDataPath + "/Saves")
                .Select(d => new DirectoryInfo(d).Name)
                .Where(d => d.Contains("NewGame"))
                .Select(d => d.Replace("NewGame", ""))
                .Select(d =>
                {
                    int value;
                    bool success = int.TryParse(d, out value);
                    return new { value, success };
                })
                .Where(pair => pair.success)
                .Select(pair => pair.value)
                .LastOrDefault();

            return index + 1;
        }

        private void Save()
        {
             
        }

        private void Load()
        {
            _loadUI.Activate(true);
        }

        private void Settings()
        {
            _settingsUI.Activate(true);
        }

        private void About()
        {
            _aboutUI.Activate(true);
        }

        private void Exit()
        {
            Application.Quit();
        }
    }
}
