using System;
using UnityEngine;

namespace SwordsAndSandals.Arena
{
    public class PlayerInput : IUseInput
    {
        public Action<bool> OnInBattle { get; set; }
        public Action[] Actions { get; set; }
        private PlayerInjector _injector;
        private PlayerRotator _playerRotator;
        private ArenaHandler _arenaHandler;
        private PlayerInputUI _playerInputUI;
         
        public PlayerInput(PlayerInjector injector, TurnLogic turnLogic, ArenaHandler arenaHandler, PlayerInputUI playerInputUI)
        {
            _injector = injector;
            _arenaHandler = arenaHandler;
            _playerInputUI = playerInputUI;
            _playerRotator = new PlayerRotator(_injector, _arenaHandler);

            Actions = new Action[9];

            for (int i = 0; i < Actions.Length; i++)
            {
                ActionsSub(i);
            }
            turnLogic.OnStarted += TurnStarted;
        }

        private void ActionsSub(int i) //idk, this lambda dont work in cycle for
        {
            _playerInputUI.ActionIcons[i].OnClicked += () => Actions[i]?.Invoke();
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
