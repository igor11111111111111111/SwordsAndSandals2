﻿using CustomJson;
using SwordsAndSandals.OutScene;
using UnityEngine;
using UnityEngine.UI;

namespace SwordsAndSandals.WeaponShop
{
    public class ShopInit : MonoBehaviour
    {
        [SerializeField] private ButtonsPanel _armorButtonsPanel;
        [SerializeField] private PricePanel _armorPricePanel;
        [SerializeField] private PlayerSpawner _playerSpawner;
        [SerializeField] private MoneyInfo _moneyInfo;
        [SerializeField] private Button _moveToStreet;

        private void Awake()
        {
            var playerData = new Json().Load<PlayerData>(Enums.SaveFilename.Player);

            var playerInjector = _playerSpawner.Init
                (
                    playerData,
                    new Vector3(4.75f, -3.28f, 0),
                    new Vector3(8, 6.4f, 1)
                );

            playerInjector.gameObject.SetActive(false);

            var armorPriceHandler = new PriceHandler(_armorPricePanel, playerData, playerInjector.ClothChanger);
            _armorButtonsPanel.Init(playerData, armorPriceHandler);
            _moneyInfo.Init(playerData, armorPriceHandler);

            _moveToStreet.onClick.AddListener(() =>
            {
                new Json().Save(playerData, Enums.SaveFilename.Player);
                new SceneChanger().MoveTo(Enums.Scene.Street);
            });
        }
    }
}