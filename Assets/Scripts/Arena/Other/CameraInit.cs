using UnityEngine;

namespace SwordsAndSandals.Arena
{
    public class CameraInit : MonoBehaviour
    {
        public Camera Player => _player;
        public Camera Ai => _ai;
        public Camera Our => _our;
        public Camera Ui => _ui;
        [SerializeField] private Camera _player;
        [SerializeField] private Camera _ai;
        [SerializeField] private Camera _our;
        [SerializeField] private Camera _ui;
    }
}
