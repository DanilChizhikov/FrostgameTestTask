using System;
using UnityEngine;

namespace TestTask.Saves.Extensions
{
    [Serializable]
    public struct SaveVector3
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public SaveVector3(Vector3 value)
        {
            X = value.x;
            Y = value.y;
            Z = value.z;
        }
        
        public Vector3 ToVector3()
        {
            return new Vector3(X, Y, Z);
        }
    }
}