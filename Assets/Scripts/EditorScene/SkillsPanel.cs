using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SwordsAndSandals;

namespace SwordsAndSandals.Editor
{
    public class SkillsPanel : MonoBehaviour
    {
        [SerializeField] SkillUI _skillPrefab;
        [SerializeField] private UnallocatedSkillPointsUI _unallocatedSkillPointsUI;
        private PlayerDataSkills _playerDataSkills;

        public void Init(PlayerDataSkills playerDataSkills)
        {
            _playerDataSkills = playerDataSkills;

            Create();

            _playerDataSkills.OnUnallocatedPointsChanged += (_) =>
            {
                _unallocatedSkillPointsUI.Refresh(_playerDataSkills.UnallocatedPoints);
            };
            _unallocatedSkillPointsUI.Refresh(_playerDataSkills.UnallocatedPoints);
        }

        private void Create()
        {
            foreach (var skill in _playerDataSkills.Array)
            {
                var skillUI = Instantiate(_skillPrefab, transform);
                skillUI.Init(skill, _playerDataSkills);
                skillUI.OnUnallocatedPointsChanged += (delta) => _playerDataSkills.OnUnallocatedPointsChanged?.Invoke(delta);
            }
        }
    }
}
