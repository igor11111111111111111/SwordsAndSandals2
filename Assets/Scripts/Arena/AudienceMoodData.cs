using System;
using UnityEngine;

namespace SwordsAndSandals.Arena
{
    public class AudienceMoodData
    {
        public event Action<int, int> OnValueChanged;
        public int Current
        { 
            get
            {
                return _current;
            }
            set
            {
                _current = Mathf.Clamp(value, 0, _max);
                OnValueChanged?.Invoke(_current, _max);
            }
        }
        private int _current;
        public int Max => _max;
        private int _max;
        public float Percent => _currentToMax * 100;
        public float Coeff => 1 + _currentToMax;
        private float _currentToMax => _current / (float)_max;
        public AudienceMoodData()
        {
            _max = 100;
            Current = 0;
        }
    }
}
