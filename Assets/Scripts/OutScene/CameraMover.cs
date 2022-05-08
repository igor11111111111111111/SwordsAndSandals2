using SwordsAndSandals.Arena;
using System;
using System.Threading.Tasks;
using UnityEngine;

namespace SwordsAndSandals
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
        private bool _isSplited;

        public CameraMover(Camera playerCamera, Camera aiCamera, Camera ourCamera, Camera uiCamera, PlayerInjector playerInjector, PlayerInjector aiInjector, TurnLogic turnLogic)
        {
            _playerCamera = playerCamera;
            _aiCamera = aiCamera;
            _ourCamera = ourCamera;
            _uiCamera = uiCamera;
            _playerInjector = playerInjector;
            _aiInjector = aiInjector;
            _turnLogic = turnLogic;

            _turnLogic.OnStarted += TurnStarted;
            _turnLogic.OnEnded += TurnEnded;

            _uiCamera.cullingMask = 1 << LayerMask.NameToLayer("UI");
        } 

        public void Init(ArenaHandler arenaHandler)
        {
            _arenaHandler = arenaHandler;
        }

        private void TurnStarted(Enums.Team team)
        {
            if (team != Enums.Team.Player)
                return;

            if (_isSplited)
            {
                _uiCamera.transform.SetParent(_playerCamera.transform);
            }
            else
            {
                _uiCamera.transform.SetParent(_ourCamera.transform);
                _uiCamera.transform.localPosition = new Vector3(0, 0, -2);
            }
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
            var playerWorld = _playerCamera.ScreenToWorldPoint(new Vector3(_playerCamera.pixelWidth, 0, 0));
            var aiWorld = _aiCamera.ScreenToWorldPoint(new Vector3(_playerCamera.pixelWidth, 0, 0));

            if (playerWorld.x >= aiWorld.x)
            {
                var target = new Vector3(_playerInjector.transform.position.x + _arenaHandler.GetAbsDistance() / 2f, _playerInjector.transform.position.y + 2.5f, 2);

                Move(_ourCamera, target, team);
                SwitchOurCamera(true);
            }
            else
            {
                SwitchOurCamera(false);
            }
        }

        private void SwitchOurCamera(bool active)
        {
            _ourCamera.gameObject.SetActive(active);
            _playerCamera.gameObject.SetActive(!active);
            _aiCamera.gameObject.SetActive(!active);
            _isSplited = !active;
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
