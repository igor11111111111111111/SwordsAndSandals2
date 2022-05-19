using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace SwordsAndSandals.WeaponShop
{
    public class WeaponListPanel : MonoBehaviour
    {
        [SerializeField] private GameObject _body;
        [SerializeField] private Cell _armorCell;
        [SerializeField] private Transform _content;
        [SerializeField] private PricePanel _armorPricePanel;
        [SerializeField] private Button _deny;

        public Action<int> OnRequiredLevel;

        private List<Cell> _armorCells;
        private PlayerData _playerData;

        public void Init(PlayerData playerData, UnityAction onClickDeny)
        {
            _playerData = playerData;
            _armorPricePanel.Init(() => 
            {
                _body.SetActive(true);
            });

            _armorCells = new List<Cell>();
            _body.SetActive(false);

            _deny.onClick.AddListener(onClickDeny);
            _deny.onClick.AddListener(() => 
            {
                _body.SetActive(false);
            });
        }

        public void Show(List<Weapon> weapons)
        {
            Clear();

            var path = "Weapon/" + weapons[0].Category.ToString();
            var sprites = Resources.LoadAll<Sprite>(path);

            foreach (var weapon in weapons)
            {
                var armorCell = Instantiate(_armorCell, _content);
                armorCell.Init(sprites, weapon, _playerData, OnButtonClick);

                _armorCells.Add(armorCell);
            }

            _body.SetActive(true);
        }

        private void OnButtonClick(Weapon weapon)
        {
            if (_playerData.DataLevel.Level < weapon.RequiredStrength)
            {
                OnRequiredLevel?.Invoke(weapon.RequiredStrength);
            }
            else
            {
                _body.SetActive(false);
                _armorPricePanel.Show(weapon);
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