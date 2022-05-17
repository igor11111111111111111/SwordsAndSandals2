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
            aiData.Reward = new Reward(500, 1000);

            aiData.DataWeapons.SetRandom();
            aiData.DataArmors.SetFull(3);

            return aiData;
        }
    }
}
