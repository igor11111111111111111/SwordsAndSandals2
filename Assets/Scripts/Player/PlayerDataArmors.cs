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
                new Armor(Armor.CategoryEnum.LeftBoot),
                new Armor(Armor.CategoryEnum.RightBoot),
                new Armor(Armor.CategoryEnum.LeftGaiter),
                new Armor(Armor.CategoryEnum.RightGaiter),
                new Armor(Armor.CategoryEnum.LeftLeggin),
                new Armor(Armor.CategoryEnum.RightLeggin),
                new Armor(Armor.CategoryEnum.LeftMitten),
                new Armor(Armor.CategoryEnum.RightMitten),
                new Armor(Armor.CategoryEnum.LeftPauldron),
                new Armor(Armor.CategoryEnum.RightPauldron),
                new Armor(Armor.CategoryEnum.Shield),
            };
        }

        //public T Get<T>() where T : Armor
        //{
        //    return (T)System.Array.Find(Array, t => t is T);
        //}

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
            ArmorInit armorInit = new ArmorInit();
            for (int i = 0; i < Array.Length; i++)
            {
                var newArmor = armorInit.Armors.Where(a => a.Category == Array[i].Category && a.ID == id).FirstOrDefault();
                Array[i] = newArmor;
            }
        }
    }
}
