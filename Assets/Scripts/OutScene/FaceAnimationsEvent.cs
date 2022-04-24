using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;

namespace SwordsAndSandals
{
    public class FaceAnimationsEvent : MonoBehaviour
    {
        [SerializeField] private SpriteResolver _spriteResolver;

        public void AnimEventHead(string label)
        {
            _spriteResolver.SetCategoryAndLabel("Face", label);
        }
    }
}
