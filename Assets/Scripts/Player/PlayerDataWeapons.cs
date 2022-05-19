using Newtonsoft.Json;
using System;

namespace SwordsAndSandals
{
    [Serializable]
    public class PlayerDataWeapons
    {
        public Weapon Current;

        public PlayerDataWeapons()
        {
            Current = new Weapon();
        }

        public void Set()
        {
            Current = new AllWeaponData().Get(Weapon.CategoryEnum.Bashing, 3);
        }

        public void Set(Weapon newWeapon)
        {
            Current = newWeapon;
        }
    }
}

