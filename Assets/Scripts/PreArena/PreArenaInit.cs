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
        [SerializeField] private Button _duel;
        [SerializeField] private Button _tournament;
        [SerializeField] private Button _moveToStreet;

        private void Awake()
        {
            var playerData = new Json().Load<PlayerData>(Enums.SaveFilename.Player);

            _menuPanel.Init(_duel, _tournament);
            _moneyInfo.Init(playerData.Money);

            _moveToStreet.onClick.AddListener
                (
                () => new SceneChanger().MoveTo(Enums.Scene.Street)
                );
        }
    }
}
