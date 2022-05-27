using UnityEngine;

namespace SwordsAndSandals.PreArena
{

    public class MenuPanel : MonoBehaviour
    {
        [SerializeField] private EnterToDuelButton _enterToDuelButton;
        [SerializeField] private EnterToTournamentButton _enterToTournamentButton;

        public void Init(TournamentData tournamentData, PlayerData playerData)
        {
            //if(tournamentData.LevelComplete[playerData.DataLevel.Level])

            _enterToDuelButton.Init();
            _enterToTournamentButton.Init();
        } 
    }
}
