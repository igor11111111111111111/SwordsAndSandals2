using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace SwordsAndSandals.ArmorShop
{
    public class ArmorListPanel : MonoBehaviour
    {
        [SerializeField] private GameObject _body;
        [SerializeField] private ArmorCell _armorCell;
        [SerializeField] private Transform _content;
        [SerializeField] private ArmorPricePanel _armorPricePanel;
        [SerializeField] private Button _deny;

        public Action<int> OnRequiredLevel;

        private List<ArmorCell> _armorCells;
        private PlayerData _playerData;

        public void Init(PlayerData playerData, UnityAction onClickDeny)
        {
            _playerData = playerData;
            _armorPricePanel.Init(() => 
            {
                _body.SetActive(true);
            });

            _armorCells = new List<ArmorCell>();
            _body.SetActive(false);

            _deny.onClick.AddListener(onClickDeny);
            _deny.onClick.AddListener(() => 
            {
                _body.SetActive(false);
            });
        }

        public void Show(List<Armor> armors)
        {
            Clear();

            var sprites = Resources.LoadAll<Sprite>(armors[0].SpritesPath);
            foreach (var armor in armors)
            {
                var armorCell = Instantiate(_armorCell, _content);
                armorCell.Init(sprites, armor, _playerData, OnButtonClick);

                _armorCells.Add(armorCell);
            }

            _body.SetActive(true);
        }

        private void OnButtonClick(Armor armor)
        {
            if (_playerData.DataLevel.Level < armor.RequiredLevel)
            {
                OnRequiredLevel?.Invoke(armor.RequiredLevel);
            }
            else
            {
                _body.SetActive(false);
                _armorPricePanel.Show(armor);
            }
        }

        private void Clear()
        {
            foreach (var cell in _armorCells)
            {
                Destroy(cell.gameObject);
            }
            _armorCells.Clear();
        }
    }
}