using System;
using UnityEngine;

namespace SwordsAndSandals.Tournament
{
    public class TournamentDataDontDestroy : MonoBehaviour
    {
        public static TournamentDataDontDestroy Instance;
        private static bool _created = false;
        public static TournamentData TournamentData => _tournamentData;
        private static TournamentData _tournamentData;

        private void Awake()
        {
            if (!_created)
            {
                DontDestroyOnLoad(this);
                Instance = this;
                _created = true;
            }
            else
            {
                Instance = null;
                Destroy(this);
            }
        }

        public void Init(TournamentData tournamentData)
        {
            _tournamentData = tournamentData;
        }
    }
}
