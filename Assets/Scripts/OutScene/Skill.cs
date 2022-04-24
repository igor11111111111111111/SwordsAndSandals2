using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwordsAndSandals
{
    [Serializable]
    public class Skill
    {
        public String Name => GetType().Name;

        public int Value;

        public Skill()
        {
            Value = 1;
        }
    }

    public class Strength : Skill
    {
        private const float SIZE_PER_VALUE = 0.4f;
        public float ScaleCoeff => SIZE_PER_VALUE * Value * 0.01f + 1;
    }
     
    public class Agility : Skill
    {

    }

    public class Attack : Skill
    {
        [JsonIgnore]
        public Dictionary<Enums.AttackType, int> BaseChance;
        [JsonIgnore]
        public Dictionary<Enums.AttackType, int> ValueChance;

        public Attack()
        {
            BaseChance = new Dictionary<Enums.AttackType, int>();
            BaseChance.Add(Enums.AttackType.Charge, 32);
            BaseChance.Add(Enums.AttackType.WeakAttack, 66);
            BaseChance.Add(Enums.AttackType.MediumAttack, 50);
            BaseChance.Add(Enums.AttackType.HardAttack, 32);

            ValueChance = new Dictionary<Enums.AttackType, int>();
            ValueChance.Add(Enums.AttackType.Charge, 4);
            ValueChance.Add(Enums.AttackType.WeakAttack, 7);
            ValueChance.Add(Enums.AttackType.MediumAttack, 6);
            ValueChance.Add(Enums.AttackType.HardAttack, 4);
        }

        public int GetHitChance(Enums.AttackType attackType)
        {
            return BaseChance[attackType] + Value * ValueChance[attackType];
        }
    }

    public class Defence : Skill
    {
        [JsonIgnore]
        public Dictionary<Enums.AttackType, int> BaseChance;
        [JsonIgnore]
        public Dictionary<Enums.AttackType, int> ValueChance;

        public Defence()
        {
            BaseChance = new Dictionary<Enums.AttackType, int>();
            BaseChance.Add(Enums.AttackType.Charge, 0);
            BaseChance.Add(Enums.AttackType.WeakAttack, 0);
            BaseChance.Add(Enums.AttackType.MediumAttack, 0);
            BaseChance.Add(Enums.AttackType.HardAttack, 0);

            ValueChance = new Dictionary<Enums.AttackType, int>();
            ValueChance.Add(Enums.AttackType.Charge, 4);
            ValueChance.Add(Enums.AttackType.WeakAttack, 7);
            ValueChance.Add(Enums.AttackType.MediumAttack, 6);
            ValueChance.Add(Enums.AttackType.HardAttack, 4);
        }

        public int GetDodgeChance(Enums.AttackType attackType)
        {
            return BaseChance[attackType] + Value * ValueChance[attackType];
        }
    }

    public class Vitality : Skill
    {

    }

    public class Charisma : Skill
    {

    }

    public class Stamina : Skill
    {

    }

    public class Magicka : Skill
    {

    }
}
