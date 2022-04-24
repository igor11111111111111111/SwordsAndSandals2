using UnityEngine;

namespace SwordsAndSandals
{
    public class FallenArmor : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Rigidbody2D _rigidbody;

        public void Init(SpriteRenderer spriteRenderer)
        {
            _spriteRenderer.sprite = spriteRenderer.sprite;
            _spriteRenderer.sortingOrder = 80;
            transform.localScale = spriteRenderer.transform.lossyScale;
            transform.rotation = spriteRenderer.transform.rotation;
            gameObject.AddComponent<PolygonCollider2D>();
            _rigidbody.AddTorque(Random.Range(-360, 360), ForceMode2D.Impulse);
            _rigidbody.AddForce(new Vector2(Random.Range(-4, 4), Random.Range(0, 4)), ForceMode2D.Impulse);

            Invoke(nameof(StopRotation), 0.1f);
            Invoke(nameof(MoveToBG), 10);
        }

        private void MoveToBG()
        {
            _spriteRenderer.sortingOrder = -10;
        }

        private void StopRotation()
        {
            _rigidbody.angularVelocity = 0;
        }
    }
}
