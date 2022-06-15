using System;
using System.Collections.Generic;
using UnityEngine;

namespace SwordsAndSandals.Arena
{
    public class AiInput : IUseInput
    {
        public Action<bool> OnInBattle { get; set; }
        public Action[] Actions { get; set; }
        private ArenaHandler _arenaHandler;
        private PlayerInjector _injector;
        private PlayerRotator _playerRotator;
        private PlayerData _playerData;

        public void Init(PlayerInjector injector, TurnLogic turnLogic, ArenaHandler arenaHandler, PlayerData playerData)
        { 
            _injector = injector;
            _arenaHandler = arenaHandler;
            _playerData = playerData;
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

            new AILogic(_arenaHandler, _playerData, Actions, OnInBattle);
        }
    }
}
