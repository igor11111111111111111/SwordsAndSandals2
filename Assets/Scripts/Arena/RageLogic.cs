using System;

namespace SwordsAndSandals.Arena
{
    public class RageLogic
    {
        public event Action<Enums.Team> OnAction;

        public RageLogic(PlayerInjector playerInjector, PlayerInjector aiInjector)
        {
            var playerController = playerInjector.Controller;
            playerController.Init(this);
            playerController.OnStartAction += (state) => StartAction(playerInjector.Data.Team, state);

            var aiController = aiInjector.Controller;
            aiController.Init(this);
            aiController.OnStartAction += (state) => StartAction(aiInjector.Data.Team, state);
        }

        private void StartAction(Enums.Team team, Enums.CurrentState state)
        {
            if (state != Enums.CurrentState.Rage)
                return;

            OnAction?.Invoke(team);
        }
    }
}
