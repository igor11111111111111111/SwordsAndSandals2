using System;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;

namespace SwordsAndSandals
{
    [Serializable]
    public class Armor : IData
    {
        [JsonIgnore] public CategoryEnum Category;
        public int ID;
        int IData.ID { get => ID; set => ID = value; }
        [JsonIgnore] public string Name { get; set; }
        [JsonIgnore] public int Cost { get; set; }
        [JsonIgnore] public int Defence;
        [JsonIgnore] public int RequiredLevel;
        [JsonIgnore] public float CellScale { get; set; }
        [JsonIgnore] public Price Price { get; set; }

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

