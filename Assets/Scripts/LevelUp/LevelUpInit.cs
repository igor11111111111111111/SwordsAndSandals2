using CustomJson;
using SwordsAndSandals.Editor;
using SwordsAndSandals.OutScene;
using UnityEngine;
using UnityEngine.UI;

namespace SwordsAndSandals.LevelUp
{
    public class LevelUpInit : MonoBehaviour
    {
        [SerializeField] private SkillsPanel _skillsPanel;
        [SerializeField] private LevelUpInfo _levelUpInfo;
        [SerializeField] private Button _moveToStreet;
        [SerializeField] private PlayerSpawner _playerSpawner;

        private PlayerData _playerData;

        private void Awake()
        {
            _playerData = new Json().Load<PlayerData>(Enums.SaveFilename.Player);
            _playerSpawner.Init
                (
                    _playerData,
                    new Vector3(-0.25f, -4.33f, 0),
                    3.5f
                );
            _skillsPanel.Init(_playerData.DataSkills);
            _levelUpInfo.Init(_playerData.DataLevel.Level);

            _moveToStreet.onClick.AddListener(MoveToStreet);
        }

        private void MoveToStreet()
        {
            new Json().Save(_playerData, Enums.SaveFilename.Player);
            new SceneChanger().MoveTo(Enums.Scene.Street);
        }
    }
}
