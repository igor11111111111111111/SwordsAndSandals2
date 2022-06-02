using UnityEngine;

namespace SwordsAndSandals.Tournament
{
    public class TournamentDataDontDestroy : MonoBehaviour
    {
        private static bool _created = false;
        public TournamentData TournamentData => _tournamentData;
        private TournamentData _tournamentData;
         
        private void Awake()
        {
            if (!_created)
            {
                DontDestroyOnLoad(this);
                _created = true;
            }
            else
            {
                Destroy(this);
            }
        }

        public void Init(TournamentData tournamentData)
        {
            _tournamentData = tournamentData;
        }
    }
}
