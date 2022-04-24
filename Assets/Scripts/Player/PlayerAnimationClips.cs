using System;
using System.Threading.Tasks;
using UnityEngine;

namespace SwordsAndSandals
{
    public class PlayerAnimationClips
    {
        private AnimationClip[] _clips;

        public PlayerAnimationClips()
        {
            _clips = Resources.LoadAll<AnimationClip>("");
        }

        public async Task EndClip(Enums.CurrentState state)
        {
            var clip = Array.Find(_clips, c => c.name == state.ToString());
            await Task.Delay((int)(clip.length * 1000));
        }
    }
}
