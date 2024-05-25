using UnityEngine;

namespace TestTask.Units
{
    [CreateAssetMenu(menuName = "Configs/Units/Components/" + nameof(RotateConfig), fileName = nameof(RotateConfig))]
    internal sealed class RotateConfig : ComponentConfig, IRotateConfig
    {
        [SerializeField, Min(0f)] private float _speed = 0f;

        public float Speed => _speed;
    }
}