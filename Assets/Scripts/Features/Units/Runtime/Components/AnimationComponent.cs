using UnityEngine;

namespace TestTask.Units
{
    internal sealed class AnimationComponent : UnitComponent<IAnimationConfig, AnimationRequest, AnimationResponse>, IAnimationComponent
    {
        private readonly int _moveVelocityHash;
        
        private Vector3 _lastPosition;
        
        public AnimationComponent(IUnitEntity entity, IAnimationConfig config) : base(entity, config)
        {
            _moveVelocityHash = Animator.StringToHash(config.MoveVelocityParameter);
            _lastPosition = entity.Position;
        }

        public override AnimationRequest GetData()
        {
            return new AnimationRequest
            {
                LastPosition = _lastPosition,
                CurrentPosition = Entity.Position,
            };
        }

        public override void SetData(AnimationResponse data)
        {
            Entity.Animator.SetFloat(_moveVelocityHash, data.Velocity);
            _lastPosition = Entity.Position;
        }
    }
}