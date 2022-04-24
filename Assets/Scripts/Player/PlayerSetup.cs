using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwordsAndSandals
{
    public class PlayerSetup
    {
        public PlayerSetup(PlayerData data, PlayerPaintableParts paintableParts, ClothChanger clothChanger)
        {
            paintableParts.Colorize(data.SkinColor);
            clothChanger.SetAll(data);
        }
    }
}
