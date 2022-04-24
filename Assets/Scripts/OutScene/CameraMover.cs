using UnityEngine;

namespace SwordsAndSandals
{
    public class CameraMover : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        private PlayerInjector _playerInjector;

        private float _speed = 1f;
        private Vector3 _offset;

        public void Init(PlayerInjector playerInjector, Vector3 offset)
        {
            _playerInjector = playerInjector;
            _offset = new Vector3(offset.x, offset.y, _camera.transform.position.z);
        }

        private void Update()
        {
            if (_playerInjector == null)
                return;
            _camera.transform.position = Vector3.Lerp(_camera.transform.position, _playerInjector.transform.position + _offset, _speed);
        }
    } 
}
