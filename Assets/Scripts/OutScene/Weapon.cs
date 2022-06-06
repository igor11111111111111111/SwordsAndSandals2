using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace SwordsAndSandals
{
    [Serializable]
    public class Weapon : IData
    {
        public CategoryEnum Category;
        public int ID;
        int IData.ID { get => ID; set => ID = value; }
        [JsonIgnore] public string Name { get; set; }
        [JsonIgnore] public int Cost { get; set; }
        [JsonIgnore] public int MinDamage;
        [JsonIgnore] public int MaxDamage;
        [JsonIgnore] public int RequiredStrength;
        [JsonIgnore] public float CellScale { get; set; }
        [JsonIgnore] public Price Price { get; set; }

        public enum CategoryEnum
        {
            Bashing,
            Hacking
        }

        public Weapon()
        {
            Category = CategoryEnum.Bashing;
            ID = 0;
            MinDamage = 1;
            MaxDamage = 5;
        }

        public Weapon(CategoryEnum category, int id)
        {
            Category = category;
            ID = id;
        }
         
        public Weapon(CategoryEnum category, int id, string name, int cost, int minDamage, int maxDamage, int requiredStrength, float cellScale)
        {
            Category = category;
            ID = id;
            Name = name;
            Cost = cost;
            MinDamage = minDamage;
            MaxDamage = maxDamage;
            RequiredStrength = requiredStrength;
            CellScale = cellScale;
        }

        public int GetRandMinMaxDamage()
        {
            return UnityEngine.Random.Range(MinDamage, MaxDamage + 1);
        }
    }
}

