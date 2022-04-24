using Newtonsoft.Json;
using System;

namespace SwordsAndSandals
{
    [Serializable]
    public class PlayerDataWeapons
    {
        public Weapon[] Array;
        [JsonIgnore]
        public Weapon Current;

        public PlayerDataWeapons()
        {
            Array = new Weapon[]
            {
                new Sword()
            };

            Current = Array[0];
        }

        public int GetAttack()
        {
            return Current.Damage;
        } 

        public void SetRandom()
        {
            var weapon = new Sword();
            weapon.Level = UnityEngine.Random.Range(0, 2);
            Current = weapon;
        }
    }
}

