using SwordsAndSandals.OutScene;
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

        [SerializeField] private SettingsUI _settingsUI;
        [SerializeField] private AboutUI _aboutUI;

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
        }

        private void New()
        {
            new SceneChanger().MoveTo(Enums.Scene.Editor);
        }

        private void Save()
        {

        }

        private void Load()
        {
            new SceneChanger().MoveTo(Enums.Scene.Street);
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
