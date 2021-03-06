using SwordsAndSandals.OutScene;
using System.Collections.Generic;

namespace SwordsAndSandals.Tournament
{
    public class AllTournamentData
    {
        public List<TournamentData> List => _list;
        private List<TournamentData> _list;

        public AllTournamentData()
        {
            var names = new PlayerNames();
            var colors = new ColorRandomizer();
            _list = new List<TournamentData>();

            _list.Add(
                new TournamentData
                (
                    "Noname tournament",
                    "Remember school years with city competitions, this is about the same level",
                    0,
                    "Yard",
                    new List<ParticipantData>
                    {
                        new ParticipantData
                        (
                            false,
                            names.GetRandomFullName(),
                            colors.Get(),
                            new PlayerDataExperience(3),
                            new PlayerDataSkills(8, 3, 2, 2, 2, 2, 1, 0),
                            new Reward(),
                            new PlayerDataArmors(2, 2, 1, 1, 1, 1, 1, 0, 0),
                            new PlayerDataWeapons(Weapon.CategoryEnum.Hacking, 2)
                        ),
                        new ParticipantData
                        (
                            false,
                            names.GetRandomFullName(),
                            colors.Get(),
                            new PlayerDataExperience(3),
                            new PlayerDataSkills(8, 3, 2, 2, 2, 2, 1, 0),
                            new Reward(),
                            new PlayerDataArmors(2, 2, 1, 1, 1, 1, 1, 0, 0),
                            new PlayerDataWeapons(Weapon.CategoryEnum.Hacking, 2)
                        ),
                        new ParticipantData
                        (
                            false,
                            names.GetRandomFullName(),
                            colors.Get(),
                            new PlayerDataExperience(3),
                            new PlayerDataSkills(8, 3, 2, 2, 2, 2, 1, 0),
                            new Reward(),
                            new PlayerDataArmors(2, 2, 1, 1, 1, 1, 1, 0, 0),
                            new PlayerDataWeapons(Weapon.CategoryEnum.Hacking, 2)
                        ),
                        new ParticipantData
                        (
                            false,
                            names.GetRandomFullName(),
                            colors.Get(),
                            new PlayerDataExperience(3),
                            new PlayerDataSkills(8, 3, 2, 2, 2, 2, 1, 0),
                            new Reward(),
                            new PlayerDataArmors(2, 2, 1, 1, 1, 1, 1, 0, 0),
                            new PlayerDataWeapons(Weapon.CategoryEnum.Hacking, 2)
                        ),
                        new ParticipantData
                        (
                            false,
                            names.GetRandomFullName(),
                            colors.Get(),
                            new PlayerDataExperience(3),
                            new PlayerDataSkills(8, 3, 2, 2, 2, 2, 1, 0),
                            new Reward(),
                            new PlayerDataArmors(2, 2, 1, 1, 1, 1, 1, 0, 0),
                            new PlayerDataWeapons(Weapon.CategoryEnum.Hacking, 2)
                        ),
                        new ParticipantData
                        (
                            true,
                            names.GetRandomFullName(),
                            colors.Get(),
                            new PlayerDataExperience(3),
                            new PlayerDataSkills(8, 3, 2, 2, 2, 2, 1, 0),
                            new Reward(4000, 30000),
                            new PlayerDataArmors(2, 2, 2, 2, 2, 2, 2, 2, 2),
                            new PlayerDataWeapons(Weapon.CategoryEnum.Hacking, 4)
                        )
                    }
                )
            );

            _list.Add(
                new TournamentData
                (
                    "Master's Court",
                    "The Master's Court is the first tournament to be held in the old Grand Arena, the second largest stadium in the realm. Many great gladiators have fought and died competing for this most prestigious of titles",
                    3,
                    "Saudalin",
                    new List<ParticipantData>
                    {
                        new ParticipantData
                        (
                            false,
                            names.GetRandomFullName(),
                            colors.Get(),
                            new PlayerDataExperience(3),
                            new PlayerDataSkills(8, 3, 2, 2, 2, 2, 1, 0),
                            new Reward(),
                            new PlayerDataArmors(2, 2, 1, 1, 1, 1, 1, 0, 0),
                            new PlayerDataWeapons(Weapon.CategoryEnum.Hacking, 2)
                        ),
                        new ParticipantData
                        (
                            false,
                            names.GetRandomFullName(),
                            colors.Get(),
                            new PlayerDataExperience(3),
                            new PlayerDataSkills(8, 3, 2, 2, 2, 2, 1, 0),
                            new Reward(),
                            new PlayerDataArmors(2, 2, 1, 1, 1, 1, 1, 0, 0),
                            new PlayerDataWeapons(Weapon.CategoryEnum.Hacking, 2)
                        ),
                        new ParticipantData
                        (
                            false,
                            names.GetRandomFullName(),
                            colors.Get(),
                            new PlayerDataExperience(3),
                            new PlayerDataSkills(8, 3, 2, 2, 2, 2, 1, 0),
                            new Reward(),
                            new PlayerDataArmors(2, 2, 1, 1, 1, 1, 1, 0, 0),
                            new PlayerDataWeapons(Weapon.CategoryEnum.Hacking, 2)
                        ),
                        new ParticipantData
                        (
                            false,
                            names.GetRandomFullName(),
                            colors.Get(),
                            new PlayerDataExperience(3),
                            new PlayerDataSkills(8, 3, 2, 2, 2, 2, 1, 0),
                            new Reward(),
                            new PlayerDataArmors(2, 2, 1, 1, 1, 1, 1, 0, 0),
                            new PlayerDataWeapons(Weapon.CategoryEnum.Hacking, 2)
                        ),
                        new ParticipantData
                        (
                            false,
                            names.GetRandomFullName(),
                            colors.Get(),
                            new PlayerDataExperience(3),
                            new PlayerDataSkills(8, 3, 2, 2, 2, 2, 1, 0),
                            new Reward(),
                            new PlayerDataArmors(2, 2, 1, 1, 1, 1, 1, 0, 0),
                            new PlayerDataWeapons(Weapon.CategoryEnum.Hacking, 2)
                        ),
                        new ParticipantData
                        (
                            true,
                            names.GetRandomFullName(),
                            colors.Get(),
                            new PlayerDataExperience(3),
                            new PlayerDataSkills(8, 3, 2, 2, 2, 2, 1, 0),
                            new Reward(4000, 30000),
                            new PlayerDataArmors(2, 2, 2, 2, 2, 2, 2, 2, 2),
                            new PlayerDataWeapons(Weapon.CategoryEnum.Hacking, 4)
                        )
                    }
                )
            );
        }
    }
}
