using CustomJson;
using SwordsAndSandals.OutScene;
using UnityEngine;
using UnityEngine.UI;

namespace SwordsAndSandals.PreArena
{
    public class PreArenaInit : MonoBehaviour
    {
        [SerializeField] private MenuPanel _menuPanel;
        [SerializeField] private MoneyInfo _moneyInfo;
        [SerializeField] private Button _moveToStreet;

        private void Awake()
        {
            var json = new Json();
            var playerData = json.Load<PlayerData>();
            var tournamentData = json.Load<TournamentData>();

            _menuPanel.Init(tournamentData, playerData);
            _moneyInfo.Init(playerData.Money);

            _moveToStreet.onClick.AddListener
                (
                () => new SceneChanger().MoveTo(Enums.Scene.Street)
                );
        }
    }
}
