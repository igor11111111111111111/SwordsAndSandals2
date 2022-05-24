using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace SwordsAndSandals
{
    [Serializable]
    public class Weapon
    {
        public CategoryEnum Category;
        public int ID;
        public string Name;
        public int Cost;
        public int Damage;
        public int Damage2;
        public int RequiredStrength;
        public float CellScale;

        public enum CategoryEnum
        {
            Bashing,
            Hacking
        }

        public Weapon()
        {
            Category = CategoryEnum.Bashing;
            ID = 0;
            Damage = 5;
        }

        public Weapon(CategoryEnum category, int id)
        {
            Category = category;
            ID = id;
        }
         
        public Weapon(CategoryEnum category, int id, string name, int cost, int damage, int damage2, int requiredStrength, float cellScale)
        {
            Category = category;
            ID = id;
            Name = name;
            Cost = cost;
            Damage = damage;
            Damage2 = damage2;
            RequiredStrength = requiredStrength;
            CellScale = cellScale;
        }
    }
}

