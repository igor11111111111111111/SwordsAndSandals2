using System;
using System.Collections.Generic;

namespace SwordsAndSandals.Arena
{
    public class AiInput
    {
        public Action<bool> OnInBattle;
        public Action[] Actions;
        private ArenaHandler _arenaHandler;
        private PlayerInjector _injector;
        private PlayerRotator _playerRotator;

        public void Init(PlayerInjector aiInjector, TurnLogic turnLogic, ArenaHandler arenaHandler)
        {
            _injector = aiInjector;
            _arenaHandler = arenaHandler;

            _playerRotator = new PlayerRotator(_injector, _arenaHandler);

            Actions = new Action[8];

            turnLogic.OnStarted += TurnStarted;
        }

        private void TurnStarted(Enums.Team team)
        {
            if (team != Enums.Team.AI)
                return;

            OnInBattle?.Invoke(_arenaHandler.InBattleDistance());

            _playerRotator.CheckRotation();

            Actions[UnityEngine.Random.Range(0, 8)]?.Invoke();
        }
    }
}
