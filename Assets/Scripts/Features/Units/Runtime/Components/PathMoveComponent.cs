using System;
using System.Collections.Generic;
using UnityEngine;

namespace TestTask.Units
{
    internal sealed class PathMoveComponent : UnitComponent<IPathMoveConfig>, IPathMoveComponent
    {
        public event Action OnReached;

        private readonly Queue<Vector3> _pathQueue;
        private readonly float _stoppedDistanceSqr;
        
        public Vector3 TargetPosition { get; private set; }
        
        public PathMoveComponent(IUnitEntity entity, IPathMoveConfig config) : base(entity, config)
        {
            _pathQueue = new Queue<Vector3>();
            _stoppedDistanceSqr = config.StoppedDistance * config.StoppedDistance;
        }

        public void SetPath(IReadOnlyList<Vector3> value)
        {
            _pathQueue.Clear();
            for (int i = 0; i < value.Count; i++)
            {
                _pathQueue.Enqueue(value[i]);
            }
        }

        public void Move()
        {
            if (IsReached())
            {
                return;
            }
            
            float moveDelta = GetMoveDelta();
            Vector3 desiredVelocity = (Entity.Position - TargetPosition).normalized * moveDelta;
            Entity.Rigidbody.velocity = desiredVelocity;
            if (IsReached())
            {
                if (_pathQueue.TryDequeue(out Vector3 targetPosition))
                {
                    TargetPosition = targetPosition;
                }
                else
                {
                    OnReached?.Invoke();
                }
            }
        }
        
        private bool IsReached()
        {
            return (Entity.Position - TargetPosition).sqrMagnitude <= _stoppedDistanceSqr;
        }

        private float GetMoveDelta()
        {
            return Config.Speed * Time.fixedDeltaTime;
        }
    }
}