using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SwordsAndSandals.Editor
{
    public class SkinPanel : MonoBehaviour
    {
        [SerializeField] private SkinUI _skinPrefab;

        public void Init(PlayerColorChanger playerColorChanger)
        {
            var skinUI = Instantiate(_skinPrefab, transform);
            skinUI.Init("SkinColour");
            playerColorChanger.Init(skinUI);

            skinUI = Instantiate(_skinPrefab, transform);
            skinUI.Init("Hairstyle");

            skinUI = Instantiate(_skinPrefab, transform);
            skinUI.Init("Stubble");
        }
    }
}
