using UnityEngine;

namespace TestTask.Units
{
    internal sealed class AnimationConfig : ComponentConfig, IAnimationConfig
    {
        [SerializeField] private string _moveVelocityParameter = "MoveVelocity";

        public string MoveVelocityParameter => _moveVelocityParameter;
    }
}