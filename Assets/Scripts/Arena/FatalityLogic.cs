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
            endBattleHandler.OnEndBattle += (info) =>
            {
                _panel.Show();
            };
        }
    }
}
