using System;
using System.Linq;
using UnityEngine;

namespace SwordsAndSandals
{
    [Serializable]
    public class PlayerDataArmors : IPlayerData
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

        public PlayerDataArmors(int helmetId, int cuirassId, int shortsId, int bootId, int gaiterId, int legginId, int mittenId, int pauldronId, int shieldId)
        {
            Array = new Armor[]
            {
                new Armor(Armor.CategoryEnum.Helmet, helmetId),
                new Armor(Armor.CategoryEnum.Cuirass, cuirassId),
                new Armor(Armor.CategoryEnum.Short, shortsId),
                new Armor(Armor.CategoryEnum.Boot, bootId),
                new Armor(Armor.CategoryEnum.Gaiter, gaiterId),
                new Armor(Armor.CategoryEnum.Leggin, legginId),
                new Armor(Armor.CategoryEnum.Mitten, mittenId),
                new Armor(Armor.CategoryEnum.Pauldron, pauldronId),
                new Armor(Armor.CategoryEnum.Shield, shieldId),
            };
        }

        public Armor Get(Armor.CategoryEnum category)
        {
            return System.Array.Find(Array, t => t.Category == category);
        }

        public int GetDefence()
        { 
            int value = 0;
            var allArmor = new AllArmorData();

            foreach (var armor in Array)
            {
                var findedArmor = allArmor.Get(armor.Category, armor.ID);
                if(findedArmor != null)
                    value += findedArmor.Defence;
            }

            return value;
        }

        public void Set(Armor newArmor)
        {
            Armor armor = Array.Where(a => a.Category == newArmor.Category).FirstOrDefault();
            var index = System.Array.IndexOf(Array, armor);// fix later
            Array[index] = newArmor;//
        }

        public void Set(AllArmorData allArmorData, int index)
        {
            if (Array[index].ID > 0)
                Array[index] = allArmorData.Get(Array[index].Category, Array[index].ID);
        }
    }
}
