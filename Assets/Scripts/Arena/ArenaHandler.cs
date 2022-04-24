using UnityEngine;

namespace SwordsAndSandals.Arena
{
    public class ArenaHandler
    {
        private PlayerInjector _playerInjector;
        private PlayerInjector _aiInjector;

        public ArenaHandler(PlayerInjector playerInjector, PlayerInjector aiInjector)
        {
            _playerInjector = playerInjector;
            _aiInjector = aiInjector;
        }

        public bool InBattleDistance()
        {
            return Mathf.Abs(GetDistance()) <= 3 ? true : false;
        }

        public float GetDistance()
        {
            return _playerInjector.transform.position.x - _aiInjector.transform.position.x;
        }
    }
}
