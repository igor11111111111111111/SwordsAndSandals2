using System.Linq;
using UnityEngine;

namespace SwordsAndSandals.PreArena
{
    public class MenuPanel : MonoBehaviour
    {
        [SerializeField] private EnterToDuelButton _enterToDuelButton;
        [SerializeField] private EnterToTournamentButton _enterToTournamentButton;

        public void Init(TournamentData tournamentData, PlayerData playerData)
        {
            if (playerData.DataLevel.Level >= tournamentData.GetFirstComplete(false).Level)
            {
                _enterToDuelButton.Init(false);
                _enterToTournamentButton.Init(true);
            }
            else
            {
                _enterToDuelButton.Init(true);
                _enterToTournamentButton.Init(false);
            }
        } 
    }
}
