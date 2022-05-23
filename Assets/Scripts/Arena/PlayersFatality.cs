using UnityEngine;

namespace SwordsAndSandals.Arena
{ 
    public class PlayersFatality : MonoBehaviour
    {
        [SerializeField] private PlayerInjector _attacker;
        [SerializeField] private PlayerInjector _defender;
        [SerializeField] private Animator _animator;

        public void Init(PlayerInjector attacker, PlayerInjector defender, Camera camera)
        {
            camera.orthographicSize = 3;
            SetupPlayer(_attacker, attacker, Enums.Direction.Left);
            SetupPlayer(_defender, defender, Enums.Direction.Right);

            var index = Random.Range(1, 4);
            _animator.SetTrigger("OnFatality");
            _animator.SetInteger("FatalityIndex", index);
        }

        private void SetupPlayer(PlayerInjector newInjector, PlayerInjector oldInjector, Enums.Direction direction)
        {
            newInjector.InitData(oldInjector.Data);

            int sign = direction == Enums.Direction.Left ? -1 : 1;
            var offset = new Vector3(1.7f, 0, 0);
            newInjector.transform.localPosition =
            new Vector3(sign * offset.x, 
            oldInjector.transform.localPosition.y,
            oldInjector.transform.localPosition.z);

            newInjector.transform.localRotation = oldInjector.transform.localRotation;
            newInjector.transform.localScale = oldInjector.transform.localScale;

            Destroy(oldInjector.gameObject);
        }
    }
}
