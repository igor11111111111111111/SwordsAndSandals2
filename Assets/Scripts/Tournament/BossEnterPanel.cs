using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SwordsAndSandals.Tournament
{
    public class BossEnterPanel : MonoBehaviour
    {
        [SerializeField] private GameObject _body;
        [SerializeField] private GameObject _bg;
        [SerializeField] private Button _moveToArena;
        [SerializeField] private TextMeshProUGUI _info;
        [SerializeField] private TextMeshProUGUI _name;

        public Action OnEnterArena;

        public void Init(PlayerInjector aiInjector, PlayerInjector playerInjector)
        {
            _info.text = "BEHOLD, ARENA CHAMPION";
            _name.text = aiInjector.Data.Name;
            // play boss enter animation betw controller event
            aiInjector.transform.parent = _body.transform;
            aiInjector.transform.localPosition = new Vector3(-20f, -530f, 0f);
            aiInjector.transform.localScale = new Vector3(600f, 600f, 1f);

            playerInjector.transform.localScale = new Vector3(0, 0, 1f);

            _moveToArena.onClick.AddListener(MoveToArena);
        }

        public void Show(bool active)
        {
            _body.SetActive(active);
            _bg.SetActive(active);
        }

        private void MoveToArena()
        {
            Show(false);
            OnEnterArena?.Invoke();
        }
    }
}
 