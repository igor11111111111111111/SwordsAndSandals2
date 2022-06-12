using CustomJson;
using SwordsAndSandals.PreArena;
using UnityEngine;

namespace SwordsAndSandals.Tournament
{
    public class TournamentInit : MonoBehaviour
    {
        [SerializeField] private ListParticipantsUI _listParticipantsUI;
        [SerializeField] private TournamentPanel _tournamentPanel;

        private void Awake()
        {
            if(TournamentDataDontDestroy.TournamentData != null)
            {
                _listParticipantsUI.Init();
                _tournamentPanel.Init();
            }
            else
            {
                Debug.Log("need class: TournamentDataDontDestroy. \n !!! load this scene after PreArena to current work !!!");
            }
        }
    }
}
