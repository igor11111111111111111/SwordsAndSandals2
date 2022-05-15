using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace SwordsAndSandals
{
    [Serializable]
    public class Armor
    {
        [JsonIgnore]
        public const int COUNT = 10; // PlayerLibraryAsset Category List Count
        public string Category => GetType().Name;
        public int Level;
        [JsonIgnore]  
        public int Defence => _levelDefence[Level];
        [JsonIgnore]
        protected int[] _levelDefence;
        [JsonIgnore]
        public int RequiredGladiatorLevel => _requiredGladiatorLevel[Level];
        [JsonIgnore]
        private int[] _requiredGladiatorLevel;
        [JsonIgnore]
        public int Cost => _cost[Level];
        [JsonIgnore]
        protected int[] _cost;
        [JsonIgnore]
        public string Name => _name[Level];
        [JsonIgnore]
        protected string[] _name;
        [JsonIgnore]
        public float CellScale => _cellScale;
        [JsonIgnore]
        protected float _cellScale;
        [JsonIgnore]
        public Sprite Sprite;

        public Armor()
        {
            Level = 0;

            _requiredGladiatorLevel = new int[COUNT]
            {
                0,
                1,
                4,
                8,
                12,
                16,
                20,
                25,  
                30,
                35
            };
        }


        public Armor Clone(int level, Sprite sprite)
        {
            var armor = (Armor)MemberwiseClone();
            armor.Level = level;
            armor.Sprite = sprite;
            return armor;
        }
    }

    public class Helmet : Armor
    {
        public Helmet()
        {
            _cellScale = 2;

            _levelDefence = new int[COUNT]
            {
                0,
                15,
                30,
                45,
                60,
                75,
                90,
                105,
                120,
                135
            };

            _cost = new int[COUNT]
            {
                0,
                1,
                2,
                3,
                4,
                5,
                6,
                7,
                8,
                9
            };

            _name = new string[COUNT]
            {
                "0",
                "1",
                "2",
                "3",
                "4",
                "5",
                "6",
                "7",
                "8",
                "9"
            };
        }
    }

    public class Cuirass : Armor
    {
        public Cuirass()
        {
            _cellScale = 2;

            //_levelDefence = new int[COUNT]
            //{
            //    0,
            //    30,
            //    60,
            //    45,
            //    60,
            //    75,
            //    90,
            //    105,
            //    120,
            //    135
            //};
        }
    }

    public class Shorts : Armor
    {
        public Shorts()
        {
            _cellScale = 2;
            //LevelDefence.Add(10);
            //LevelDefence.Add(15);
        }
    }

    public class LeftFoot : Armor
    {
        public LeftFoot()
        {
            _cellScale = 3;
            //LevelDefence.Add(5);
            //LevelDefence.Add(10);
        }
    }

    public class RightFoot : Armor
    {
        public RightFoot()
        {
            _cellScale = 3;
            //LevelDefence.Add(5);
            //LevelDefence.Add(10);
        }
    }

    public class LeftGaiter : Armor
    {
        public LeftGaiter()
        {
            _cellScale = 3;
            //LevelDefence.Add(5);
            //LevelDefence.Add(10);
        }
    }

    public class RightGaiter : Armor
    {
        public RightGaiter()
        {
            _cellScale = 3;
            //LevelDefence.Add(5);
            //LevelDefence.Add(10);
        }
    }

    public class LeftLeggins : Armor
    {
        public LeftLeggins()
        {
            _cellScale = 3;
            //LevelDefence.Add(5);
            //LevelDefence.Add(10);
        }
    }

    public class RightLeggins : Armor
    {
        public RightLeggins()
        {
            _cellScale = 3;
            //LevelDefence.Add(5);
            //LevelDefence.Add(10);
        }
    }

    public class LeftMitten : Armor
    {
        public LeftMitten()
        {
            _cellScale = 3;
            //LevelDefence.Add(5);
            //LevelDefence.Add(10);
        }
    }

    public class RightMitten : Armor
    {
        public RightMitten()
        {
            _cellScale = 3;
            //LevelDefence.Add(5);
            //LevelDefence.Add(10);
        }
    }

    public class LeftPauldron : Armor
    {
        public LeftPauldron()
        {
            _cellScale = 3;
            //LevelDefence.Add(5);
            //LevelDefence.Add(10);
        }
    }

    public class RightPauldron : Armor
    {
        public RightPauldron()
        {
            _cellScale = 3;
            //LevelDefence.Add(5);
            //LevelDefence.Add(10);
        }
    }

    public class Shield : Armor
    {
        public Shield()
        {
            _cellScale = 2;
            //LevelDefence.Add(5);
            //LevelDefence.Add(10);
        }
    }
}

