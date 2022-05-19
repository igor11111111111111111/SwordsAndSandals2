using SwordsAndSandals.OutScene;
using UnityEngine;
using UnityEngine.UI;

namespace SwordsAndSandals.Street
{
    public class BuildingPanel : MonoBehaviour
    {
        [SerializeField] private Button _button;

        public void Init(Enums.Scene scene)
        {
            _button.onClick.AddListener(() =>
            {
                new SceneChanger().MoveTo(scene);
            });
        }
    }
}
