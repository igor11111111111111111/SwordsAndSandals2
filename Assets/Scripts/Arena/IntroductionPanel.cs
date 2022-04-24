using SwordsAndSandals.OutScene;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace SwordsAndSandals.Arena
{
    public class IntroductionPanel : MonoBehaviour
    {
        [SerializeField] private GameObject _body1;
        [SerializeField] private GameObject _body2;
        [SerializeField] private Button _moveToArena;
        [SerializeField] private Button _moveToPreArena;

        [SerializeField] private Text _playerName;
        [SerializeField] private Text _playerLevel;
        [SerializeField] private Text _aiName;
        [SerializeField] private Text _aiLevel;

        public Action OnEnterArena;
         
        public void Init(
            SwordsAndSandals.PlayerData playerData, 
            SwordsAndSandals.PlayerData aiData)
        {
            _moveToArena.onClick.AddListener(MoveToArena);
            _moveToPreArena.onClick.AddListener(MoveToPreArena);

            _playerName.text = playerData.Name;
            _playerLevel.text = "Level " + playerData.DataLevel.Level;

            _aiName.text = aiData.Name;
            _aiLevel.text = "Level " + aiData.DataLevel.Level;

            _body1.SetActive(true);
            _body2.SetActive(true);
        }

        private void MoveToArena()
        {
            _body1.SetActive(false);
            _body2.SetActive(false);
            OnEnterArena?.Invoke();
        }

        private void MoveToPreArena()
        {
            new SceneChanger().MoveTo(Enums.Scene.PreArena);
        }
    }
}
