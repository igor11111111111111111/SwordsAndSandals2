using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SwordsAndSandals;
using System;

namespace SwordsAndSandals.Editor
{
    public class SkillUI : MonoBehaviour
    {
        public Action<int> OnUnallocatedPointsChanged;

        [SerializeField] private Button _minus;
        [SerializeField] private Button _plus;
        [SerializeField] private Text _value;
        [SerializeField] private Text _name;

        private Skill _skill;
        private PlayerDataSkills _playerDataSkills;

        public void Init(Skill skill, PlayerDataSkills playerDataSkills)
        {
            _skill = skill;
            _playerDataSkills = playerDataSkills;

            name = _name.text = _skill.Name;
            Refresh();
            if(_minus != null)
                _minus.onClick.AddListener(Minus);
            _plus.onClick.AddListener(Plus);
        }

        private void Minus()
        {
            if (_skill.Value == 1)
                return;

            _skill.Value--;
            OnUnallocatedPointsChanged?.Invoke(+1);
            Refresh();
        }

        private void Plus()
        {
            if (_playerDataSkills.UnallocatedPoints == 0)
                return;

            _skill.Value++;
            OnUnallocatedPointsChanged?.Invoke(-1);
            Refresh();
        }

        private void Refresh()
        {
            _value.text = _skill.Value.ToString();
        }
    }
}
