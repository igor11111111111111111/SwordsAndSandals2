using System;
using System.Collections.Generic;
using UnityEngine;

namespace SwordsAndSandals.Arena
{
    public class ActionIconsChanger
    { 
        private Sprite[] _sprites;
        private List<ActionIcon> _actionIcons;
        private PlayerDataSkills _playerDataSkills;
        private PlayerDataSkills _aiDataSkills;

        public ActionIconsChanger(List<ActionIcon> actionIcons, PlayerController controller, PlayerDataSkills playerDataSkills, PlayerDataSkills aiDataSkills)
        {
            _actionIcons = actionIcons;
            _playerDataSkills = playerDataSkills;
            _aiDataSkills = aiDataSkills;
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
        // clean some shit later
        private void SetIcons(bool inBattle)
        {
            if (inBattle)
            {
                _actionIcons[2].SetSprite(Get(Enums.CurrentState.Punch), false);
                _actionIcons[4].SetSprite(Get(Enums.CurrentState.HardAttack), false);
                _actionIcons[5].SetSprite(Get(Enums.CurrentState.MediumAttack), false);
                _actionIcons[6].SetSprite(Get(Enums.CurrentState.WeakAttack), false);

                _actionIcons[4].SetChance(GetChance(Enums.AttackType.HardAttack), true);
                _actionIcons[5].SetChance(GetChance(Enums.AttackType.MediumAttack), true);
                _actionIcons[6].SetChance(GetChance(Enums.AttackType.WeakAttack), true);
            }
            else
            {
                _actionIcons[2].SetSprite(Get(Enums.CurrentState.Rage), false);
                _actionIcons[4].SetSprite(Get(Enums.CurrentState.Jump), false);
                _actionIcons[5].SetSprite(Get(Enums.CurrentState.Move), false);
                _actionIcons[6].SetSprite(Get(Enums.CurrentState.Charge), false);

                _actionIcons[4].SetChance(GetChance(Enums.AttackType.HardAttack), false);
                _actionIcons[5].SetChance(GetChance(Enums.AttackType.MediumAttack), false);
                _actionIcons[6].SetChance(GetChance(Enums.AttackType.Charge), true);
            }
        }

        private Sprite Get(Enums.CurrentState state)
        {
            return Array.Find(_sprites, c => c.name == state.ToString());
        }

        private int GetChance(Enums.AttackType attackType)
        {
            var playerAttackChance = _playerDataSkills.Get<Attack>().GetHitChance(attackType);
            var enemyDefenceChance = _aiDataSkills.Get<Defence>().GetDodgeChance(attackType);
            var totalChance = Mathf.Clamp(playerAttackChance - enemyDefenceChance, 1, 99);
            return totalChance;
        }
    }
}
