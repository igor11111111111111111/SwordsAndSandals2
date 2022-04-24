using System;
using UnityEngine;

namespace CustomJson
{

    [Serializable]
    public class SerializedColor
    {
        public float r, g, b, a;

        private Color _color
        {
            get 
            { 
                return new Color(r, g, b, a); 
            }
            set 
            {
                r = value.r;
                g = value.g;
                b = value.b;
                a = value.a;
            }
        }

        public SerializedColor()
        {
            r = g = b = a = 1;
        }

        public static implicit operator Color(SerializedColor instance)
        {
            return instance._color;
        }

        public static implicit operator SerializedColor(Color color)
        {
            return new SerializedColor { _color = color };
        }
    }
}
