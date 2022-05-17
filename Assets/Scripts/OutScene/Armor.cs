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
        [JsonIgnore] public string SpritesPath => "Armor/" + Category.ToString();
        public string Name;
        public int Cost;
        public int Defence;
        public int RequiredLevel;
        public float CellScale;

        public enum CategoryEnum
        {
            Helmet,
            Cuirass,
            Short,
            LeftBoot,
            RightBoot,
            LeftGaiter,
            RightGaiter,
            LeftLeggin,
            RightLeggin,
            LeftMitten, 
            RightMitten,
            LeftPauldron,
            RightPauldron,
            Shield
        }

        public Armor(CategoryEnum category)
        {
            Category = category;
            ID = 0;
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

        public Armor Clone()
        {
            return (Armor)MemberwiseClone();
        }

        public void Change(int newID, ArmorInit armorInit)
        {
            var armor = armorInit.Armors.Where(a => a.Category == Category && a.ID == newID).FirstOrDefault();

            ID = armor.ID;
            Category = armor.Category;
            Name = armor.Name;
            Cost = armor.Cost;
            Defence = armor.Defence;
            RequiredLevel = armor.RequiredLevel;
            CellScale = armor.CellScale;
        }
    }
}

