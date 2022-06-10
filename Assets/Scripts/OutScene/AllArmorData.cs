using System.Collections.Generic;
using System.Linq;

namespace SwordsAndSandals
{
    public class AllArmorData
    {
        private List<Armor> _armors;

        public AllArmorData()
        {
            _armors = new List<Armor>();

            Helmet();
            Cuirass();
            Shield();
            Short();
            Pauldron();
            Mitten();
            Gaiter();
            Leggins();
            Boot();
        }

        private void Helmet()
        {
            var category = Armor.CategoryEnum.Helmet;

            _armors.Add(
            new Armor
            (
                // 3% crit hit protection
                1,
                category,
                "Peasant",
                1200,
                20,
                1,
                2
            ));

            _armors.Add(new Armor
            (
                // 5% crit hit protection
                2,
                category,
                "Cutpurse",
                2700,
                30,
                1,
                2
            ));

            _armors.Add(new Armor
            (
                // 6% crit hit protection
                3,
                category,
                "Brigand",
                4800,
                40,
                1,
                2
            ));

            _armors.Add(new Armor
            (
                // 8% crit hit protection
                4,
                category,
                "Militia",
                7500,
                50,
                6,
                2
            ));

            _armors.Add(new Armor
            (
                // 9% crit hit protection
                5,
                category,
                "Veteran",
                10800,
                60,
                6,
                2
            ));

            _armors.Add(new Armor
            (
                // 11% crit hit protection
                6,
                category,
                "Hoplite",
                14700,
                70,
                12,
                2
            ));

            _armors.Add(new Armor
            (
                // 12% crit hit protection
                7,
                category,
                "Swashbuckler",
                19200,
                80,
                12,
                2
            ));

            _armors.Add(new Armor
            (
                // 14% crit hit protection
                8,
                category,
                "Retarius",
                24300,
                90,
                12,
                2
            ));

            _armors.Add(new Armor
            (
                // 15% crit hit protection
                9,
                category,
                "Myrmidon",
                30000,
                100,
                18,
                2
            ));
        }

        private void Cuirass()
        {
            var category = Armor.CategoryEnum.Cuirass;

            // % of damage taken converted to energy
            _armors.Add(new Armor
            (
                // 2
                1,
                category,
                "Peasant",
                3072,
                32,
                1,
                2
            ));

            _armors.Add(new Armor
            (
                // 3
                2,
                category,
                "Cutpurse",
                6912,
                48,
                1,
                2
            ));

            _armors.Add(new Armor
            (
                // 4
                3,
                category,
                "Brigand",
                12288,
                64,
                1,
                2
            ));

            _armors.Add(new Armor
            (
                // 5
                4,
                category,
                "Militia",
                19200,
                80,
                6,
                2
            ));

            _armors.Add(new Armor
            (
                // 6
                5,
                category,
                "Veteran",
                27648,
                96,
                6,
                2
            ));

            _armors.Add(new Armor
            (
                // 7
                6,
                category,
                "Hoplite",
                37632,
                112,
                12,
                2
            ));

            _armors.Add(new Armor
            (
                // 8
                7,
                category,
                "Swashbuckler",
                49152,
                128,
                12,
                2
            ));

            _armors.Add(new Armor
            (
                // 9
                8,
                category,
                "Retarius",
                62208,
                144,
                12,
                2
            ));

            _armors.Add(new Armor
            (
                // 10
                9,
                category,
                "Myrmidon",
                76800,
                160,
                18,
                2
            ));
        }

        private void Shield()
        {
            var category = Armor.CategoryEnum.Shield;

            // change to deflect missile weapons
            _armors.Add(new Armor
            (
                // 3
                1,
                category,
                "Peasant",
                1728,
                24,
                1,
                2
            ));

            _armors.Add(new Armor
            (
                // 5
                2,
                category,
                "Cutpurse",
                3888,
                36,
                1,
                2
            ));

            _armors.Add(new Armor
            (
                // 6
                3,
                category,
                "Brigand",
                6912,
                48,
                1,
                2
            ));

            _armors.Add(new Armor
            (
                // 8
                4,
                category,
                "Militia",
                10800,
                60,
                6,
                2
            ));

            _armors.Add(new Armor
            (
                // 9
                5,
                category,
                "Veteran",
                15552,
                72,
                6,
                2
            ));

            _armors.Add(new Armor
            (
                // 11
                6,
                category,
                "Hoplite",
                21168,
                84,
                12,
                2
            ));

            _armors.Add(new Armor
            (
                // 12
                7,
                category,
                "Swashbuckler",
                27648,
                96,
                12,
                2
            ));

            _armors.Add(new Armor
            (
                // 14
                8,
                category,
                "Retarius",
                34992,
                108,
                12,
                2
            ));

            _armors.Add(new Armor
            (
                // 15
                9,
                category,
                "Myrmidon",
                43200,
                120,
                18,
                2
            ));
        }

