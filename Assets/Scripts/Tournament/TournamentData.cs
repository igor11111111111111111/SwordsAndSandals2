using System.Collections.Generic;

namespace SwordsAndSandals.Tournament
{
    public class TournamentData
    {
        public string Name => _name;
        private string _name;
        public string Info => _info;
        private string _info;
        public int IconIndex => _iconIndex;
        private int _iconIndex; 
        public string LocationPath => _locationPath;
        private string _locationPath;
        public List<ParticipantData> Participants => _participants;
        private List<ParticipantData> _participants;

        public TournamentData(string name, string info, int iconIndex, string locationPath, List<ParticipantData> participants)
        {
            _name = name;
            _info = info;
            _iconIndex = iconIndex;
            _locationPath = locationPath;
            _participants = participants;
        }
    }
}
