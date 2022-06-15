using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SwordsAndSandals;

namespace SwordsAndSandals.Editor
{
    public class UnallocatedSkillPointsUI : MonoBehaviour
    {
        [SerializeField] private Text _value;

        public void Refresh(int value)
        {
            _value.text = value.ToString();
        }
    }
}
