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
        public Animator Animator => _animator;
        public PlayerData Data => _data;
        private PlayerData _data;
        public PlayerController Controller => _controller;
        private PlayerController _controller;
        public ClothChanger ClothChanger => _clothChanger;
        private ClothChanger _clothChanger;
        public Enums.Direction Direction;
        private PlayerSortingLayer _sortingLayer;

        public void InitData(PlayerData playerData)
        {
            _data = playerData;
            var paintableParts = GetComponent<PlayerPaintableParts>();
            _clothChanger = GetComponent<ClothChanger>();
            _clothChanger.Init(playerData);
            new PlayerSetup(playerData, paintableParts, _clothChanger);
            _sortingLayer = GetComponent<PlayerSortingLayer>();
        }

        public void InitPlayerArenaInput(PlayerInputUI inputUI, TurnLogic turnLogic, ArenaHandler arenaHandler, PlayerData aiData)
        {
            var rigidBody = GetComponent<Rigidbody2D>();
            var physics = GetComponent<PlayerPhysics>();

            _data.Team = Enums.Team.Player;
            PlayerAnimationClips animationClips = new PlayerAnimationClips();
            PlayerInput input = new PlayerInput(this, turnLogic, arenaHandler);
            inputUI.Init(this, turnLogic);
            _controller = new PlayerController(inputUI, input, physics, _data, animationClips);
            new PlayerAnimator(_animator, _controller);

            _groundCheck.Init(_controller);
            physics.Init(this, rigidBody, _controller, _data, _groundCheck);
            _sortingLayer.Set(_data.Team);

            inputUI.LateInit(_controller, aiData);
        }

        public void InitAIArenaInput(TurnLogic turnLogic, ArenaHandler arenaHandler)
        { 
            var rigidBody = GetComponent<Rigidbody2D>();
            var physics = GetComponent<PlayerPhysics>();

            _data.Team = Enums.Team.AI;
            PlayerAnimationClips animationClips = new PlayerAnimationClips();

            var aiInput = new AiInput();
            aiInput.Init(this, turnLogic, arenaHandler);
            _controller = new PlayerController(aiInput, physics, _data, animationClips);
            new PlayerAnimator(_animator, _controller);

            _groundCheck.Init(_controller);
            physics.Init(this, rigidBody, _controller, _data, _groundCheck);
            _sortingLayer.Set(_data.Team);
        }

        public void InitAttackHandler(AttackHandler attackHandler)
        {
            _controller.Init(attackHandler);
            _clothChanger.Init(attackHandler);
        }
    }
}
