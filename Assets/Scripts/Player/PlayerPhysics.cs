using SwordsAndSandals.Arena;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwordsAndSandals
{
    public class PlayerPhysics : MonoBehaviour
    {
        public Action OnEndAction;

        private Rigidbody2D _rigidbody;
        private PlayerController _controller;
        private PlayerData _data;
        private PlayerGroundCheck _groundCheck;
        private PlayerInjector _injector;

        public void Init(PlayerInjector injector, Rigidbody2D rigidbody, PlayerController controller, PlayerData data, PlayerGroundCheck groundCheck)
        {
            _rigidbody = rigidbody;
            _controller = controller;
            _data = data;
            _groundCheck = groundCheck;
            _injector = injector;

            _controller.OnAttack += Attack;
            _controller.OnMove += Move;
            _controller.OnJump += Jump;
        }

        private void OnDestroy()
        {
            if (_controller == null)
                return;

            _controller.OnAttack -= Attack;
            _controller.OnMove -= Move;
            _controller.OnJump -= Jump;
        }

        private void Attack(Enums.AttackType attackType)
        {
            if (attackType != Enums.AttackType.Charge)
                return;

            int dir = _injector.Direction == Enums.Direction.Left ? -1 : 1;
            var force = new Vector2(1 * dir, 1) * PlayerData.JUMP_FORCE * _data.DataSkills.Get<Agility>().JumpCoeff;

            _rigidbody.AddForce(force, ForceMode2D.Impulse);
        }

        private void Move(Enums.Direction direction)
        {
            if (direction != Enums.Direction.None)
                StartCoroutine(Move2(direction));
        }

        private IEnumerator Move2(Enums.Direction direction)
        {
            int sign = 0;

            if (direction == Enums.Direction.Right)
            {
                sign = 1;
            }
            else if (direction == Enums.Direction.Left)
            {
                sign = -1;
            }

            var target = new Vector3
            (
                transform.position.x + PlayerData.MOVE_DISTANCE * sign * _data.DataSkills.Get<Agility>().MoveDistanceCoeff,
                transform.position.y,
                transform.position.z
            );

            float speed = 0.02f;
            while ((target.x - transform.position.x) * sign > 0)
            {
                transform.position = Vector3.MoveTowards(transform.position, target, speed);
                yield return new WaitForEndOfFrame();
            }

            OnEndAction?.Invoke();
        }

        private void Jump(Enums.Direction direction)
        {
            if (direction != Enums.Direction.None)
                StartCoroutine(Jump2(direction));
        }

        private IEnumerator Jump2(Enums.Direction direction)
        {

            int sign = 0;

            if (direction == Enums.Direction.Right)
            {
                sign = 1;
            }
            else if (direction == Enums.Direction.Left)
            {
                sign = -1;
            }

            var force = new Vector2(1 * sign, 2) * PlayerData.JUMP_FORCE * _data.DataSkills.Get<Agility>().JumpCoeff;

            _rigidbody.AddForce(force, ForceMode2D.Impulse);

            while (!_groundCheck.IsGrounded)
            {
                yield return new WaitForEndOfFrame();
            }

            OnEndAction?.Invoke();
        }
    }
}
