using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwordsAndSandals
{
    public class PlayerPaintableParts : MonoBehaviour
    {
        [SerializeField] SpriteRenderer _head;
        [SerializeField] SpriteRenderer _body;
        [SerializeField] SpriteRenderer _torso;
        [SerializeField] SpriteRenderer _leftForearm;
        [SerializeField] SpriteRenderer _rightForearm;
        [SerializeField] SpriteRenderer _leftHip;
        [SerializeField] SpriteRenderer _rightHip;
        [SerializeField] SpriteRenderer _leftShin;
        [SerializeField] SpriteRenderer _rightShin;
        [SerializeField] SpriteRenderer _leftShoulder;
        [SerializeField] SpriteRenderer _rightShoulder;

        public void Colorize(Color color)
        {
            _head.color = color;
            _body.color = color;
            _torso.color = color;
            _leftForearm.color = color;
            _rightForearm.color = color;
            _leftHip.color = color;
            _rightHip.color = color;
            _leftShin.color = color;
            _rightShin.color = color;
            _leftShoulder.color = color;
            _rightShoulder.color = color;
        }
    }
}
