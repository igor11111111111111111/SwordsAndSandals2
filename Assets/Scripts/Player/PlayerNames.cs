using System;
using System.Collections.Generic;
using UnityEngine;

namespace SwordsAndSandals.OutScene
{
    public class PlayerNames
    {
        private List<String> _name = new List<string>
        {
            "Boris",
            "Mortis",
            "Jonny",
            "Maxim",
            "Tormund",
            "Nici",
            "Tommy",
            "Armen",
            "Cirley",
            "Dmitry",
            "Evan",
            "Fomas",
            "Tomas",
            "Zepter",
            "Zlen",
            "Sven",
            "Sobr",
            "Bob",
            "Lemmy",
            "Gorge",
            "Panley",
            "Sadrik",
            "Omar"
        };

        private List<String> _nickname = new List<string>
        {
            "Blade",
            "One Finger",
            "Little Finger",
            "Halfbeard",
            "Halfling",
            "Semiarmed",
            "Cruel",
            "Jester",
            "AllElected",
            "Outcast",
            "Outlaw",
            "Crooked",
            "Wise",
            "Dump",
            "Weak",
            "Strong",
            "Little D",
            "Big B"
        };

        public string GetRandomFullName()
        {
            string fullName = null;
            int index;

            index = UnityEngine.Random.Range(0, _name.Count);
            fullName += _name[index];
            fullName += " ";
            index = UnityEngine.Random.Range(0, _nickname.Count);
            fullName += _nickname[index];
            return fullName;
        }
    }
}
