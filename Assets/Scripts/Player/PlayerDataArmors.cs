using System;
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
                new Helmet(),
                new Cuirass(),
                new Shorts(),
                new LeftFoot(),
                new RightFoot(),
                new LeftGaiter(),
                new RightGaiter(),
                new LeftLeggins(),
                new RightLeggins(),
                new LeftMitten(),
                new RightMitten(),
                new LeftPauldron(),
                new RightPauldron(),
                new Shield()
            };
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

        public void SetRandom()
        {
            foreach (var armor in Array)
            {
                armor.Level = UnityEngine.Random.Range(0, 2);
            }
        }

        public void SetFull(int level)
        {
            foreach (var armor in Array)
            {
                armor.Level = level;
            }
        }
    }
}
