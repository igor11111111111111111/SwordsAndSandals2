﻿using UnityEngine;

namespace SwordsAndSandals.Arena
{
    public class ArenaPanel : MonoBehaviour
    {
        [SerializeField] private GameObject _body;
        [SerializeField] public FeauturePanel _playerPanel;
        [SerializeField] public FeauturePanel _aiPanel;

        public void Init(FatalityPanel fatalityPanel)
        {
            Show(false);

            fatalityPanel.OnClicked += () => { Show(false); };
        }

        public void Init(PlayerData playerData, PlayerData aiData)
        {
            _playerPanel.Init(playerData);
            _aiPanel.Init(aiData);
        }

        public void Show(bool active)
        {
            _body.SetActive(active);
        }
    }
}
