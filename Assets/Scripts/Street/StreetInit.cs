using CustomJson;
using UnityEngine;
using System;

namespace SwordsAndSandals.Street
{
    public class StreetInit : MonoBehaviour
    {
        [SerializeField] private OutScene.PlayerSpawner _playerSpawner;

        private void Awake()
        {
            var playerData = new Json().Load<PlayerData>(Enums.SaveFilename.Player);

            _playerSpawner.Init
                (
                    playerData,
                    new Vector3(0, -5.25f, 0),
                    3.2f
                );
        }
    }
}
