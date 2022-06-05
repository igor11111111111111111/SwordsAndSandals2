using CustomJson;
using SwordsAndSandals.OutScene;
using SwordsAndSandals.Tournament;
using System.Linq;
using UnityEngine;
using static SwordsAndSandals.Arena.EndBattlePanel;

namespace SwordsAndSandals.Arena
{
    public class AcceptEndBattlePanel
    {
        private SwordsAndSandals.PlayerData _playerData;
        private SwordsAndSandals.PlayerData _aiData;
        private Enums.Team _winningTeam;
        private TournamentDataDontDestroy _tournamentDataDontDestroy;
        private XPData _XPData;

        public AcceptEndBattlePanel(SwordsAndSandals.PlayerData playerData, SwordsAndSandals.PlayerData aiData, Enums.Team winningTeam, TournamentDataDontDestroy tournamentDataDontDestroy, XPData xPData)
        {
            _playerData = playerData;
            _aiData = aiData;
            _winningTeam = winningTeam;
            _tournamentDataDontDestroy = tournamentDataDontDestroy;
            _XPData = xPData;

            Accept();
        }

        private void Accept()
        {
            if (_winningTeam == Enums.Team.Player)
            {
                Win();
            }
            else
            {
                Lose();
            }
        }

        private void Win()
        {
            _playerData.DataLevel.CurrentXP = _XPData.NewXP;
            _playerData.Money += _aiData.Reward.Money; // * coeff apprecation

            _XPData.SetNewLevel(_playerData.DataLevel.Level);

            if (_tournamentDataDontDestroy != null)
            {
                WinTournament();
            }
            else
            {
                WinRegularFight();
            }
        }

        private void WinTournament()
        {
            var aliveParticipants = _tournamentDataDontDestroy.TournamentData.Participants.Where(p => p.IsAlive);

            if (aliveParticipants.Count() == 1)
            {
                WinAllTournament();
            }
            else
            {
                WinTournamentFight();
            }
        }

        private void WinAllTournament()
        {
            Object.Destroy(_tournamentDataDontDestroy.gameObject);

            var tournamentData = new Json().Load<TournamentData>();
            tournamentData.SetCurrentComplete();
            new Json().Save(tournamentData);

            AddSkillPoints();
            new Json().Save(_playerData);
            new SceneChanger().MoveTo(Enums.Scene.LevelUp);
        }

        private void WinTournamentFight()
        {
            if (_XPData.NewXP >= _XPData.XPToNewLevel)
            {
                AddSkillPoints();
                new Json().Save(_playerData);
            }

            _tournamentDataDontDestroy.TournamentData.Participants.Find(ai => ai.PlayerData == _aiData).IsAlive = false;
            new SceneChanger().MoveTo(Enums.Scene.Tournament);
        }

        private void WinRegularFight()
        {
            if (_XPData.NewXP >= _XPData.XPToNewLevel)
            {
                AddSkillPoints();
                new Json().Save(_playerData);
                new SceneChanger().MoveTo(Enums.Scene.LevelUp);
            }
            else
            {
                new Json().Save(_playerData);
                new SceneChanger().MoveTo(Enums.Scene.Street);
            }
        }

        private void Lose()
        {
            new SceneChanger().MoveTo(Enums.Scene.Street);
        }

        private void AddSkillPoints()
        {
            _playerData.DataSkills.AddPointsPerLevel(_XPData.GetDeltaLevels());
        }
    }
}
