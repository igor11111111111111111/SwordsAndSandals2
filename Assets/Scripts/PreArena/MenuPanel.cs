using SwordsAndSandals.OutScene;
using UnityEngine;
using UnityEngine.UI;

namespace SwordsAndSandals.PreArena
{
    public class MenuPanel : MonoBehaviour
    {
        public void Init(Button duel, Button tournament)
        {
            duel.onClick.AddListener(Duel);
            tournament.onClick.AddListener(Tournament);
        }

        private void Duel()
        {
            new SceneChanger().MoveTo(Enums.Scene.Arena);
        }

        private void Tournament()
        {
            //new SceneChanger().MoveTo(Enums.Scene.Arena);
        }
    }
}
