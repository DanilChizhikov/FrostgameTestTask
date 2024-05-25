using UnityEngine;
using Zenject;

namespace TestTask.Units
{
    internal sealed class PathMoveSystem : UnitComponentSystem<PathMoveComponent>, IFixedTickable
    {
        public PathMoveSystem(IUnitComponentService componentService) : base(componentService)
        {
        }
        
        public void FixedTick()
        {
            CalculateQueue();
            while (TryMoveNext(out PathMoveComponent component))
            {
                MoveRequest request = component.GetData();
                Vector3 direction = request.TargetPosition - request.CurrentPosition;
                Vector3 velocity = direction.normalized * GetDeltaSpeed(request.MoveSpeed);
                velocity.y = 0f;
                Quaternion desiredRotation = Quaternion.LookRotation(velocity, Vector3.up);
                Quaternion rotation = Quaternion.RotateTowards(request.CurrentRotation, desiredRotation, GetDeltaSpeed(request.RotateSpeed));
                component.SetData(new MoveResponse
                {
                    Velocity = velocity,
                    Rotation = rotation,
                    IsReached = direction.sqrMagnitude <= request.StoppedDistanceSqr
                });
            }
        }
        
        private static float GetDeltaSpeed(float speed) => speed * Time.fixedDeltaTime;
    }
}