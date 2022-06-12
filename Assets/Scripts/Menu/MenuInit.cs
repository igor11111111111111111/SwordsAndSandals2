using CustomJson;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

namespace SwordsAndSandals.Menu
{
    public class MenuInit : MonoBehaviour
    {
        [SerializeField] private MenuUI _menuUI;

        private void Awake()
        {
            Init();
            _menuUI.Init();
        }

        private void Init()
        {
            string savesPath = Application.persistentDataPath + "/Saves";
            if (!File.Exists(savesPath))
            {
                var folderPath = Directory.CreateDirectory(savesPath);
            }

            var currentSaveData = new Json().Load<CurrentSaveData>();
            if(currentSaveData == null)
            {
                new Json().Save(new CurrentSaveData());
            }

            var settingsSaveData = new Json().Load<SettingsSaveData>();
            if (settingsSaveData == null)
            {
                new Json().Save(new SettingsSaveData());
            }
        }
    }
}
