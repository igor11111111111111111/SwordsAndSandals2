
using System;
using System.Threading.Tasks;
using UnityEngine;
 
namespace SwordsAndSandals.Arena
{
    public class CameraMover
    {
        private Camera _playerCamera;
        private Camera _aiCamera;
        private Camera _ourCamera;
        private Camera _uiCamera;

        private PlayerInjector _playerInjector;
        private PlayerInjector _aiInjector;
        private TurnLogic _turnLogic;
        private ArenaHandler _arenaHandler;

        private float _speed = 0.1f;
        private Enums.Team _oldTeam;

        public CameraMover(Camera playerCamera, Camera aiCamera, Camera ourCamera, Camera uiCamera, PlayerInjector playerInjector, PlayerInjector aiInjector, TurnLogic turnLogic)
        {
            _playerCamera = playerCamera;
            _aiCamera = aiCamera;
            _ourCamera = ourCamera;
            _uiCamera = uiCamera;
            _playerInjector = playerInjector;
            _aiInjector = aiInjector;
            _turnLogic = turnLogic;

            _turnLogic.OnEnded += TurnEnded;

            _ourCamera.transform.transform.position = new Vector3(0, 0, 2);
            _uiCamera.cullingMask = 1 << LayerMask.NameToLayer("UI");
        } 

        public void Init(ArenaHandler arenaHandler)
        {
            _arenaHandler = arenaHandler;
        }

        private void TurnEnded(Enums.Team team)
        {
            var offset = new Vector3(0, 2.5f, -2);
            Move(_playerCamera, _playerInjector.transform.position + offset, team);
            Move(_aiCamera, _aiInjector.transform.position + offset, team);
            Split(team);

            _oldTeam = team;
        }

        private void Split(Enums.Team team)
        {
            var playerCameraWidth = _playerCamera.ScreenToWorldPoint(
                new Vector3(_playerCamera.pixelWidth, 0, 0));
            var aiCameraWidthRight = _aiCamera.ScreenToWorldPoint(
                new Vector3(_playerCamera.pixelWidth, 0, 0));
            var aiCameraWidthLeft = _aiCamera.ScreenToWorldPoint(
                new Vector3(-_playerCamera.pixelWidth, 0, 0));

            if(_playerCamera.transform.position.x < _aiCamera.transform.position.x)
            {
                _playerCamera.rect = new Rect(0, 0, 0.5f, 1);
                _aiCamera.rect = new Rect(0.5f, 0, 1, 1);
            }
            else
            {
                _aiCamera.rect = new Rect(0, 0, 0.5f, 1);
                _playerCamera.rect = new Rect(0.5f, 0, 1, 1);
            }

            if (
                _playerInjector.Direction == Enums.Direction.Right && playerCameraWidth.x >= aiCameraWidthRight.x || 
                _playerInjector.Direction == Enums.Direction.Left && playerCameraWidth.x < Mathf.Abs(aiCameraWidthLeft.x))
            {
                var target = new Vector3(_playerInjector.transform.position.x - _arenaHandler.GetDistance() / 2f, _playerInjector.transform.position.y + 2.5f, 2);
                Move(_ourCamera, target, team);
                SetOurCamera(true);
            }
            else
            {
                SetOurCamera(false);
            }
        }

        private void SetOurCamera(bool active)
        {
            if (active)
            {
                _uiCamera.transform.SetParent(_ourCamera.transform);
                _uiCamera.transform.localPosition = new Vector3(0, 0, -2);
            }
            else
            {
                _uiCamera.transform.SetParent(_playerCamera.transform);
            }

            _ourCamera.gameObject.SetActive(active);
            _playerCamera.gameObject.SetActive(!active);
            _aiCamera.gameObject.SetActive(!active);
        }

        private async void Move(Camera camera, Vector3 target, Enums.Team team)
        {
            while (camera.transform.position != target)
            {
                camera.transform.position = Vector3.Lerp(camera.transform.position, target, _speed);

                await Task.Delay(10);

                if (_oldTeam != team)
                    break;
            }
        }
    } 
}
