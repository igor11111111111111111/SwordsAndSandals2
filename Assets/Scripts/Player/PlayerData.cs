﻿using CustomJson;
using Newtonsoft.Json;
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
    }
}
