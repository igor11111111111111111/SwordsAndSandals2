using SwordsAndSandals.OutScene;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SwordsAndSandals.Arena
{
    public class AllEnemyData
    {
        private List<SwordsAndSandals.PlayerData> _list;

        public AllEnemyData()
        {
            var names = new PlayerNames();
            var colors = new ColorRandomizer();

            _list = new List<SwordsAndSandals.PlayerData>()
            {
                //0 - level
                new SwordsAndSandals.PlayerData
                   (
                        names.GetRandomFullName(),
                        colors.Get(),
                        new PlayerDataExperience(0),
                        new PlayerDataSkills(3, 1, 2, 2, 0, 0, 1, 0),
                        new Reward(1000, 2000),
                        new PlayerDataArmors(0, 0, 0, 0, 0, 0, 0, 0, 0),
                        new PlayerDataWeapons(Weapon.CategoryEnum.Bashing, 0)
                    ),
                //1
                new SwordsAndSandals.PlayerData
                   (
                        names.GetRandomFullName(),
                        colors.Get(),
                        new PlayerDataExperience(1),
                        new PlayerDataSkills(4, 2, 3, 3, 0, 0, 1, 0),
                        new Reward(500, 1000),
                        new PlayerDataArmors(0, 0, 1, 1, 0, 0, 1, 0, 0),
                        new PlayerDataWeapons(Weapon.CategoryEnum.Bashing, 0)
                    ),
                new SwordsAndSandals.PlayerData
                   (
                        names.GetRandomFullName(),
                        colors.Get(),
                        new PlayerDataExperience(1),
                        new PlayerDataSkills(4, 0, 4, 4, 0, 0, 1, 0),
                        new Reward(500, 1000),
                        new PlayerDataArmors(1, 0, 1, 0, 0, 0, 0, 0, 0),
                        new PlayerDataWeapons(Weapon.CategoryEnum.Bashing, 0)
                    ),
                new SwordsAndSandals.PlayerData
                   (
                        names.GetRandomFullName(),
                        colors.Get(),
                        new PlayerDataExperience(1),
                        new PlayerDataSkills(2, 0, 3, 3, 3, 1, 1, 0),
                        new Reward(500, 1000),
                        new PlayerDataArmors(1, 0, 1, 0, 0, 0, 0, 0, 0),
                        new PlayerDataWeapons(Weapon.CategoryEnum.Bashing, 0)
                    ),
                //2
                new SwordsAndSandals.PlayerData
                   (
                        names.GetRandomFullName(),
                        colors.Get(),
                        new PlayerDataExperience(2),
                        new PlayerDataSkills(5, 3, 3, 3, 1, 1, 1, 0),
                        new Reward(500, 1500),
                        new PlayerDataArmors(0, 1, 1, 0, 0, 1, 0, 1, 0),
                        new PlayerDataWeapons(Weapon.CategoryEnum.Bashing, 1)
                    ),
                new SwordsAndSandals.PlayerData
                   (
                        names.GetRandomFullName(),
                        colors.Get(),
                        new PlayerDataExperience(2),
                        new PlayerDataSkills(4, 2, 2, 4, 2, 1, 2, 0),
                        new Reward(500, 1500),
                        new PlayerDataArmors(1, 0, 1, 0, 0, 1, 0, 1, 1),
                        new PlayerDataWeapons(Weapon.CategoryEnum.Hacking, 1)
                    ),
                new SwordsAndSandals.PlayerData
                   (
                        names.GetRandomFullName(),
                        colors.Get(),
                        new PlayerDataExperience(2),
                        new PlayerDataSkills(4, 0, 2, 6, 2, 1, 2, 0),
                        new Reward(500, 1500),
                        new PlayerDataArmors(1, 1, 1, 0, 0, 0, 0, 0, 0),
                        new PlayerDataWeapons(Weapon.CategoryEnum.Hacking, 1)
                    ),
                new SwordsAndSandals.PlayerData
                   (
                        names.GetRandomFullName(),
                        colors.Get(),
                        new PlayerDataExperience(2),
                        new PlayerDataSkills(4, 0, 6, 2, 2, 0, 3, 0),
                        new Reward(500, 1500),
                        new PlayerDataArmors(1, 1, 0, 0, 0, 0, 0, 1, 1),
                        new PlayerDataWeapons(Weapon.CategoryEnum.Bashing, 1)
                    ),
                //3
                new SwordsAndSandals.PlayerData
                   (
                        names.GetRandomFullName(),
                        colors.Get(),
                        new PlayerDataExperience(3),
                        new PlayerDataSkills(8, 3, 4, 3, 1, 1, 1, 0),
                        new Reward(800, 1800),
                        new PlayerDataArmors(1, 1, 1, 1, 1, 1, 1, 1, 1),
                        new PlayerDataWeapons(Weapon.CategoryEnum.Bashing, 2)
                    ),
                new SwordsAndSandals.PlayerData
                   (
                        names.GetRandomFullName(),
                        colors.Get(),
                        new PlayerDataExperience(3),
                        new PlayerDataSkills(8, 3, 2, 2, 2, 2, 1, 0),
                        new Reward(800, 1800),
                        new PlayerDataArmors(2, 2, 1, 1, 1, 1, 1, 0, 0),
                        new PlayerDataWeapons(Weapon.CategoryEnum.Hacking, 2)
                    ),
                //4 
                new SwordsAndSandals.PlayerData
                (
                    names.GetRandomFullName(),
                    colors.Get(),
                    new PlayerDataExperience(4),
                    new PlayerDataSkills(8, 3, 4, 3, 1, 1, 1, 0),
                    new Reward(800, 1800),
                    new PlayerDataArmors(1, 1, 1, 1, 1, 1, 1, 1, 1),
                    new PlayerDataWeapons(Weapon.CategoryEnum.Bashing, 2)
                ),
                //5 
                new SwordsAndSandals.PlayerData
                (
                    names.GetRandomFullName(),
                    colors.Get(),
                    new PlayerDataExperience(5),
                    new PlayerDataSkills(8, 3, 4, 3, 1, 1, 1, 0),
                    new Reward(800, 1800),
                    new PlayerDataArmors(1, 1, 1, 1, 1, 1, 1, 1, 1),
                    new PlayerDataWeapons(Weapon.CategoryEnum.Bashing, 2)
                ),
                //6
                new SwordsAndSandals.PlayerData
                (
                    names.GetRandomFullName(),
                    colors.Get(),
                    new PlayerDataExperience(6),
                    new PlayerDataSkills(8, 3, 4, 3, 1, 1, 1, 0),
                    new Reward(800, 1800),
                    new PlayerDataArmors(1, 1, 1, 1, 1, 1, 1, 1, 1),
                    new PlayerDataWeapons(Weapon.CategoryEnum.Bashing, 2)
                ),
            };
        }

        public SwordsAndSandals.PlayerData Get(int playerLevel)
        {
            var equalLevels = _list.Where((e) => e.DataLevel.Level == playerLevel).ToArray();
            var player = equalLevels[Random.Range(0, equalLevels.Count())];
            //_list.Remove(player); // для отключения повтора врагов надо внести в save data инфу о побежденных врагах

            return player;
        }
    }
}
