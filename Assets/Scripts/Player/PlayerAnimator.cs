using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwordsAndSandals
{
    public class PlayerAnimator
    {
        private Animator _animator;
        private PlayerController _controller;

        public PlayerAnimator(Animator animator, PlayerController controller)
        {
            _animator = animator;
            _controller = controller;

            _controller.OnMove += Move;
            _controller.OnJump += Jump;
            _controller.OnPunch += Punch;
            _controller.OnSleep += Sleep;
            _controller.OnRage += Rage;
            _controller.OnBlock += Block;
            _controller.OnWin += Win;
            _controller.OnLose += Lose;
            _controller.OnDance += Dance;
            _controller.OnAttack += Attack;
            _controller.OnSuperAttack += SuperAttack;
        }

        ~ PlayerAnimator()
        {
            _controller.OnMove -= Move;
            _controller.OnJump -= Jump;
            _controller.OnPunch -= Punch;
            _controller.OnSleep -= Sleep;
            _controller.OnRage -= Rage;
            _controller.OnBlock -= Block;
            _controller.OnWin -= Win;
            _controller.OnLose -= Lose;
            _controller.OnDance -= Dance;
            _controller.OnAttack -= Attack;
            _controller.OnSuperAttack -= SuperAttack;
        }

        private void Move(Enums.Direction direction)
        {
            if(direction == Enums.Direction.None)
            {
                _animator.SetBool("IsMove", false);
            }
            else
            {
                _animator.SetBool("IsMove", true);
            }
        }

        private void Jump(Enums.Direction _)
        {
            _animator.SetTrigger("OnJump");
        }

        private void Punch()
        {
            _animator.SetTrigger("OnPunch");
        }

        private void Sleep()
        {
            _animator.SetTrigger("OnSleep");
        }

        private void Rage()
        {
            _animator.SetTrigger("OnRage");
        }

        private void Block()
        {
            _animator.SetTrigger("OnBlock");
        }

        private void Lose()
        {
            _animator.SetTrigger("OnLose");
        }

        private void Win()
        {
            _animator.SetTrigger("OnWin");
        }

        private void Dance()
        {
            _animator.SetTrigger("OnDance");
        }

        private void Attack(Enums.AttackType type)
        {
            _animator.SetTrigger("OnAttack");
            _animator.SetInteger("AttackIndex", ((int)type));
        }

        private void SuperAttack(Enums.SuperAttackState state)
        {
            _animator.SetTrigger("OnSuperAttack");
            _animator.SetInteger("SuperAttackIndex", ((int)state));
        }
    }
}
