using UnityEngine;

namespace SwordsAndSandals.ArmorShop
{
    public class ArmorPricePanel : MonoBehaviour
    {
        [SerializeField] private GameObject _body;

        public void Init()
        {
            _body.SetActive(false);
        }

        public void Show()
        {
            _body.SetActive(true);
        }
    }
}