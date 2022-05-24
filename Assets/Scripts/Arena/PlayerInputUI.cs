using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace SwordsAndSandals.Arena
{
    public class PlayerInputUI : MonoBehaviour
    { 
        [SerializeField] private ActionIcon iconPrefab;
        [SerializeField] private GameObject _body;
        public List<ActionIcon> ActionIcons => _actionIcons;
        private List<ActionIcon> _actionIcons;
        private PlayerController _controller;
        private PlayerInjector _injector;

        public void Init(PlayerInjector injector, TurnLogic turnLogic)
        {
            _injector = injector;
            _actionIcons = new List<ActionIcon>();

            for (int i = 0; i < 9; i++)
            {
                var icon = Instantiate(iconPrefab, _body.transform);
                icon.Init();
                icon.name = i.ToString();
                _actionIcons.Add(icon);
            };

            turnLogic.OnStarted += Show;
            SetBodyActive(false);
        }

        public void Init(EndBattleHandler endBattleHandler)
        {
            endBattleHandler.OnEndBattle += (info) => { SetBodyActive(false); };
        }

        public void LateInit(PlayerController controller, SwordsAndSandals.PlayerData aiData)
        {
            _controller = controller;
            _controller.OnStartAction += (_) => SetBodyActive(false);

            new ActionIconsChanger(_actionIcons, _controller, _injector.Data.DataSkills, aiData.DataSkills);
        }

        private void Show(Enums.Team team)
        {
            if (team != Enums.Team.Player)
                return;

            SetBodyActive(true);
            MoveBody();
        }

        private void MoveBody()
        {
            if (_injector == null)
                return;

            Vector3 offset = new Vector3(0, 3.5f, -2);
            _body.transform.position = _injector.transform.position + offset;
        }

        private void SetBodyActive(bool active)
        {
            _body.SetActive(active);
        }
    }
}
