using CustomJson;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace SwordsAndSandals.Menu
{
    public class LoadUI : MonoBehaviour
    {
        [SerializeField] private GameObject _body;
        [SerializeField] private Button _exit;
        [SerializeField] private SavedGameButton _savedGameButton;
        [SerializeField] private Transform _content;

        public void Init()
        {
            DisplaySaves();

            _exit.onClick.AddListener(() => Activate(false));
        }

        public void Activate(bool active)
        {
            _body.SetActive(active);
        }

        private void DisplaySaves()
        {
            var saves = Directory
               .GetDirectories(Application.persistentDataPath + "/Saves")
               .Where(d =>// need more check
               {
                   var files = new DirectoryInfo(d).GetFiles();
                   return (files.Length > 0) ? true : false;
               })//
               .Select(d => new DirectoryInfo(d).Name)
               .ToArray();

            foreach (var save in saves)
            {
                var playerData = new Json().Load<PlayerData>(save);
                Instantiate(_savedGameButton, _content).Init(playerData, save);
            }
        }
    }
}
