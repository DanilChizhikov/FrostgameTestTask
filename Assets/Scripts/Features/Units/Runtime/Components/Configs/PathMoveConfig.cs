using UnityEngine;

namespace TestTask.Units
{
    [CreateAssetMenu(menuName = "Configs/Units/Components/" + nameof(PathMoveConfig), fileName = nameof(PathMoveConfig))]
    internal sealed class PathMoveConfig : ComponentConfig, IPathMoveConfig
    {
        [SerializeField, Min(0f)] private float _moveSpeed = 0f;
        [SerializeField, Min(0f)] private float _rotationSpeed = 0f;
        [SerializeField, Min(0f)] private float _stoppedDistance = 0f;
        [SerializeField, Min(1)] private int _queueSize = 1;

        public float MoveSpeed => _moveSpeed;
        public float RotationSpeed => _rotationSpeed;
        public float StoppedDistance => _stoppedDistance;
        public int QueueSize => _queueSize;
    }
}