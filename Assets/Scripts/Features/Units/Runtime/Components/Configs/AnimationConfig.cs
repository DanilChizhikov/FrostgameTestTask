using UnityEngine;

namespace TestTask.Units
{
    [CreateAssetMenu(menuName = "Configs/Units/Components/" + nameof(AnimationConfig), fileName = nameof(AnimationConfig))]
    internal sealed class AnimationConfig : ComponentConfig, IAnimationConfig
    {
        [SerializeField] private string _moveVelocityParameter = "MoveVelocity";

        public string MoveVelocityParameter => _moveVelocityParameter;
    }
}