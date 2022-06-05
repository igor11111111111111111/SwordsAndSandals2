using System;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;

namespace SwordsAndSandals
{
    [Serializable]
    public class Armor 
    {
        public CategoryEnum Category;
        public int ID;
        public string Name;
        public int Cost;
        public int Defence;
        public int RequiredLevel;
        public float CellScale;
        [JsonIgnore] public Price Price;

        public enum CategoryEnum
        {
            Helmet,
            Cuirass,
            Short,
            Boot,
            Gaiter,
            Leggin,
            Mitten,
            Pauldron,
            Shield
        }

        public Armor()
        {
        }

        public Armor(CategoryEnum category)
        {
            Category = category;
            ID = 0;
        }

        public Armor(CategoryEnum category, int id)
        {
            Category = category;
            ID = id;
        }

        public Armor(int id, CategoryEnum category, string name, int cost, int defence, int requiredLevel, float cellScale)
        { 
            ID = id;
            Category = category;
            Name = name;
            Cost = cost;
            Defence = defence;
            RequiredLevel = requiredLevel;
            CellScale = cellScale;
        }
    }
}

