using SwordsAndSandals.OutScene;
using UnityEngine;
using UnityEngine.UI;

namespace SwordsAndSandals.PreArena
{
    public class EnterToDuelButton : MonoBehaviour
    {
        [SerializeField] private GameObject _body;
        [SerializeField] private Button _button;

        public void Init(bool active)
        {
            _body.SetActive(active);

            if (active)
            {
                _button.onClick.AddListener(() =>
                    new SceneChanger().MoveTo(Enums.Scene.Arena));
            }
        }
    }
}
