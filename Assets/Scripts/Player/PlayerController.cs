using SwordsAndSandals.Arena;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace SwordsAndSandals
{
    public class PlayerController : IUseController
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

        public Action<Enums.CurrentState> OnStartAction { get; set; }

        public Action OnEndAction; 

        public Action<bool> OnInBattle;

        private PlayerPhysics _physics;
        private PlayerData _data;
        private PlayerAnimationClips _animationClips;

        private Enums.CurrentState _currentState;

        public PlayerController(IUseInput input, PlayerPhysics physics, PlayerData data, PlayerAnimationClips animationClips)
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
            input.Actions[8] += Button8;

            input.OnInBattle += (b) =>
            {
                _data.InBattle = b;
                OnInBattle?.Invoke(b);
            }; 

            _physics.OnEndAction += EndAction;
        }

        public void Init(AttackHandler attackHandler)
        {
            attackHandler.OnBlock += (damage, pos) => OnBlock?.Invoke();
            attackHandler.OnWin += () => OnWin?.Invoke();
            attackHandler.OnLose += () => OnLose?.Invoke();

            OnInBattle?.Invoke(true);
        }

        private void Button0()
        {
            _currentState = Enums.CurrentState.Jump;
            OnStartAction?.Invoke(_currentState);
            OnJump?.Invoke(Enums.Direction.Left);
        }

        private void Button1()
        {
            _currentState = Enums.CurrentState.Move;
            OnStartAction?.Invoke(_currentState);
            OnMove?.Invoke(Enums.Direction.Left);
        }
        
        private async void Button2()
        {
            if (_data.InBattle)
            {
                OnPunch?.Invoke();
                _currentState = Enums.CurrentState.Punch;
            }
            else
            {
                OnRage?.Invoke();
                _currentState = Enums.CurrentState.Rage;
            }

            OnStartAction?.Invoke(_currentState);

            await _animationClips.EndClip(_currentState);
            OnEndAction?.Invoke();
        }

        private async void Button3()
        {
            _currentState = Enums.CurrentState.Sleep;
            OnStartAction?.Invoke(_currentState);
            OnSleep?.Invoke();

            await _animationClips.EndClip(_currentState);
            OnEndAction?.Invoke();
        }

        private async void Button4()
        {
            _currentState = Enums.CurrentState.Dance;
            OnStartAction?.Invoke(_currentState);
            OnDance?.Invoke();

            await _animationClips.EndClip(_currentState);
            OnEndAction?.Invoke();
        }

        private async void Button5()
        {
            if (_data.InBattle)
            {
                _currentState = Enums.CurrentState.HardAttack;
                OnAttack?.Invoke(Enums.AttackType.HardAttack);
                OnStartAction?.Invoke(_currentState);

                await _animationClips.EndClip(_currentState);
                OnEndAction?.Invoke();
            }
            else
            {
                _currentState = Enums.CurrentState.Jump;
                OnJump?.Invoke(Enums.Direction.Right);
                OnStartAction?.Invoke(_currentState);
            }
        }

        private async void Button6()
        {
            if (_data.InBattle)
            {
                _currentState = Enums.CurrentState.MediumAttack;
                OnAttack?.Invoke(Enums.AttackType.MediumAttack);
                OnStartAction?.Invoke(_currentState);

                await _animationClips.EndClip(_currentState);
                OnEndAction?.Invoke();
            }
            else
            {
                _currentState = Enums.CurrentState.Move;
                OnMove?.Invoke(Enums.Direction.Right);
                OnStartAction?.Invoke(_currentState);
            }
        }

        private async void Button7()
        {
            if (_data.InBattle)
            {
                _currentState = Enums.CurrentState.WeakAttack;
                OnAttack?.Invoke(Enums.AttackType.WeakAttack);
                OnStartAction?.Invoke(_currentState);
            }
            else
            {
                _currentState = Enums.CurrentState.Charge;
                OnAttack?.Invoke(Enums.AttackType.Charge);
                OnStartAction?.Invoke(_currentState);
            }

            await _animationClips.EndClip(_currentState);
            OnEndAction?.Invoke();
        }

        private async void Button8()
        {
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

            OnStartAction?.Invoke(_currentState);

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
