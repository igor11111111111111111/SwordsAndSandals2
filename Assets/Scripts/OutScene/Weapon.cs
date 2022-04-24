using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace SwordsAndSandals
{
    [Serializable]
    public class Weapon
    {
        public String Name => GetType().Name;
        public int Level;
        public int Damage => LevelDamage[Level];
        [JsonIgnore]
        public Dictionary<int, int> LevelDamage;

        public Weapon()
        {
            Level = 0;
            LevelDamage = new Dictionary<int, int>();
            LevelDamage.Add(0, 10);
        }
    }

    public class Sword : Weapon
    {
        public Sword()
        {
            LevelDamage.Add(1, 20);
            LevelDamage.Add(2, 30);
        }
    }
}

