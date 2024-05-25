using UnityEngine;

namespace TestTask.Units
{
    internal sealed class AnimationComponent : UnitComponent<IAnimationConfig>, IAnimationComponent
    {
        private readonly int _moveVelocityHash;
        
        public AnimationComponent(IUnitEntity entity, IAnimationConfig config) : base(entity, config)
        {
            _moveVelocityHash = Animator.StringToHash(config.MoveVelocityParameter);
        }

        public void Refresh()
        {
            float velocity = Entity.Rigidbody.velocity.normalized.sqrMagnitude;
            Entity.Animator.SetFloat(_moveVelocityHash, velocity);
        }
    }
}