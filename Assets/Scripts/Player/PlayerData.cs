using CustomJson;
using Newtonsoft.Json;
using System;
using UnityEngine;

namespace SwordsAndSandals
{
    [Serializable] 
    public class PlayerData : IUtilitySaveData
    {
        public string Name;
        [JsonIgnore]
        public const float MOVE_DISTANCE = 1f;
        [JsonIgnore]
        public const float JUMP_FORCE = 2f;
        public float Money;
        [JsonIgnore]
        public bool InBattle = false;
        public SerializedColor SkinColor;
        public PlayerDataExperience DataLevel;
        public PlayerDataSkills DataSkills;
        public PlayerDataArmors DataArmors;
        public PlayerDataWeapons DataWeapons;
        [JsonIgnore]
        public Enums.Team Team;
        [JsonIgnore] 
        public Reward Reward;

        public PlayerData()
        {
            SkinColor = new SerializedColor();
            DataLevel = new PlayerDataExperience();
            DataSkills = new PlayerDataSkills();
            DataArmors = new PlayerDataArmors();
            DataWeapons = new PlayerDataWeapons();
            Team = Enums.Team.Player;
        }
         
        public PlayerData(string name, SerializedColor skinColor, PlayerDataExperience dataLevel, PlayerDataSkills dataSkills, Reward reward, PlayerDataArmors dataArmors, PlayerDataWeapons dataWeapons)
        {
            Name = name;
            SkinColor = skinColor;
            DataLevel = dataLevel;
            DataSkills = dataSkills;
            DataArmors = dataArmors;
            DataWeapons = dataWeapons;
            Reward = reward;
            Team = Enums.Team.AI;
        }

        public void Set(IData data)// fix
        {
            if(data is Armor)
            {
                DataArmors.Set(data as Armor);
            }
            else if(data is Weapon)
            {
                DataWeapons.Set(data as Weapon);
            }
        }//
    }
}
