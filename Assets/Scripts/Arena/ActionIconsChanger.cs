using System;
using System.Collections.Generic;
using UnityEngine;

namespace SwordsAndSandals.Arena
{
    public class ActionIconsChanger
    { 
        private Sprite[] _sprites;
        private List<ActionIcon> _actionIcons;

        public ActionIconsChanger(List<ActionIcon> actionIcons, PlayerController controller)
        {
            _actionIcons = actionIcons;

            _sprites = Resources.LoadAll<Sprite>("");

            SetFixedIcons();
            controller.OnInBattle += SetIcons;
        }

        private void SetFixedIcons()
        {
            _actionIcons[0].SetSprite(Get(Enums.CurrentState.Jump), true);
            _actionIcons[1].SetSprite(Get(Enums.CurrentState.Move), true);
            _actionIcons[3].SetSprite(Get(Enums.CurrentState.Dance), false);
            _actionIcons[7].SetSprite(Get(Enums.CurrentState.SuperAttack1), false);
        }

        private void SetIcons(bool inBattle)
        {
            if (inBattle)
            {
                _actionIcons[2].SetSprite(Get(Enums.CurrentState.Punch), false);
                _actionIcons[4].SetSprite(Get(Enums.CurrentState.HardAttack), false);
                _actionIcons[5].SetSprite(Get(Enums.CurrentState.MediumAttack), false);
                _actionIcons[6].SetSprite(Get(Enums.CurrentState.WeakAttack), false);
            }
            else
            {
                _actionIcons[2].SetSprite(Get(Enums.CurrentState.Rage), false);
                _actionIcons[4].SetSprite(Get(Enums.CurrentState.Jump), false);
                _actionIcons[5].SetSprite(Get(Enums.CurrentState.Move), false);
                _actionIcons[6].SetSprite(Get(Enums.CurrentState.Charge), false);
            }
        }

        private Sprite Get(Enums.CurrentState state)
        {
            return Array.Find(_sprites, c => c.name == state.ToString());
        }
    }
}
