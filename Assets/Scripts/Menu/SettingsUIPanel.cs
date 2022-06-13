using CustomJson;
using UnityEngine;
using UnityEngine.UI;

namespace SwordsAndSandals.Menu
{
    public class SettingsUIPanel : MonoBehaviour
    {
        [SerializeField] private GameObject _body;
        [SerializeField] private Button _exit;
        [SerializeField] private SettingsUI _settingsUI;

        public void Init()
        {
            var data = new Json().Load<SettingsSaveData>();
            Instantiate(_settingsUI, _body.transform)
                .Init(data, Enums.Setting.Music, _exit);
            Instantiate(_settingsUI, _body.transform)
                .Init(data, Enums.Setting.Sounds, _exit);

            _exit.onClick.AddListener(() => Activate(false));
        }

        public void Activate(bool active)
        {
            _body.SetActive(active);
        }
    }
}
