using SwordsAndSandals;
using SwordsAndSandals.OutScene;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SwordsAndSandals.Street
{
    public class ArenaPanel : MonoBehaviour
    {
        [SerializeField] private Button _button;

        private void Awake()
        {
            _button.onClick.AddListener(() => 
            {
                new SceneChanger().MoveTo(Enums.Scene.PreArena);
            });
        }
    }
}
