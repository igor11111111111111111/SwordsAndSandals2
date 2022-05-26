using System;
using System.Collections.Generic;

namespace SwordsAndSandals.Arena
{
    public class AiInput : IUseInput
    {
        public Action<bool> OnInBattle { get; set; }
        public Action[] Actions { get; set; }
        private ArenaHandler _arenaHandler;
        private PlayerInjector _injector;
        private PlayerRotator _playerRotator;

        public void Init(PlayerInjector aiInjector, TurnLogic turnLogic, ArenaHandler arenaHandler)
        { 
            _injector = aiInjector;
            _arenaHandler = arenaHandler;

            _playerRotator = new PlayerRotator(_injector, _arenaHandler);

            Actions = new Action[9];

            turnLogic.OnStarted += TurnStarted;
        }

        private void TurnStarted(Enums.Team team)
        {
            if (team != Enums.Team.AI)
                return;

            OnInBattle?.Invoke(_arenaHandler.InBattleDistance());

            _playerRotator.CheckRotation();

            Actions[4/*UnityEngine.Random.Range(0, 9)*/]?.Invoke();
        }
    }
}
