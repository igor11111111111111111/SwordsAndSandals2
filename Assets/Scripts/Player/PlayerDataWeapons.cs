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

        public void Set(AllWeaponData allWeaponData)
        {
            if (Current.ID > 0)
            {
                Current = allWeaponData.Get(Current.Category, Current.ID);
            }
        }

        public void Set(Weapon newWeapon)
        {
            Current = newWeapon;
        }
    }
}

