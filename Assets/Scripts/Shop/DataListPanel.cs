using SwordsAndSandals.ArmorShop;
using SwordsAndSandals.Shop;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace SwordsAndSandals.Shop
{ 
    public class DataListPanel : MonoBehaviour
    {
        [SerializeField] private GameObject _body;
        [SerializeField] private Cell _cell;
        [SerializeField] private Transform _content;
        [SerializeField] private PricePanel _pricePanel;
        [SerializeField] private Button _deny;

        public Action<int> OnRequiredLevel;
        public Action<int> OnRequiredStrength;

        private List<Cell> _cells;
        private PlayerData _playerData;

        public void Init(PlayerData playerData, UnityAction onClickDeny)
        {
            _playerData = playerData;
            _pricePanel.Init(() => { _body.SetActive(true); });

            _cells = new List<Cell>();
            _body.SetActive(false);

            _deny.onClick.AddListener(onClickDeny);
            _deny.onClick.AddListener(() => { _body.SetActive(false); });
        }

        public void Show(List<IData> datas)
        {
            Sprite[] sprites = null;
            Clear();

            if (datas[0] is Armor)
            {
                var category = (datas[0] as Armor).Category.ToString();
                var path = "Armor/" + category;// fix later
                sprites = Resources.LoadAll<Sprite>(path);

                if (sprites.Length == 0)
                {
                    path = "Armor/" + "Right" + category;
                    sprites = Resources.LoadAll<Sprite>(path);
                }//
            }
            else if(datas[0] is Weapon)
            {
                var category = (datas[0] as Weapon).Category.ToString();
                var path = "Weapon/" + category;
                sprites = Resources.LoadAll<Sprite>(path);
            }
 
            foreach (var data in datas)
            {
                var armorCell = Instantiate(_cell, _content);
                armorCell.Init(sprites, data, _playerData, OnButtonClick);

                _cells.Add(armorCell);
            }

            _body.SetActive(true);
        }

        private void OnButtonClick(IData data)
        {
            if(data is Armor)
            {
                if (_playerData.DataLevel.Level < (data as Armor).RequiredLevel)
                {
                    OnRequiredLevel?.Invoke((data as Armor).RequiredLevel);
                }
                else
                {
                    Test(data);
                }
            }
            else if (data is Weapon)
            {
                if (_playerData.DataSkills.Get<Strength>().Value < (data as Weapon).RequiredStrength)
                {
                    OnRequiredStrength?.Invoke((data as Weapon).RequiredStrength);
                }
                else
                {
                    Test(data);
                }
            }
        }

        private void Test(IData data)
        {
            _body.SetActive(false);

            var charismaDiscount = _playerData.DataSkills.Get<Charisma>().GetDiscount();

            int tradeInDiscount = 0;
            if (data is Armor)
            {
                tradeInDiscount = (int)(_playerData.DataArmors.Get((data as Armor).Category).Cost / 10f);
            }
            else if (data is Weapon)
            {
                tradeInDiscount = (int)(_playerData.DataWeapons.Current.Cost / 10f);
            }

            data.Price = new Price(data.Cost, charismaDiscount, tradeInDiscount);

            _pricePanel.Show(data);
        }

        private void Clear()
        {
            foreach (var cell in _cells)
            {
                Destroy(cell.gameObject);
            }
            _cells.Clear();
        }
    }
}