﻿using System.Collections.Generic;

namespace SwordsAndSandals.Tournament
{
    public class TournamentData
    {
        public string Name => _name;
        private string _name;
        public string Info => _info;
        private string _info;
        public string IconPath => _iconPath;
        private string _iconPath;
        public string LocationPath => _locationPath;
        private string _locationPath;
        public List<ParticipantData> Participants => _participants;
        private List<ParticipantData> _participants;

        public TournamentData(string name, string info, string iconPath, string locationPath, List<ParticipantData> participants)
        {
            _name = name;
            _info = info;
            _iconPath = iconPath;
            _locationPath = locationPath;
            _participants = participants;
        }
    }
}