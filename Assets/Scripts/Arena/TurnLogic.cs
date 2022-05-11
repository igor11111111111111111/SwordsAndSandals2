using System;
using UnityEngine;

namespace SwordsAndSandals.Arena
{
    public partial class TurnLogic
    { 
        public Enums.Team CurrentTeam;
        public Action<Enums.Team> OnStarted;
        public Action<Enums.Team> OnEnded;

        private PlayerInjector _playerInjector;
        private PlayerInjector _aiInjector;

        public void Init(PlayerInjector playerInjector, PlayerInjector aiInjector, EndBattleHandler endBattleHandler)
        {
            _playerInjector = playerInjector;
            _aiInjector = aiInjector;
            CurrentTeam = Enums.Team.Player;
            OnStarted?.Invoke(CurrentTeam);

            _playerInjector.Controller.OnEndAction += ChangeTurn;
            _aiInjector.Controller.OnEndAction += ChangeTurn;

            endBattleHandler.OnEndBattle += UnsubChangeTurn;
        }

        private void ChangeTurn()
        {
            OnEnded?.Invoke(CurrentTeam);

            CurrentTeam = 
                CurrentTeam == Enums.Team.AI 
                ? Enums.Team.Player 
                : Enums.Team.AI;

            OnStarted?.Invoke(CurrentTeam);
        }

        private void UnsubChangeTurn(EndBattleHandler.Info _)
        {
            _playerInjector.Controller.OnEndAction -= ChangeTurn;
            _aiInjector.Controller.OnEndAction -= ChangeTurn;
        }
    }
}
