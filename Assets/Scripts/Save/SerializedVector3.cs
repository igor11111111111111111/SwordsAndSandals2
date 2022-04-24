using System;
using UnityEngine;

namespace CustomJson
{
    [Serializable]
    public class SerializedVector3
    {
        public float x;
        public float y;
        public float z;

        private Vector3 _vector3
        {
            get
            {
                return new Vector3(x, y, z);
            }
            set
            {
                x = value.x;
                y = value.y;
                z = value.z;
            }
        }

        public static implicit operator Vector3(SerializedVector3 instance)
        {
            return instance._vector3;
        }

        public static implicit operator SerializedVector3(Vector3 vector3)
        {
            return new SerializedVector3 { _vector3 = vector3 };
        }
    }
}
