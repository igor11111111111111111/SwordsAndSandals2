﻿using CustomJson;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SwordsAndSandals.Tournament
{
    public class ListParticipantsUI : MonoBehaviour
    {
        [SerializeField] private ParticipantUI participantPrefab;

        public void Init(TournamentData tournamentData)
        {
            Losts(tournamentData);
            Player();
            Alives(tournamentData);
        }

        private void Losts(TournamentData tournamentData)
        {
            var Losts = tournamentData.Participants.Where(p => !p.IsAlive).ToArray();

            foreach (var participant in Losts)
            {
                var instParticipant = Instantiate(participantPrefab, transform);

                instParticipant.Init(participant.PlayerData.Name + "(lost)", Color.gray);
            }
        }

        private void Player()
        {
            var player = Instantiate(participantPrefab, transform);
            var name = new Json().Load<PlayerData>().Name + "(you)";
            player.Init(name, Color.green);
        }

        private void Alives(TournamentData tournamentData)
        {
            var alives = tournamentData.Participants.Where(p => p.IsAlive).ToArray();

            foreach (var participant in alives)
            {
                var instParticipant = Instantiate(participantPrefab, transform);

                if (participant.IsBoss)
                {
                    instParticipant.Init(participant.PlayerData.Name, Color.yellow);
                }
                else
                {
                    instParticipant.Init(participant.PlayerData.Name);
                }
            }
        }
    }
}
