using UnityEngine;

namespace TestTask.Units
{
    internal struct MoveRequest
    {
        public Vector3 CurrentPosition { get; set; }
        public Quaternion CurrentRotation { get; set; }
        public Vector3 TargetPosition { get; set; }
        public float StoppedDistanceSqr { get; set; }
        public float MoveSpeed { get; set; }
        public float RotateSpeed { get; set; }
    }
}