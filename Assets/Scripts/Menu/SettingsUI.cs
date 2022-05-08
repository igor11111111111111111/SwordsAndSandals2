using UnityEngine;
using UnityEngine.UI;

namespace SwordsAndSandals.Menu
{
    public class SettingsUI : MonoBehaviour
    {
        [SerializeField] private GameObject _body;
        [SerializeField] private Button _exit;

        public void Init()
        {
            _exit.onClick.AddListener(() => Activate(false));
        }

        public void Activate(bool active)
        {
            _body.SetActive(active);
        }
    }
}
