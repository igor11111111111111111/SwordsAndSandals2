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

            Hacking();
            Bashing();
        }

        public void Hacking()
        {
            _weapons.Add(
            new Weapon
            (
                Weapon.CategoryEnum.Hacking,
                1,
                "Cleaver",
                2274,
                4,
                16,
                3,
                2.5f
            ));

            _weapons.Add(
            new Weapon
            (
                Weapon.CategoryEnum.Hacking,
                2,
                "Hand axe",
                2841,
                5,
                20,
                6,
                2.3f
            ));

            _weapons.Add(
            new Weapon
            (
                Weapon.CategoryEnum.Hacking,
                3,
                "Bronze axe",
                3408,
                6,
                24,
                9,
                2
            ));

            _weapons.Add(
            new Weapon
            (
                Weapon.CategoryEnum.Hacking,
                4,
                "Hatchet",
                4542,
                8,
                32,
                12,
                2.4f
            ));

            _weapons.Add(
            new Weapon
            (
                Weapon.CategoryEnum.Hacking,
                5,
                "Warrior axe",
                5676,
                10,
                40,
                15,
                1.8f
            ));

            _weapons.Add(
            new Weapon
            (
                Weapon.CategoryEnum.Hacking,
                6,
                "Berserker axe",
                8511,
                15,
                60,
                18,
                1.5f
            ));

            _weapons.Add(
            new Weapon
            (
                Weapon.CategoryEnum.Hacking,
                7,
                "Greensteel axe",
                10212,
                18,
                72,
                21,
                1.3f
            ));
        }

        public void Bashing()
        {
            _weapons.Add(
            new Weapon
            (
                Weapon.CategoryEnum.Bashing,
                1,
                "Blackjack",
                1714,
                4,
                12,
                3,
                2
            ));

            _weapons.Add(
            new Weapon
            (
                Weapon.CategoryEnum.Bashing,
                2,
                "Hammer",
                2142,
                5,
                15,
                6,
                2
            ));

            _weapons.Add(
            new Weapon
            (
                Weapon.CategoryEnum.Bashing,
                3,
                "Knuckle Duster",
                3424,
                8,
                24,
                9,
                2
            ));

            _weapons.Add(
            new Weapon
            (
                Weapon.CategoryEnum.Bashing,
                4,
                "Wooden club",
                4279,
                10,
                30,
                12,
                1.7f
            ));

            _weapons.Add(
            new Weapon
            (
                Weapon.CategoryEnum.Bashing,
                5,
                "Iron Mace",
                6417,
                15,
                45,
                15,
                1.4f
            ));

            _weapons.Add(
            new Weapon
            (
                Weapon.CategoryEnum.Bashing,
                6,
                "Steel Mace",
                8554,
                20,
                60,
                18,
                1.4f
            ));

            _weapons.Add(
            new Weapon
            (
                Weapon.CategoryEnum.Bashing,
                7,
                "Spiked Mace",
                10692,
                25,
                75,
                21,
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

