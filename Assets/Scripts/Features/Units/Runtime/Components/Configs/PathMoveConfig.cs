using UnityEngine;

namespace TestTask.Units
{
    [CreateAssetMenu(menuName = "Configs/Units/Components/" + nameof(PathMoveConfig), fileName = nameof(PathMoveConfig))]
    internal sealed class PathMoveConfig : ComponentConfig, IPathMoveConfig
    {
        [SerializeField, Min(0f)] private float _speed = 0f;
        [SerializeField, Min(0f)] private float _stoppedDistance = 0f;

        public float Speed => _speed;
        public float StoppedDistance => _stoppedDistance;
    }
}