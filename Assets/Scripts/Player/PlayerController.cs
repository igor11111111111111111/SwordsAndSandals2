using SwordsAndSandals.Arena;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace SwordsAndSandals
{
    public class PlayerController 
    {
        public Action<Enums.AttackType> OnAttack;
        public Action<Enums.Direction> OnMove;
        public Action<Enums.Direction> OnJump;
        public Action OnPunch;
        public Action OnSleep;
        public Action OnRage; 
        public Action OnBlock;
        public Action OnLose;
        public Action OnWin;
        public Action OnDance;
        public Action<Enums.SuperAttackState> OnSuperAttack;

        public Action<Enums.AttackType> OnTakeDamage;

        public Action OnStartAction;
        public Action OnEndAction;

        public Action<bool> OnInBattle;

        private PlayerInput _input;
        private PlayerPhysics _physics;
        private PlayerData _data;
        private PlayerAnimationClips _animationClips;

        private Enums.CurrentState _currentState;

        public PlayerController(PlayerInput input, PlayerPhysics physics, PlayerData data, PlayerAnimationClips animationClips)
        {
            _input = input;
            _physics = physics;
            _data = data;
            _animationClips = animationClips;
            
            _input.ActionIcons[0].OnClicked += Button0;
            _input.ActionIcons[1].OnClicked += Button1;
            _input.ActionIcons[2].OnClicked += Button2;
            _input.ActionIcons[3].OnClicked += Button3;
            _input.ActionIcons[4].OnClicked += Button4;
            _input.ActionIcons[5].OnClicked += Button5;
            _input.ActionIcons[6].OnClicked += Button6;
            _input.ActionIcons[7].OnClicked += Button7;

            _input.OnInBattle += (b) =>
            {
                _data.InBattle = b;
                OnInBattle?.Invoke(b);
            };

            _physics.OnEndAction += EndAction;
        }

        public void Init(AttackHandler attackHandler)
        {
            attackHandler.OnBlock += () => OnBlock?.Invoke();
            attackHandler.OnLose += () => OnLose?.Invoke();
        }

        public PlayerController(AiInput input, PlayerPhysics physics, PlayerData data, PlayerAnimationClips animationClips)
        {
            _physics = physics;
            _data = data;
            _animationClips = animationClips;

            input.Actions[0] += Button0;
            input.Actions[1] += Button1;
            input.Actions[2] += Button2;
            input.Actions[3] += Button3;
            input.Actions[4] += Button4;
            input.Actions[5] += Button5;
            input.Actions[6] += Button6;
            input.Actions[7] += Button7;

            input.OnInBattle += (b) =>
            {
                _data.InBattle = b;
                OnInBattle?.Invoke(b);
            };

            _physics.OnEndAction += EndAction;
        }

        public void LateInit()
        {
            OnInBattle?.Invoke(true);
        }

        private void Button0()
        {
            OnStartAction?.Invoke();
            OnJump?.Invoke(Enums.Direction.Left);
            _currentState = Enums.CurrentState.Jump;
        }

        private void Button1()
        {
            OnStartAction?.Invoke();
            OnMove?.Invoke(Enums.Direction.Left);
            _currentState = Enums.CurrentState.Move;
        }
        
        private async void Button2()
        {
            OnStartAction?.Invoke();

            if (_data.InBattle)
            {
                OnPunch?.Invoke();
                _currentState = Enums.CurrentState.Punch;
            }
            else
            {
                OnRage?.Invoke();
                _currentState = Enums.CurrentState.Rage;
                // low stamina
                // sleep
            }

            await _animationClips.EndClip(_currentState);
            OnEndAction?.Invoke();
        }

        private async void Button3()
        {
            OnStartAction?.Invoke();
            OnDance?.Invoke();

            _currentState = Enums.CurrentState.Dance;

            await _animationClips.EndClip(_currentState);
            OnEndAction?.Invoke();
        }

        private async void Button4()
        {
            OnStartAction?.Invoke();

            if (_data.InBattle)
            {
                OnAttack?.Invoke(Enums.AttackType.HardAttack);
                _currentState = Enums.CurrentState.HardAttack;

                await _animationClips.EndClip(_currentState);
                OnEndAction?.Invoke();
            }
            else
            {
                OnJump?.Invoke(Enums.Direction.Right);
                _currentState = Enums.CurrentState.Jump;
            }
        }

        private async void Button5()
        {
            OnStartAction?.Invoke();

            if (_data.InBattle)
            {
                OnAttack?.Invoke(Enums.AttackType.MediumAttack);
                _currentState = Enums.CurrentState.MediumAttack;

                await _animationClips.EndClip(_currentState);
                OnEndAction?.Invoke();
            }
            else
            {
                OnMove?.Invoke(Enums.Direction.Right);
                _currentState = Enums.CurrentState.Move;
            }
        }

        private async void Button6()
        {
            OnStartAction?.Invoke();

            if (_data.InBattle)
            {
                OnAttack?.Invoke(Enums.AttackType.WeakAttack);
                _currentState = Enums.CurrentState.WeakAttack;
            }
            else
            {
                OnAttack?.Invoke(Enums.AttackType.Charge);
                _currentState = Enums.CurrentState.Charge;
            }

            await _animationClips.EndClip(_currentState);
            OnEndAction?.Invoke();
        }

        private async void Button7()
        {
            OnStartAction?.Invoke();

            if(_currentState == Enums.CurrentState.SuperAttack1)
            {
                OnSuperAttack?.Invoke(Enums.SuperAttackState.SuperAttack2);
                _currentState = Enums.CurrentState.SuperAttack2;
            }

            else if (_currentState == Enums.CurrentState.SuperAttack2)
            {
                OnSuperAttack?.Invoke(Enums.SuperAttackState.SuperAttack3);
                _currentState = Enums.CurrentState.SuperAttack3;
            }
            else
            {
                OnSuperAttack?.Invoke(Enums.SuperAttackState.SuperAttack1);
                _currentState = Enums.CurrentState.SuperAttack1;
            }

            await _animationClips.EndClip(_currentState);
            OnEndAction?.Invoke();
        }

        private void EndAction()
        {
            OnEndAction?.Invoke();

            if (_currentState == Enums.CurrentState.Move)
            {
                OnMove?.Invoke(Enums.Direction.None);
            }
        }
    }
}
