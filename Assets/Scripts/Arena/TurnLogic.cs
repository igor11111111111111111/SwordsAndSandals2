using System;

namespace SwordsAndSandals.Arena
{
    public partial class TurnLogic
    { 
        public Enums.Team CurrentTeam;
        public Action<Enums.Team> OnStarted;
        private PlayerInjector _playerInjector;
        private PlayerInjector _aiInjector;

        public void Init(PlayerInjector playerInjector, PlayerInjector aiInjector)
        {
            _playerInjector = playerInjector;
            _aiInjector = aiInjector;

            CurrentTeam = Enums.Team.Player;
            OnStarted?.Invoke(CurrentTeam);

            playerInjector.Controller.OnEndAction += EndTurn;
            aiInjector.Controller.OnEndAction += EndTurn;
        }

        private void EndTurn()
        {
            CurrentTeam = 
                CurrentTeam == Enums.Team.AI 
                ? Enums.Team.Player 
                : Enums.Team.AI;

            OnStarted?.Invoke(CurrentTeam);
        }
    }
}
