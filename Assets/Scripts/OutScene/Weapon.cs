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
        public int MinDamage; 
        public int MaxDamage;
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

