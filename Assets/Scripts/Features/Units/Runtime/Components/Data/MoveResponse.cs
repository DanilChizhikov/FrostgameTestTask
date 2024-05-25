using UnityEngine;

namespace TestTask.Units
{
    internal struct MoveResponse
    {
        public Vector3 Velocity { get; set; }
        public Quaternion Rotation { get; set; }
        public bool IsReached { get; set; }
    }
}