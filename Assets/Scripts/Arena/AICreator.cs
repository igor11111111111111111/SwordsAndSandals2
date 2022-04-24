using SwordsAndSandals.OutScene;
using UnityEngine;

namespace SwordsAndSandals.Arena
{
    public class AICreator
    { 
        public static SwordsAndSandals.PlayerData GetRandom()
        {
            var aiData = new SwordsAndSandals.PlayerData();

            aiData.SkinColor = new ColorRandomizer().Get();
            aiData.Name = new PlayerNames().GetRandomFullName();

            var rand = Random.Range(0, 2);
            if(rand == 0)
            {
                aiData.DataWeapons.SetRandom();
                aiData.DataArmors.SetFull(1);
            }
            else
            {
                var weapon = new Sword();
                weapon.Level = 1;
                aiData.DataWeapons.Current = weapon;
                aiData.DataArmors.SetRandom();
            }

            return aiData;
        }
    }
}
