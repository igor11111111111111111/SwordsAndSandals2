using System;
using UnityEngine;

namespace SwordsAndSandals.Arena
{
    public class PlayerInput
    {
        public Action<bool> OnInBattle;

        private PlayerInjector _injector;
        private PlayerRotator _playerRotator;
        private ArenaHandler _arenaHandler;

        public PlayerInput(PlayerInjector injector, TurnLogic turnLogic, ArenaHandler arenaHandler)
        {
            _injector = injector;
            _arenaHandler = arenaHandler;
            _playerRotator = new PlayerRotator(_injector, _arenaHandler);

            turnLogic.OnStarted += TurnStarted;
        }

        private void TurnStarted(Enums.Team team)
        {
            if (team != Enums.Team.Player)
                return;

            OnInBattle?.Invoke(_arenaHandler.InBattleDistance());

            _playerRotator.CheckRotation();
        }
    }
}
