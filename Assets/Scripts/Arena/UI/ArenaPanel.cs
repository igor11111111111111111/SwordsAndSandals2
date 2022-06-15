using UnityEngine;

namespace SwordsAndSandals.Arena
{
    public class ArenaPanel : MonoBehaviour
    {
        [SerializeField] private GameObject _body;
        [SerializeField] private FeauturePanel _playerPanel;
        [SerializeField] private FeauturePanel _aiPanel;
        [SerializeField] private StatsPanel _statsPanel;

        public void Init(FatalityPanel fatalityPanel)
        {
            Show(false);

            fatalityPanel.OnClicked += () => { Show(false); };
        }

        public void Init(PlayerData playerData, PlayerData aiData, AudienceMoodData audienceMoodData)
        { 
            _playerPanel.Init(playerData);
            _aiPanel.Init(aiData);
            _statsPanel.Init(audienceMoodData);
        }

        public void Show(bool active)
        {
            _body.SetActive(active);
        }
    }
}
