using CustomJson;
using UnityEngine;
using System;

namespace SwordsAndSandals.Street
{
    public class StreetInit : MonoBehaviour
    {
        [SerializeField] private OutScene.PlayerSpawner _playerSpawner;

        [SerializeField] private BuildingPanel _arenaPanel;
        [SerializeField] private BuildingPanel _weaponPanel;
        [SerializeField] private BuildingPanel _armorPanel;

        private void Awake()
        {
            var playerData = new Json().Load<PlayerData>();

            _playerSpawner.Init
            (
                playerData,
                new Vector3(0, -5.25f, 0),
                3.2f
            );

            _arenaPanel.Init(Enums.Scene.PreArena);
            _weaponPanel.Init(Enums.Scene.WeaponShop);
            _armorPanel.Init(Enums.Scene.ArmorShop);

            MusicDontDestroy.SetClip("Street", true, true);
        }
    }
}
