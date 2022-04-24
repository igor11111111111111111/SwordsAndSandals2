using SwordsAndSandals.OutScene;
using UnityEngine;
using UnityEngine.UI;

namespace SwordsAndSandals.PreArena
{
    public class PreArena : MonoBehaviour
    {
        [SerializeField] private Button _moveToStreet;
        [SerializeField] private Text _money;

        public void Init(PlayerData playerData)
        {
            RefreshMoney(playerData.Money);

            _moveToStreet.onClick.AddListener(MoveToStreet);
        }

        private void MoveToStreet()
        {
            new SceneChanger().MoveTo(Enums.Scene.Street);
        }

        private void RefreshMoney(float money)
        {
            _money.text = money.ToString();
        }
    }
}
