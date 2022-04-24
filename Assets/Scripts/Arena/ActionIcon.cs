using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SwordsAndSandals.Arena
{
    public class ActionIcon : MonoBehaviour
    {
        public Action OnClicked;
        [SerializeField] private Button _button;
        [SerializeField] private Image _image;

        public void Init()
        {
            _button.onClick?.AddListener(() => OnClicked?.Invoke());
        }

        public void SetSprite(Sprite sprite, bool isNeedRotate)
        {
            _image.sprite = sprite;
            if(isNeedRotate)
                _image.transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
