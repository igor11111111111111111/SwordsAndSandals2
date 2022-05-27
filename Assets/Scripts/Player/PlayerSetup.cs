using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwordsAndSandals
{
    public class PlayerSetup
    {
        public PlayerSetup(PlayerData data, PlayerPaintableParts paintableParts, ClothChanger clothChanger)
        {
            if(data.Team == Enums.Team.AI)
            {
                // init defence
                var allArmorData = new AllArmorData();
                for (int i = 0; i < data.DataArmors.Array.Length; i++)
                {
                    data.DataArmors.Set(allArmorData, i);
                }
                //

                // init damage
                var allWeaponData = new AllWeaponData();
                data.DataWeapons.Set(allWeaponData);
                //
            }

            paintableParts.Colorize(data.SkinColor);
            clothChanger.SetAll();
        }
    }
}
