using Newtonsoft.Json;
using System;
using static SwordsAndSandals.Weapon;

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

        public PlayerDataWeapons(CategoryEnum category, int id)
        {
            Current = new Weapon(category, id);
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

