using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
 
namespace SwordsAndSandals
{
    [Serializable]
    public class PlayerDataSkills
    {
        [NonSerialized]
        public Action<int> OnUnallocatedPointsChanged;

        public int UnallocatedPoints;

        public Skill[] Array;

        public PlayerDataSkills()
        {
            Array = new Skill[]
            {
                new Strength(),
                new Agility(),
                new Attack(),
                new Defence(),
                new Vitality(),
                new Charisma(),
                new Stamina(),
                new Magicka()
            };
            //Array.Find(Skills, s => s is Agility);
            UnallocatedPoints = 9;

            OnUnallocatedPointsChanged += ChangePoints;
        }

        ~ PlayerDataSkills()
        {
            OnUnallocatedPointsChanged -= ChangePoints;
        }

        public T Get<T>() where T : Skill
        {
            return (T)System.Array.Find(Array, t => t is T);
        }

        private void ChangePoints(int delta)
        {
            UnallocatedPoints += delta;
        }
    }
}
