using System;

namespace SwordsAndSandals.Arena
{
    public partial class TurnLogic
    { 
        public Enums.Team CurrentTeam;
        public Action<Enums.Team> OnStarted;
        public Action<Enums.Team> OnEnded;

        public void Init(PlayerInjector playerInjector, PlayerInjector aiInjector)
        {
            CurrentTeam = Enums.Team.Player;
            OnStarted?.Invoke(CurrentTeam);

            playerInjector.Controller.OnEndAction += EndTurn;
            aiInjector.Controller.OnEndAction += EndTurn;
        }

        private void EndTurn()
        {
            OnEnded?.Invoke(CurrentTeam);

            CurrentTeam = 
                CurrentTeam == Enums.Team.AI 
                ? Enums.Team.Player 
                : Enums.Team.AI;

            OnStarted?.Invoke(CurrentTeam);
        }
    }
}
