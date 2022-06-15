using UnityEngine;

namespace SwordsAndSandals.Arena
{
    public class RegenerationLogic
    {
         public RegenerationLogic(IUseController controller, PlayerData arenaPlayerData)
        {
            controller.OnStartAction += (state) =>
            {
                if(state == Enums.CurrentState.Sleep)
                {
                    arenaPlayerData.HealthData.Current += 2;
                }
            };
        }
    }
} 
