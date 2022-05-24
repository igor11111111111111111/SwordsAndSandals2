using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwordsAndSandals
{
    public class PlayerPaintableParts : MonoBehaviour
    {
        [SerializeField] private List<SpriteRenderer> _sprites;

        public void Colorize(Color color)
        {
            foreach (var sprite in _sprites)
            {
                sprite.color = color;
            }
        }
    }
}
