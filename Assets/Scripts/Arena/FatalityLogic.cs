using UnityEngine;

namespace SwordsAndSandals.Arena
{
    public class FatalityLogic : MonoBehaviour
    {
        public FatalityPanel Panel => _panel;
        private FatalityPanel _panel;

        public void Init(PlayerInjector attacker, PlayerInjector defender, PlayersFatality fatalityPrefab, FatalityPanel fatalityPanel, Camera camera)
        {
            _panel = fatalityPanel;
            _panel.Init();

            _panel.OnClicked += () =>
            {
                // затемнение экрана ит д 
                var fatality = Instantiate(fatalityPrefab);
                fatality.Init(attacker, defender, camera);
            };
        }

        public void Init(EndBattleHandler endBattleHandler)
        {
            endBattleHandler.OnEndBattle += EndBattle;
        }

        private void EndBattle(EndBattleHandler.Info info)
        {
            if (info.WinningTeam == Enums.Team.Player)
            {
                _panel.Show();
            }
            else
            {
                // 50 на 50 помиловние или фаталити от бота
            }
        }
    }
}
