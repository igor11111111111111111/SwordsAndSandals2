using SwordsAndSandals.OutScene;
using UnityEngine;
using UnityEngine.UI;

namespace SwordsAndSandals.Street
{
    public class ArmoryPanel : MonoBehaviour
    {
        [SerializeField] private Button _button;

        private void Awake()
        {
            _button.onClick.AddListener(() =>
            {
                new SceneChanger().MoveTo(Enums.Scene.ArmorShop);
            });
        }
    }
}
