using System.Threading.Tasks;
using UnityEngine;

namespace SwordsAndSandals
{
    public class FallenArmor : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Rigidbody2D _rigidbody;
         
        public async void Init(SpriteRenderer spriteRenderer, Enums.Team team)
        {
            _spriteRenderer.sprite = spriteRenderer.sprite;
            _spriteRenderer.sortingLayerName = team.ToString();
            _spriteRenderer.sortingOrder = 80;
            transform.localScale = spriteRenderer.transform.lossyScale;
            transform.rotation = spriteRenderer.transform.rotation;
            gameObject.AddComponent<PolygonCollider2D>();
            _rigidbody.AddTorque(Random.Range(-360, 360), ForceMode2D.Impulse);
            _rigidbody.AddForce(new Vector2(Random.Range(-4, 4), Random.Range(0, 4)), ForceMode2D.Impulse);

            await Task.Delay(300);
            StopRotation();
            await Task.Delay(9000);
            MoveToBG();
        }

        private void MoveToBG()
        {
            if (_spriteRenderer != null)
                _spriteRenderer.sortingOrder = -10;
        }

        private void StopRotation()
        {
            if (_rigidbody != null)
                _rigidbody.angularVelocity = 0;
        }
    }
}
