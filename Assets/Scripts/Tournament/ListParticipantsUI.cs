using CustomJson;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SwordsAndSandals.Tournament
{
    public class ListParticipantsUI : MonoBehaviour
    {
        [SerializeField] private ParticipantUI participantPrefab;

        public void Init(TournamentDataDontDestroy tournamentDataScene)
        {
            Deads(tournamentDataScene);
            Player();
            Alives(tournamentDataScene);
        }

        private void Deads(TournamentDataDontDestroy tournamentDataScene)
        {
            var deads = tournamentDataScene.TournamentData.Participants.Where(p => !p.IsAlive).ToArray();

            foreach (var participant in deads)
            {
                var instParticipant = Instantiate(participantPrefab, transform);

                instParticipant.Init(participant.Name + "(dead)", Color.gray);
            }
        }

        private void Player()
        {
            var player = Instantiate(participantPrefab, transform);
            var name = new Json().Load<PlayerData>().Name + "(you)";
            player.Init(name, Color.green);
        }

        private void Alives(TournamentDataDontDestroy tournamentDataScene)
        {
            var alives = tournamentDataScene.TournamentData.Participants.Where(p => p.IsAlive).ToArray();

            foreach (var participant in alives)
            {
                var instParticipant = Instantiate(participantPrefab, transform);

                if (participant.Name.Contains("(boss)"))
                {
                    instParticipant.Init(participant.Name, Color.yellow);
                }
                else
                {
                    instParticipant.Init(participant.Name);
                }
            }
        }
    }
}
