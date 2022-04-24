using CustomJson;
using UnityEngine;
using UnityEngine.UI;

namespace SwordsAndSandals.PreArena
{
    public class PreArenaInit : MonoBehaviour
    {
        [SerializeField] private PreArena _preArena;
        [SerializeField] private MenuPanel _menuPanel;
        [SerializeField] private Button _duel;
        [SerializeField] private Button _tournament;

        private void Awake()
        {
            var playerData = new Json().Load<PlayerData>(Enums.SaveFilename.Player);

            _preArena.Init(playerData);
            _menuPanel.Init(_duel, _tournament);
        }
    }
}
