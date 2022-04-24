using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwordsAndSandals
{
    public class PlayerGroundCheck : MonoBehaviour
    {
        public bool IsGrounded => _isGrounded;
        private bool _isGrounded;

        private PlayerController _controller;

        public void Init(PlayerController controller)
        {
            _controller = controller;

            _controller.OnJump += Jump;
        }

        private void OnDestroy()
        {
            if (_controller == null)
                return;

            _controller.OnJump -= Jump;
        }

        private void Jump(Enums.Direction _)
        {
            _isGrounded = false;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.TryGetComponent(out Ground ground))
            {
                _isGrounded = true;
            }
        }
    }
}
