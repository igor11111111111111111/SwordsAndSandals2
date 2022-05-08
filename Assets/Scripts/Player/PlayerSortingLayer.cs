using System.Collections.Generic;
using UnityEngine;

namespace SwordsAndSandals
{
    public class PlayerSortingLayer : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer[] _renderers;

        public void Set(Enums.Team team)
        {
            foreach (var renderer in _renderers)
            {
                renderer.sortingLayerName = team.ToString();
            }
        }
    }
}
