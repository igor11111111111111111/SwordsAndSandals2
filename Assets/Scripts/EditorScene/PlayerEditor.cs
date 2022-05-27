using UnityEngine;
using UnityEngine.UI;
using CustomJson;
using SwordsAndSandals.OutScene;

namespace SwordsAndSandals.Editor
{ 
    public class PlayerEditor : MonoBehaviour
    { 
        [SerializeField] private InputField _inputField;
        [SerializeField] private SkillsPanel _skillsPanel;
        [SerializeField] private SkinPanel _skinPanel;

        [SerializeField] private Button _accept;
        [SerializeField] private Button _deny;

        private PlayerData _playerData;
        private PlayerColorChanger _playerColorChanger;

        public void Init(PlayerData playerData, PlayerInjector playerInjector)
        {
            _playerData = playerData;

            var partableParts = playerInjector.GetComponent<PlayerPaintableParts>();
            _playerColorChanger = new PlayerColorChanger(partableParts);

            _skillsPanel.Init(_playerData.DataSkills);
            _skinPanel.Init(_playerColorChanger);

            _accept.onClick.AddListener(Accept);
            _deny.onClick.AddListener(Deny);
        }
        
        private void Accept()
        {
            _playerData.Name = _inputField.text;
            _playerData.SkinColor = _playerColorChanger.CurrentColor;

            var json = new Json();
            json.Save(_playerData);
            json.Save(new TournamentData());

            new SceneChanger().MoveTo(Enums.Scene.Street);
        }

        private void Deny()
        {
            new SceneChanger().MoveTo(Enums.Scene.Menu);
        }
    }
}
