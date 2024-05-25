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
        
        private Vector3 _targetPosition;
        private Vector3 _currentPosition;
        
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
            _currentPosition = Vector3.MoveTowards(_currentPosition, _targetPosition, moveDelta);
            if (IsReached())
            {
                if (!_pathQueue.TryDequeue(out _targetPosition))
                {
                    OnReached?.Invoke();
                }
            }
        }
        
        private bool IsReached()
        {
            return (_currentPosition - _targetPosition).sqrMagnitude <= _stoppedDistanceSqr;
        }

        private float GetMoveDelta()
        {
            return Config.Speed * Time.fixedDeltaTime;
        }
    }
}