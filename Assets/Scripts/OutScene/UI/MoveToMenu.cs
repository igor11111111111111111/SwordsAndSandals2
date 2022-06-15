using UnityEngine;
using UnityEngine.UI;

namespace SwordsAndSandals.OutScene
{
    public class MoveToMenu : MonoBehaviour
    {
        [SerializeField] private Button _button;

        private void Awake()
        {
            _button.onClick.AddListener(() =>
            new SceneChanger().MoveTo(Enums.Scene.Menu));
        }
    }
}
