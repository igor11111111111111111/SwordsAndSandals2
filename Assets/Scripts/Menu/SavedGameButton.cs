using CustomJson;
using SwordsAndSandals.OutScene;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SwordsAndSandals.Menu
{
    public class SavedGameButton : MonoBehaviour
    {
        [SerializeField] private Button _enter;
        [SerializeField] private Button _remove;
        [SerializeField] private TextMeshProUGUI _saveName;
        [SerializeField] private TextMeshProUGUI _name;
        [SerializeField] private TextMeshProUGUI _level;

        public void Init(PlayerData playerData, string saveName)
        {
            _saveName.fontSize = Mathf.Clamp(20.5f - (saveName.Length - 10) * 1f, 0, 20.5f);
            _saveName.text = saveName;
            _name.fontSize = Mathf.Clamp(20.5f - (playerData.Name.Length - 10) * 1f, 0, 20.5f);
            _name.text = playerData.Name;
            _level.text = playerData.DataLevel.Level + " lvl";

            _enter.onClick.AddListener(() => Enter(saveName));
            _remove.onClick.AddListener(() => Remove(saveName));
        }

        private void Enter(string saveName)
        {
            new Json().Save(new CurrentSaveData(saveName));

            new SceneChanger().MoveTo(Enums.Scene.Street);
        }

        private void Remove(string saveName)
        {
            Directory.Delete(Application.persistentDataPath + "/Saves/" + saveName, true);
            Destroy(gameObject);
        }
    }
}
