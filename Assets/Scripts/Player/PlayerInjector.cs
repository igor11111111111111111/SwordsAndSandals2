using SwordsAndSandals.Arena;
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
        private PlayerSortingLayer _sortingLayer;

        public void Init(PlayerData playerData)
        {
            _data = playerData;
            var paintableParts = GetComponent<PlayerPaintableParts>();
            _clothChanger = GetComponent<ClothChanger>();
            _clothChanger.Init(playerData);
            new PlayerSetup(playerData, paintableParts, _clothChanger);
            _sortingLayer = GetComponent<PlayerSortingLayer>();
        }

        public void Init(IUseInput aiInput)
        {
            var rigidBody = GetComponent<Rigidbody2D>();
            var physics = GetComponent<PlayerPhysics>();
            PlayerAnimationClips animationClips = new PlayerAnimationClips();
            _controller = new PlayerController(aiInput, physics, _data, animationClips);
            new PlayerAnimator(_animator, _controller);
            _groundCheck.Init(_controller);
            physics.Init(this, rigidBody, _controller, _data, _groundCheck);
            _sortingLayer.Set(_data.Team);
        }

        public void Init(AttackHandler attackHandler)
        {
            _controller.Init(attackHandler);
            _clothChanger.Init(attackHandler);
        }
    }
}
