using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace SwordsAndSandals.Arena
{
    public class FatalityPanel : MonoBehaviour
    {
        [SerializeField] private GameObject _body;
        [SerializeField] private Button _button;
        public Action OnClicked;
         
        public void Init()
        {
            _body.SetActive(false);

            _button.onClick.AddListener(() => 
            {
                _body.SetActive(false);
                OnClicked?.Invoke();
            });
        }

        public void Show()
        {
            _body.SetActive(true);
        }
    }
}
