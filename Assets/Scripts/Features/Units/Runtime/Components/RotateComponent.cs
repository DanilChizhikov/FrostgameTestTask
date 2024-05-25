using UnityEngine;

namespace TestTask.Units
{
    internal sealed class RotateComponent : UnitComponent<IRotateConfig>, IRotateComponent
    {
        public RotateComponent(IUnitEntity entity, IRotateConfig config) : base(entity, config)
        {
        }

        public void Rotate()
        {
            Quaternion targetRotation = Quaternion.LookRotation(Entity.Rigidbody.velocity, Vector3.up);
            float rotateDelta = GetRotateDelta();
            Entity.Rotation = Quaternion.RotateTowards(Entity.Rotation, targetRotation, rotateDelta);
        }
        
        private float GetRotateDelta()
        {
            return Config.Speed * Time.fixedDeltaTime;
        }
    }
}