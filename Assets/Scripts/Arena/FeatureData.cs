using System;
using UnityEngine;

namespace SwordsAndSandals.Arena
{
    public class FeatureData
    {
        public Action<String> OnValueChanged;
        public int Current
        {
            get 
            {
                return _current;
            }
            set
            {
                _current = value;
                if (_current <= 0)
                    _current = 0;
                OnValueChanged?.Invoke(_currentMaxValue);
            }
        }
        protected int _current;
        public int Max => _max;
        protected int _max;
        private string _currentMaxValue => _current + " / " + Max;

        public void Init()
        {
            OnValueChanged?.Invoke(_currentMaxValue);
        }
    }

    public class ArmorData : FeatureData
    {
        public ArmorData(int max)
        {
            _current = _max = max;
        }
    }

    public class HealthData : FeatureData
    {
        private const int _baseValue = 10;
        private const int _valuePerPoint = 20;

        public HealthData(Skill skill)
        {
            _current = _max = _baseValue + skill.Value * _valuePerPoint;
        }
    }

    public class StaminaData : FeatureData
    {
        private const int _baseValue = 100;
        private const int _valuePerPoint = 10;

        public StaminaData(Skill skill)
        {
            _current = _max = _baseValue + skill.Value * _valuePerPoint;
        }
    }
}
