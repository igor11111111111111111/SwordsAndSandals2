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

        public Skill(int value)
        {
            Value = value;
        }
    }

    public class Strength : Skill
    {
        private const float SIZE_PER_VALUE = 0.004f;
        private const float DAMAGE_PER_VALUE = 0.1f;

        [JsonIgnore]
        public float ScaleCoeff => SIZE_PER_VALUE * Value + 1;

        [JsonIgnore]
        public float DamageCoeff => DAMAGE_PER_VALUE * Value + 1;

        public Strength()
        {
        }

        public Strength(int value) : base(value)
        {
        }
    }
     
    public class Agility : Skill
    {
        private const float JUMPFORCE_PER_VALUE = 0.05f;
        private const float MOVEDISTANCE_PER_VALUE = 0.05f;

        [JsonIgnore]
        public float JumpCoeff => JUMPFORCE_PER_VALUE * Value + 1;
        [JsonIgnore]
        public float MoveDistanceCoeff => MOVEDISTANCE_PER_VALUE * Value + 1;

        public Agility()
        {
        }

        public Agility(int value) : base(value)
        {
        }
    }

    public class Attack : Skill
    {
        [JsonIgnore]
        public Dictionary<Enums.AttackType, int> BaseChance;
        [JsonIgnore]
        public Dictionary<Enums.AttackType, int> ValueChance;

        public Attack()
        {
            Init();
        }

        public Attack(int value) : base(value)
        {
            Init();
        }

        private void Init()
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
            Init();
        }

        public Defence(int value) : base(value)
        {
            Init();
        }

        private void Init()
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

        public int GetDefenceChance(Enums.AttackType attackType)
        {
            return BaseChance[attackType] + Value * ValueChance[attackType];
        }
    }

    public class Vitality : Skill
    {
        public Vitality()
        {
        }

        public Vitality(int value) : base(value)
        {
        }
    }

    public class Charisma : Skill
    {
        public Charisma()
        {
        }

        public Charisma(int value) : base(value)
        {
        }
    }

    public class Stamina : Skill
    {
        public Stamina()
        {
        }

        public Stamina(int value) : base(value)
        {
        }
    }

    public class Magicka : Skill
    {
        public Magicka()
        {
        }

        public Magicka(int value) : base(value)
        {
        }
    }
}
