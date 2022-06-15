using System;
using UnityEngine;

namespace SwordsAndSandals.Arena
{
    public class PlayerRotator
    {
        private PlayerInjector _injector;
        private ArenaHandler _arenaHandler;
        private float _oldDistance;
        private float _floatNull;

        public PlayerRotator()
        {

        }

        public PlayerRotator(PlayerInjector playerInjector, ArenaHandler arenaHandler)
        {
            _injector = playerInjector;
            _arenaHandler = arenaHandler;

            _floatNull = -9999;
            _oldDistance = _floatNull;
        }

        public void CheckRotation()
        {
            var distance = _arenaHandler.GetDistance();

            if (_oldDistance == _floatNull)
                _oldDistance = distance;

            if (Mathf.Sign(distance) != Mathf.Sign(_oldDistance))
            {
                Rotate(_injector.transform);
            }

            _oldDistance = distance;
        }

        public void Rotate(Transform transform)
        {
            transform.rotation = transform.rotation.y == 0
            ? Quaternion.Euler(0, 180, 0)
            : Quaternion.Euler(0, 0, 0);

            _injector.Direction = transform.rotation.y == 0
            ? Enums.Direction.Right
            : Enums.Direction.Left;
        }

        public void Rotate(PlayerInjector injector)
        {
            injector.transform.rotation = injector.transform.rotation.y == 0
            ? Quaternion.Euler(0, 180, 0)
            : Quaternion.Euler(0, 0, 0);

            injector.Direction = injector.transform.rotation.y == 0
            ? Enums.Direction.Right
            : Enums.Direction.Left;
        }
    }
}
