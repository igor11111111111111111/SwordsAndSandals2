using System;
using System.Collections.Generic;
using UnityEngine;

namespace SwordsAndSandals.Arena
{

    public class PlayerInput : MonoBehaviour
    {
        public Action<bool> OnInBattle;

        [SerializeField] private ActionIcon iconPrefab;
        [SerializeField] private GameObject _body;
        private PlayerInjector _injector;
        public List<ActionIcon> ActionIcons => _actionIcons;
        private List<ActionIcon> _actionIcons;
        private PlayerController _controller;
        private TurnLogic _turnLogic;
        private PlayerRotator _playerRotator;
        private ArenaHandler _arenaHandler;

        public void Init(PlayerInjector injector)
        {
            _injector = injector;

            _actionIcons = new List<ActionIcon>();
            for (int i = 0; i < 8; i++)
            {
                var icon = Instantiate(iconPrefab, _body.transform);
                icon.Init();
                icon.name = i.ToString();
                _actionIcons.Add(icon);
            };

            MoveBody();
        }

        public void LateInit(PlayerController controller, TurnLogic turnLogic, ArenaHandler arenaHandler)
        {
            _controller = controller;
            _turnLogic = turnLogic;
            _arenaHandler = arenaHandler;
            _playerRotator = new PlayerRotator(_injector, _arenaHandler);

            _turnLogic.OnStarted += TurnStarted;
            _controller.OnStartAction += StartAction;

            new ActionIconsChanger(_actionIcons, _controller);
        }

        private void TurnStarted(Enums.Team team)
        {
            if (team != Enums.Team.Player)
                return;

            OnInBattle?.Invoke(_arenaHandler.InBattleDistance());

            _playerRotator.CheckRotation();
 
            SetBodyActive(true);
            MoveBody();
        }

        private void StartAction()
        {
            SetBodyActive(false);
        }

        private void MoveBody()
        {
            if (_injector == null)
                return;

            var offset = new Vector3(-1, 3.5f, 0);
            _body.transform.position = _injector.transform.position + offset;
        }

        private void SetBodyActive(bool active)
        {
            _body.SetActive(active);
        }
    }
}
