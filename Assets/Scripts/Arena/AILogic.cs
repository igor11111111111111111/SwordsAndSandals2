using System;
using UnityEngine;

namespace SwordsAndSandals.Arena
{
    public class AILogic
    {
        private ArenaHandler _arenaHandler;
        private PlayerData _playerData;
        private Action[] _actions;

        public AILogic(ArenaHandler _arenaHandler, PlayerData _playerData, Action[] _actions, Action<bool> OnInBattle)
        {
            this._arenaHandler = _arenaHandler;
            this._playerData = _playerData;
            this._actions = _actions;

            if (_playerData.StaminaData.Current <= 16)
            {
                _actions[3]?.Invoke(); // sleep
            }
            else if (_playerData.HealthData.Current / (float)_playerData.HealthData.Max <= 0.3f)
            {
                if (_arenaHandler.GetAbsDistance() < 6)
                {
                    OnInBattle?.Invoke(false);
                    _actions[5]?.Invoke(); // jump right
                }
                else
                {
                    _actions[3]?.Invoke(); // sleep
                }
            }
            else
            {
                if (_arenaHandler.InBattleDistance())
                {
                    _actions[UnityEngine.Random.Range(5, 8)]?.Invoke(); // attack
                }
                else if (_arenaHandler.GetDistance() > -4 &&
                    _arenaHandler.GetDistance() < -3 ||
                    _arenaHandler.GetDistance() > 3 &&
                    _arenaHandler.GetDistance() < 4)
                {
                    _actions[7]?.Invoke(); // charge
                }
                else
                {
                    var index = UnityEngine.Random.Range(1, 4);
                    if (index == 1)
                    {
                        _actions[2]?.Invoke(); // rage
                    }
                    else if (index == 2)
                    {
                        _actions[4]?.Invoke(); // dance
                    }
                    else
                    {
                        Move();
                    }
                }
            }
        }

        private void Move()
        {
            var index = UnityEngine.Random.Range(1, 3);
            if (index == 1)
            {
                if (_arenaHandler.GetDistance() <= -4)
                {
                    _actions[1]?.Invoke(); // move left
                }
                else if (_arenaHandler.GetDistance() >= 4)
                {
                    _actions[6]?.Invoke(); // move right
                }
            }
            else
            {
                if (_arenaHandler.GetDistance() <= -4)
                {
                    _actions[0]?.Invoke(); // jump left
                }
                else if (_arenaHandler.GetDistance() >= 4)
                {
                    _actions[5]?.Invoke(); // jump right
                }
            }
        }
    }
}
