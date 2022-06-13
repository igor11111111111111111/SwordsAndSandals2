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
            _menuUI.Init();
            MusicDontDestroy.SetClip("Menu", true);
        }
    }
}
