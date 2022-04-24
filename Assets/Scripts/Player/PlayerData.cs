using CustomJson;
using System;
using UnityEngine;

namespace SwordsAndSandals
{
    [Serializable] 
    public class PlayerData : ISaveData
    {
        public string Name;
        public float MoveRange = 1f;
        public float JumpForce = 2f;
        public float Size = 1f;
        public float Money;
        public bool InBattle = false;
        public SerializedColor SkinColor;
        public PlayerDataExperience DataLevel;
        public PlayerDataSkills DataSkills;
        public PlayerDataArmors DataArmors;
        public PlayerDataWeapons DataWeapons;

        public PlayerData()
        {
            SkinColor = new SerializedColor();
            DataLevel = new PlayerDataExperience();
            DataSkills = new PlayerDataSkills();
            DataArmors = new PlayerDataArmors();
            DataWeapons = new PlayerDataWeapons();
        } 
    }
}
