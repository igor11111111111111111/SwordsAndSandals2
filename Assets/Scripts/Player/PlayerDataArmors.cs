using System;
using System.Linq;
using UnityEngine;

namespace SwordsAndSandals
{
    [Serializable]
    public class PlayerDataArmors
    {
        public Armor[] Array;
          
        public PlayerDataArmors()
        {
            Array = new Armor[]
            {
                new Armor(Armor.CategoryEnum.Helmet),
                new Armor(Armor.CategoryEnum.Cuirass),
                new Armor(Armor.CategoryEnum.Short),
                new Armor(Armor.CategoryEnum.Boot),
                new Armor(Armor.CategoryEnum.Gaiter),
                new Armor(Armor.CategoryEnum.Leggin),
                new Armor(Armor.CategoryEnum.Mitten),
                new Armor(Armor.CategoryEnum.Pauldron),
                new Armor(Armor.CategoryEnum.Shield),
            };
        }

        public Armor Get(Armor.CategoryEnum category)
        {
            return System.Array.Find(Array, t => t.Category == category);
        }

        public int GetDefence()
        {
            int value = 0;

            foreach (var armor in Array)
            {
                value += armor.Defence;
            }

            return value;
        }

        public void Set(Armor newArmor)
        {
            Armor armor = Array.Where(a => a.Category == newArmor.Category).FirstOrDefault();
            var index = System.Array.IndexOf(Array, armor);// fix later
            Array[index] = newArmor;//
        }

        public void SetFull(int id)
        {
            AllArmorData allArmorData = new AllArmorData();
            for (int i = 0; i < Array.Length; i++)
            {
                Array[i] = allArmorData.Get(Array[i].Category, id);
            }
        }
    }
}
