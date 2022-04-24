using UnityEngine;

namespace SwordsAndSandals.Arena
{
    public class ArenaPanel : MonoBehaviour
    {
        [SerializeField] private GameObject _body;
        [SerializeField] public FeauturePanel _playerPanel;
        [SerializeField] public FeauturePanel _aiPanel;

        public void Init()
        {
            Show(false);
        }

        public void InitPlayers(PlayerData playerData, PlayerData aiData)
        {
            _playerPanel.Init(playerData);
            _aiPanel.Init(aiData);
        }

        public void Show(bool active)
        {
            _body.SetActive(active);
        }
    }
}
