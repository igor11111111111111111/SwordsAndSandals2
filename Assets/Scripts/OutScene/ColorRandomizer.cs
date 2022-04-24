using SwordsAndSandals.OutScene;
using UnityEngine;

namespace SwordsAndSandals.OutScene
{
    public class ColorRandomizer
    {
        public Color Get()
        {
            return new Color(Tone(), Tone(), Tone());
        }

        private float Tone()
        {
            return Random.Range(0, 255) / 255f;
        }
    }
}
