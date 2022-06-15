using UnityEngine;
using SwordsAndSandals;

namespace SwordsAndSandals.OutScene
{
    public class PlayerSpawner : MonoBehaviour
    {
        [SerializeField] PlayerInjector _playerPrefab;

        public PlayerInjector Init(PlayerData playerData, Vector3 position, float sceneScale)
        {
            var injector = Instantiate(_playerPrefab, position, Quaternion.identity);
            injector.Init(playerData);
            injector.transform.localScale = new Vector3(sceneScale, sceneScale, 1);
            injector.GetComponent<Rigidbody2D>().simulated = false;

            return injector;
        }

        public PlayerInjector Init(PlayerData playerData, Vector3 position, Vector3 sceneScale)
        {
            var injector = Instantiate(_playerPrefab, position, Quaternion.identity);
            injector.Init(playerData);
            injector.transform.localScale = sceneScale;
            injector.GetComponent<Rigidbody2D>().simulated = false;

            return injector;
        }
    }
}
