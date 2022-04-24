using SwordsAndSandals.Arena;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace SwordsAndSandals
{
    public class PlayerInjector : MonoBehaviour
    { 
        [SerializeField] private PlayerGroundCheck _groundCheck;
        [SerializeField] private Animator _animator;
        public PlayerData Data => _data;
        private PlayerData _data;
        public PlayerController Controller => _controller;
        private PlayerController _controller;
        public ClothChanger ClothChanger => _clothChanger;
        private ClothChanger _clothChanger;
        public Enums.Direction Direction;

        public void InitData(PlayerData playerData)
        {
            _data = playerData;
            var paintableParts = GetComponent<PlayerPaintableParts>();
            _clothChanger = GetComponent<ClothChanger>();

            new PlayerSetup(playerData, paintableParts, _clothChanger);
        }

        public void InitPlayerArenaInput(PlayerInput playerInput, TurnLogic turnLogic, ArenaHandler arenaHandler)
        {
            var rigidBody = GetComponent<Rigidbody2D>();
            var physics = GetComponent<PlayerPhysics>();

            PlayerAnimationClips animationClips = new PlayerAnimationClips();
            playerInput.Init(this);
            _controller = new PlayerController(playerInput, physics, _data, animationClips);
            PlayerAnimator playerAnimator = new PlayerAnimator(_animator, _controller);

            _groundCheck.Init(_controller);
            physics.Init(this, rigidBody, _controller, _data, _groundCheck);


            playerInput.LateInit(_controller, turnLogic, arenaHandler);
            _controller.LateInit();
        }

        public void InitAIArenaInput(AiInput aiInput, TurnLogic turnLogic, ArenaHandler arenaHandler)
        {
            var rigidBody = GetComponent<Rigidbody2D>();
            var physics = GetComponent<PlayerPhysics>();

            PlayerAnimationClips animationClips = new PlayerAnimationClips();

            aiInput.Init(this, turnLogic, arenaHandler);
            _controller = new PlayerController(aiInput, physics, _data, animationClips);
            PlayerAnimator playerAnimator = new PlayerAnimator(_animator, _controller);

            _groundCheck.Init(_controller);
            physics.Init(this, rigidBody, _controller, _data, _groundCheck);

            _controller.LateInit();
        }

        public void InitAttackHandler(AttackHandler attackHandler)
        {
            _controller.Init(attackHandler);
        }
    }
}