        private void Short() 
        {
            var category = Armor.CategoryEnum.Short;

            // change to deflect missile weapons
            _armors.Add(new Armor
            (
                // 3
                1,
                category,
                "Peasant",
                728,
                12,
                1,
                2
            ));

            _armors.Add(new Armor
            (
                // 5
                2,
                category,
                "Cutpurse",
                1888,
                18,
                1,
                2
            ));

            _armors.Add(new Armor
            (
                // 6
                3,
                category,
                "Brigand",
                3500,
                24,
                1,
                2
            ));

            _armors.Add(new Armor
            (
                // 8
                4,
                category,
                "Militia",
                5400,
                30,
                6,
                2
            ));

            _armors.Add(new Armor
            (
                // 9
                5,
                category,
                "Veteran",
                8000,
                35,
                6,
                2
            ));

            _armors.Add(new Armor
            (
                // 11
                6,
                category,
                "Hoplite",
                11000,
                42,
                12,
                2
            ));

            _armors.Add(new Armor
            (
                // 12
                7,
                category,
                "Swashbuckler",
                14000,
                48,
                12,
                2
            ));

            _armors.Add(new Armor
            (
                // 14
                8,
                category,
                "Retarius",
                17000,
                54,
                12,
                2
            ));

            _armors.Add(new Armor
            (
                // 15
                9,
                category,
                "Myrmidon",
                21000,
                60,
                18,
                2
            ));
        }

        private void Pauldron()
        {
            var category = Armor.CategoryEnum.Pauldron;

            // extra charge distance
            _armors.Add(new Armor
            (
                // 4
                1,
                category,
                "Peasant",
                768,
                16,
                1,
                3
            ));

            _armors.Add(new Armor
            (
                // 6
                2,
                category,
                "Cutpurse",
                1728,
                24,
                1,
                3
            ));

            _armors.Add(new Armor
            (
                // 8
                3,
                category,
                "Brigand",
                3072,
                32,
                1,
                3
            ));

            _armors.Add(new Armor
            (
                // 10
                4,
                category,
                "Militia",
                4800,
                40,
                6,
                3
            ));

            _armors.Add(new Armor
            (
                // 12
                5,
                category,
                "Veteran",
                6912,
                48,
                6,
                3
            ));

            _armors.Add(new Armor
            (
                // 14
                6,
                category,
                "Hoplite",
                9408,
                56,
                12,
                3
            ));

            _armors.Add(new Armor
            (
                // 16
                7,
                category,
                "Swashbuckler",
                12288,
                64,
                12,
                3
            ));

            _armors.Add(new Armor
            (
                // 18
                8,
                category,
                "Retarius",
                15552,
                72,
                12,
                3
            ));

            _armors.Add(new Armor
            (
                // 18
                9,
                category,
                "Myrmidon",
                19200,
                80,
                18,
                3
            ));
        }

        private void Mitten()
        {
            var category = Armor.CategoryEnum.Mitten;
            // extra shove distance
            _armors.Add(new Armor
            (
                // 4
                1,
                category,
                "Peasant",
                300,
                10,
                1,
                3
            ));

            _armors.Add(new Armor
            (
                // 6
                2,
                category,
                "Cutpurse",
                675,
                15,
                1,
                3
            ));

            _armors.Add(new Armor
            (
                // 8
                3,
                category,
                "Brigand",
                1200,
                20,
                1,
                3
            ));

            _armors.Add(new Armor
            (
                // 10
                4,
                category,
                "Militia",
                1875,
                25,
                6,
                3
            ));

            _armors.Add(new Armor
            (
                // 12
                5,
                category,
                "Veteran",
                2700,
                30,
                6,
                3
            ));

            _armors.Add(new Armor
            (
                // 14
                6,
                category,
                "Hoplite",
                3675,
                35,
                12,
                3
            ));

            _armors.Add(new Armor
            (
                // 16
                7,
                category,
                "Swashbuckler",
                4800,
                40,
                12,
                3
            ));

            _armors.Add(new Armor
            (
                // 18
                8,
                category,
                "Retarius",
                6075,
                45,
                12,
                3
            ));

            _armors.Add(new Armor
            (
                // 20
                9,
                category,
                "Retarius",
                7500,
                50,
                18,
                3
            ));
        }

