using System.Collections.Generic;
using UnityEngine;

namespace SwordsAndSandals.Arena
{
    public class StaminaLogic
    {
        private Dictionary<Enums.CurrentState, int> _stateValue;

        public StaminaLogic(IUseController controller, PlayerData arenaPlayerData)
        {
            _stateValue = new Dictionary<Enums.CurrentState, int>();
            _stateValue.Add(Enums.CurrentState.Charge, 16);
            _stateValue.Add(Enums.CurrentState.Dance, 3);
            _stateValue.Add(Enums.CurrentState.HardAttack, 7);
            _stateValue.Add(Enums.CurrentState.MediumAttack, 5);
            _stateValue.Add(Enums.CurrentState.WeakAttack, 3);
            _stateValue.Add(Enums.CurrentState.Jump, 8);
            _stateValue.Add(Enums.CurrentState.Move, 4);
            _stateValue.Add(Enums.CurrentState.Punch, 4);
            _stateValue.Add(Enums.CurrentState.Rage, 1); // * level charism
            _stateValue.Add(Enums.CurrentState.SuperAttack1, 5);
            _stateValue.Add(Enums.CurrentState.SuperAttack2, 5);
            _stateValue.Add(Enums.CurrentState.SuperAttack3, 5);
            _stateValue.Add(Enums.CurrentState.Sleep, -20);

            controller.OnStartAction += (state) =>
            {
                arenaPlayerData.StaminaData.Current -= _stateValue[state];
            };
        }
    }
} 
