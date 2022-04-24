using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwordsAndSandals.Editor
{
    public class PlayerColorChanger
    {
        public Color CurrentColor => _colors[_currentIndex];
        private Color[] _colors;
        private int _currentIndex;
        private PlayerPaintableParts _paintableParts;

        public PlayerColorChanger(PlayerPaintableParts playerPaintableParts)
        {
            _colors = new Color[]
            {
                Color.white,
                Color.red,
                Color.yellow,
                Color.blue,
                Color.green,
                Color.black,
            };
            _currentIndex = 0;

            _paintableParts = playerPaintableParts;
        }

        public void Init(SkinUI skinUI)
        {
            skinUI.OnNext += Next;
            skinUI.OnPrevious += Previous;
        }

        private void Next()
        {
            if (_colors.Length - _currentIndex <= 1)
                return;

            _currentIndex++;
            _paintableParts.Colorize(_colors[_currentIndex]);
        }

        private void Previous()
        {
            if (_currentIndex == 0)
                return;

            _currentIndex--;
            _paintableParts.Colorize(_colors[_currentIndex]);
        }
    }
}
