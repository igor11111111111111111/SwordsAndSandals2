using CustomJson;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SwordsAndSandals.Menu
{
    public class SettingsUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _name;
        [SerializeField] private Slider _slider;
        [SerializeField] private Toggle _toggle;

        public void Init(SettingsSaveData data, Enums.Setting setting, Button exit)
        {
            _name.text = setting.ToString();
            name = setting.ToString();

            if (setting == Enums.Setting.Music)
                Music(data, exit);
            else if(setting == Enums.Setting.Sounds)
                Sounds(data, exit);
        }

        private void Music(SettingsSaveData data, Button exit)
        {
            _name.fontSize = 30;
            _slider.value = data.MusicVolume;
            _toggle.isOn = data.IsMusicEnable;

            _slider.onValueChanged.AddListener(MusicDontDestroy.SetVolume);
            _toggle.onValueChanged.AddListener((isOn) =>
            {
                MusicDontDestroy.SetActive(isOn);
                if (isOn)
                    MusicDontDestroy.SetClip("Menu", true, true);
            });

            exit.onClick.AddListener(() =>
            {
                data.MusicVolume = _slider.value;
                data.IsMusicEnable = _toggle.isOn;
                new Json().Save(data);
            });
        }

        private void Sounds(SettingsSaveData data, Button exit)
        {
            _name.fontSize = 28.6f;
            _slider.value = data.SoundsVolume;
            _toggle.isOn = data.IsSoundsEnable;

            //_slider.onValueChanged.AddListener(MusicDontDestroy.SetVolume);
            //_toggle.onValueChanged.AddListener((isOn) =>
            //{
            //    MusicDontDestroy.SetActive(isOn);
            //    if (isOn)
            //        MusicDontDestroy.SetClip("Menu", true);
            //});

            //exit.onClick.AddListener(() =>
            //{
            //    data.MusicVolume = _slider.value;
            //    data.IsMusicEnable = _toggle.isOn;
            //    new Json().Save(data);
            //});
        }
    }
}
