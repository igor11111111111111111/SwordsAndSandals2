using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace SwordsAndSandals.Editor
{
    public class SkinUI : MonoBehaviour
    {
        public Action OnNext;
        public Action OnPrevious;

        [SerializeField] private Button _next;
        [SerializeField] private Button _previous;
        [SerializeField] private Text _name;

        public void Init(string name)
        {
            this.name = name;
            _name.text = name;

            _next.onClick.AddListener(() => OnNext?.Invoke());
            _previous.onClick.AddListener(() => OnPrevious?.Invoke());
        }
    }
}
