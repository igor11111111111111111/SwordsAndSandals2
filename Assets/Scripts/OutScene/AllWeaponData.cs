using System.Collections.Generic;
using System.Linq;

namespace SwordsAndSandals
{
    public class AllWeaponData
    {
        private List<Weapon> _weapons;

        public AllWeaponData()
        {
            _weapons = new List<Weapon>();

            _weapons.Add(
            new Weapon
            (
                Weapon.CategoryEnum.Hacking,
                1,
                "1",
                1 * 100,
                1 * 10,
                1,
                2.5f
            ));

            _weapons.Add(
            new Weapon
            (
                Weapon.CategoryEnum.Hacking,
                2,
                "1",
                1 * 100,
                1 * 10,
                1,
                2.3f
            ));

            _weapons.Add(
            new Weapon
            (
                Weapon.CategoryEnum.Hacking,
                3,
                "1",
                1 * 100,
                1 * 10,
                1,
                2
            ));

            _weapons.Add(
            new Weapon
            (
                Weapon.CategoryEnum.Hacking,
                4,
                "1",
                1 * 100,
                1 * 10,
                1,
                2.4f
            ));

            _weapons.Add(
            new Weapon
            (
                Weapon.CategoryEnum.Hacking,
                5,
                "1",
                1 * 100,
                1 * 10,
                1,
                1.8f
            ));

            _weapons.Add(
            new Weapon
            (
                Weapon.CategoryEnum.Hacking,
                6,
                "1",
                1 * 100,
                1 * 10,
                1,
                1.5f
            ));

            _weapons.Add(
            new Weapon
            (
                Weapon.CategoryEnum.Hacking,
                7,
                "1",
                1 * 100,
                1 * 10,
                1,
                1.3f
            ));

            _weapons.Add(
            new Weapon
            (
                Weapon.CategoryEnum.Bashing,
                1,
                "1",
                1 * 100,
                1 * 10,
                1,
                2
            ));

            _weapons.Add(
            new Weapon
            (
                Weapon.CategoryEnum.Bashing,
                2,
                "1",
                1 * 100,
                1 * 10,
                1,
                2
            ));

            _weapons.Add(
            new Weapon
            (
                Weapon.CategoryEnum.Bashing,
                3,
                "1",
                1 * 100,
                1 * 10,
                1,
                2
            ));

            _weapons.Add(
            new Weapon
            (
                Weapon.CategoryEnum.Bashing,
                4,
                "1",
                1 * 100,
                1 * 10,
                1,
                1.7f
            ));

            _weapons.Add(
            new Weapon
            (
                Weapon.CategoryEnum.Bashing,
                5,
                "1",
                1 * 100,
                1 * 10,
                1,
                1.4f
            ));

            _weapons.Add(
            new Weapon
            (
                Weapon.CategoryEnum.Bashing,
                6,
                "1",
                1 * 100,
                1 * 10,
                1,
                1.4f
            ));

            _weapons.Add(
            new Weapon
            (
                Weapon.CategoryEnum.Bashing,
                7,
                "1",
                1 * 100,
                1 * 10,
                1,
                1.4f
            ));
        }

        public List<Weapon> Get(Weapon.CategoryEnum category)
        {
            return _weapons.Where(a => a.Category == category).ToList();
        }

        public Weapon Get(Weapon.CategoryEnum category, int id)
        {
            return _weapons.Where(a => a.Category == category && a.ID == id).FirstOrDefault();
        }
    }
}

