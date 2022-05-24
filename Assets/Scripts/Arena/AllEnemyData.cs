using SwordsAndSandals.OutScene;
using System.Collections.Generic;

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
                new SwordsAndSandals.PlayerData
                   (
                        names.GetRandomFullName(),
                        colors.Get(),
                        new PlayerDataExperience(0),
                        // randomize 9 skill betw all ~ magic
                        new PlayerDataSkills(0, 0, 0, 0, 0, 0, 0, 0),
                        new Reward(1000, 2000),
                        new PlayerDataArmors(0, 0, 0, 0, 0, 0, 0, 0, 0),
                        new PlayerDataWeapons(Weapon.CategoryEnum.Bashing, 0)
                    )
                //new SwordsAndSandals.PlayerData
                //   (
                //        names.GetRandomFullName(),
                //        colors.Get(),
                //        new PlayerDataExperience(0),
                //        new PlayerDataSkills(0, 0, 0, 0, 0, 0, 0, 0),
                //        new Reward(1000, 2000),
                //        new PlayerDataArmors(0, 0, 0, 0, 0, 0, 0, 0, 0),
                //        new PlayerDataWeapons(Weapon.CategoryEnum.Bashing, 0)
                //   )
            };
        }

        public SwordsAndSandals.PlayerData Get(int playerLevel)
        {
            // randomize betw Level = playerLevel
            return _list[0];
        }
    }
}
