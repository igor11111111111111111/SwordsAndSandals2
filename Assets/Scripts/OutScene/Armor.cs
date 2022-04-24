using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SwordsAndSandals
{
    [Serializable]
    public class Armor
    {   
        public String Name => GetType().Name;
        public int Level;
        public int Defence => LevelDefence[Level];
        [JsonIgnore]
        public Dictionary<int, int> LevelDefence;

        public Armor()
        {
            Level = 0;
            LevelDefence = new Dictionary<int, int>();
            LevelDefence.Add(0, 0);
        }
    }

    public class Helmet : Armor
    {
        public Helmet()
        {
            LevelDefence.Add(1, 15);
            LevelDefence.Add(2, 30);
        }
    }

    public class Cuirass : Armor
    {
        public Cuirass()
        {
            LevelDefence.Add(1, 30);
            LevelDefence.Add(2, 60);
        }
    }

    public class Shorts : Armor
    {
        public Shorts()
        {
            LevelDefence.Add(1, 10);
            LevelDefence.Add(2, 15);
        }
    }

    public class LeftFoot : Armor
    {
        public LeftFoot()
        {
            LevelDefence.Add(1, 5);
            LevelDefence.Add(2, 10);
        }
    }

    public class RightFoot : Armor
    {
        public RightFoot()
        {
            LevelDefence.Add(1, 5);
            LevelDefence.Add(2, 10);
        }
    }

    public class LeftGaiter : Armor
    {
        public LeftGaiter()
        {
            LevelDefence.Add(1, 5);
            LevelDefence.Add(2, 10);
        }
    }

    public class RightGaiter : Armor
    {
        public RightGaiter()
        {
            LevelDefence.Add(1, 5);
            LevelDefence.Add(2, 10);
        }
    }

    public class LeftLeggins : Armor
    {
        public LeftLeggins()
        {
            LevelDefence.Add(1, 5);
            LevelDefence.Add(2, 10);
        }
    }

    public class RightLeggins : Armor
    {
        public RightLeggins()
        {
            LevelDefence.Add(1, 5);
            LevelDefence.Add(2, 10);
        }
    }

    public class LeftMitten : Armor
    {
        public LeftMitten()
        {
            LevelDefence.Add(1, 5);
            LevelDefence.Add(2, 10);
        }
    }

    public class RightMitten : Armor
    {
        public RightMitten()
        {
            LevelDefence.Add(1, 5);
            LevelDefence.Add(2, 10);
        }
    }

    public class LeftPauldron : Armor
    {
        public LeftPauldron()
        {
            LevelDefence.Add(1, 5);
            LevelDefence.Add(2, 10);
        }
    }

    public class RightPauldron : Armor
    {
        public RightPauldron()
        {
            LevelDefence.Add(1, 5);
            LevelDefence.Add(2, 10);
        }
    }

    public class Shield : Armor
    {
        public Shield()
        {
            LevelDefence.Add(1, 5);
            LevelDefence.Add(2, 10);
        }
    }
}

