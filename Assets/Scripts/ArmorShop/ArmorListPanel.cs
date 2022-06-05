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
            _armorPricePanel.Init(() => { _body.SetActive(true); });

            _armorCells = new List<Cell>();
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

            var path = "Armor/" + armors[0].Category.ToString();// fix later
            var sprites = Resources.LoadAll<Sprite>(path);

            if (sprites.Length == 0)
            {
                path = "Armor/" + "Right" + armors[0].Category.ToString();
                sprites = Resources.LoadAll<Sprite>(path);
            }//
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

                var charismaDiscount = _playerData.DataSkills.Get<Charisma>().GetDiscount();
                var tradeInDiscount = (int)(_playerData.DataArmors.Get(armor.Category).Cost / 10f);
                armor.Price = new Price(armor.Cost, charismaDiscount, tradeInDiscount);

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