        private void Gaiter()
        {
            var category = Armor.CategoryEnum.Gaiter;
            // critical hit protection
            _armors.Add(new Armor
            (
                // 2
                1,
                category,
                "Peasant",
                108,
                6,
                1,
                3
            ));

            _armors.Add(new Armor
            (
                // 3
                2,
                category,
                "Cutpurse",
                243,
                9,
                1,
                3
            ));

            _armors.Add(new Armor
            (
                // 4
                3,
                category,
                "Brigand",
                432,
                12,
                1,
                3
            ));

            _armors.Add(new Armor
            (
                // 5
                4,
                category,
                "Militia",
                675,
                15,
                6,
                3
            ));

            _armors.Add(new Armor
            (
                // 6
                5,
                category,
                "Veteran",
                972,
                18,
                6,
                3
            ));

            _armors.Add(new Armor
            (
                // 7
                6,
                category,
                "Hoplite",
                1323,
                21,
                12,
                3
            ));

            _armors.Add(new Armor
            (
                // 8
                7,
                category,
                "Swashbuckler",
                1728,
                24,
                12,
                3
            ));

            _armors.Add(new Armor
            (
                // 9
                8,
                category,
                "Retarius",
                2187,
                27,
                12,
                3
            ));

            _armors.Add(new Armor
            (
                // 10
                9,
                category,
                "Myrmidon",
                2700,
                30,
                18,
                3
            ));
        }

        private void Leggins()
        {
            var category = Armor.CategoryEnum.Leggin;
            // extra jumping distance
            _armors.Add(new Armor
            (
                // 4
                1,
                category,
                "Peasant",
                432,
                12,
                1,
                3
            ));

            _armors.Add(new Armor
            (
                // 6
                2,
                category,
                "Cutpurse",
                972,
                18,
                1,
                3
            ));

            _armors.Add(new Armor
            (
                // 8
                3,
                category,
                "Brigand",
                1728,
                24,
                1,
                3
            ));

            _armors.Add(new Armor
            (
                // 10
                4,
                category,
                "Militia",
                2700,
                30,
                6,
                3
            ));

            _armors.Add(new Armor
            (
                // 12
                5,
                category,
                "Veteran",
                3888,
                36,
                6,
                3
            ));

            _armors.Add(new Armor
            (
                // 14
                6,
                category,
                "Hoplite",
                5292,
                42,
                12,
                3
            ));

            _armors.Add(new Armor
            (
                // 16
                7,
                category,
                "Swashbuckler",
                6912,
                48,
                12,
                3
            ));

            _armors.Add(new Armor
            (
                // 18
                8,
                category,
                "Retarius",
                8748,
                54,
                12,
                3
            ));

            _armors.Add(new Armor
           (
               // 20
               9,
               category,
               "Myrmidon",
               10800,
               60,
               18,
               3
           ));
        }

        private void Boot()
        {
            var category = Armor.CategoryEnum.Boot;
            // extra movement speed
            _armors.Add(new Armor
            (
                // 4
                1,
                category,
                "Peasant",
                48,
                4,
                1,
                3
            ));

            _armors.Add(new Armor
            (
                // 6
                2,
                category,
                "Cutpurse",
                108,
                6,
                1,
                3
            ));

            _armors.Add(new Armor
            (
                // 8
                3,
                category,
                "Brigand",
                192,
                8,
                1,
                3
            ));

            _armors.Add(new Armor
            (
                // 10
                4,
                category,
                "Militia",
                300,
                10,
                6,
                3
            ));

            _armors.Add(new Armor
            (
                // 12
                5,
                category,
                "Veteran",
                432,
                12,
                6,
                3
            ));

            _armors.Add(new Armor
            (
                // 14
                6,
                category,
                "Hoplite",
                588,
                14,
                12,
                3
            ));

            _armors.Add(new Armor
            (
                // 16
                7,
                category,
                "Swashbuckler",
                768,
                16,
                12,
                3
            ));

            _armors.Add(new Armor
            (
                // 18
                8,
                category,
                "Retarius",
                972,
                18,
                12,
                3
            ));

            _armors.Add(new Armor
            (
                // 20
                9,
                category,
                "Myrmidon",
                1200,
                20,
                18,
                3
            ));
        }

        public List<Armor> Get(Armor.CategoryEnum category)
        {
            return _armors.Where(a => a.Category == category).ToList();
        }

        public Armor Get(Armor.CategoryEnum category, int id)
        {
            return _armors.Where(a => a.Category == category && a.ID == id).FirstOrDefault();
        }

        public Armor Get(Armor armor)
        {
            return _armors.Where(a => a.Category == armor.Category && a.ID == armor.ID).FirstOrDefault();
        }
    }
}

