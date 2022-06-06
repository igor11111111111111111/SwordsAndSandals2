using UnityEngine;

namespace SwordsAndSandals.Shop
{ 
    public abstract class AbstractButtonsPanel : MonoBehaviour
    {
        public abstract GameObject Body { get;}
        public abstract void Init(PlayerData playerData, PriceHandler armorPriceHandler);
    } 
}