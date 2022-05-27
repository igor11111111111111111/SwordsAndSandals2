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
        [NonSerialized]
        public const int POINTS_PER_LEVEL = 4;
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

            UnallocatedPoints = 9;

            OnUnallocatedPointsChanged += ChangePoints;
        }

        public PlayerDataSkills(int strength, int agility, int attack, int defence, int vitality, int charisma, int stamina, int magicka)
        {
            Array = new Skill[]
            {
                new Strength(strength),
                new Agility(agility),
                new Attack(attack),
                new Defence(defence),
                new Vitality(vitality),
                new Charisma(charisma),
                new Stamina(stamina),
                new Magicka(magicka)
            };
        }

        ~ PlayerDataSkills()
        {
            OnUnallocatedPointsChanged -= ChangePoints;
        }

        public T Get<T>() where T : Skill
        {
            return (T)System.Array.Find(Array, t => t is T);
        }

        public void AddPointsPerLevel()
        {
            UnallocatedPoints += POINTS_PER_LEVEL;
        }

        private void ChangePoints(int delta)
        {
            UnallocatedPoints += delta;
        }
    }
}
