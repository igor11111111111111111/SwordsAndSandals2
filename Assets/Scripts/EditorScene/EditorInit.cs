using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace SwordsAndSandals.Editor
{
    public class EditorInit : MonoBehaviour
    {
        [SerializeField] private OutScene.PlayerSpawner _playerSpawner;
        [SerializeField] private PlayerEditor _playerEditor;

        private void Awake()
        {
            PlayerData playerData = new PlayerData();

            var playerInjector = _playerSpawner.Init
                (
                    playerData,
                    new Vector3(1.15f, -4.6f, 0),
                    4.7f
                );

            _playerEditor.Init(playerData, playerInjector);
        }
    }
}
