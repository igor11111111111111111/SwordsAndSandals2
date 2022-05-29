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
            var tournamentDataScene = FindObjectOfType<TournamentDataDontDestroy>();
            if(tournamentDataScene != null)
            {
                _listParticipantsUI.Init(tournamentDataScene);
                _tournamentPanel.Init(tournamentDataScene.TournamentData);
            }
            else
            {
                Debug.Log("need class: TournamentDataDontDestroy. \n !!! load this scene after PreArena to current work !!!");
            }
        }
    }
}
