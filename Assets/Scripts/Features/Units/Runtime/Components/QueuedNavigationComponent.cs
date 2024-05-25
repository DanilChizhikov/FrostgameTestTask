using System;
using System.Collections.Generic;
using TestTask.Navigation;
using UnityEngine;

namespace TestTask.Units
{
    internal sealed class QueuedNavigationComponent : UnitComponent<IQueuedNavigationConfig>, INavigationComponent, INavigationAgent
    {
        public event Action<Vector3> OnDestinationChanged;
        public event Action<INavigationAgent> OnDisposed;

        private readonly Queue<Vector3> _pointQueue;
        private readonly float _minDistanceSqr;
        
        private IPathfinder _pathfinder;
        private Vector3 _lastDestination;

        public Vector3 Position => Entity.Position;

        public QueuedNavigationComponent(IUnitEntity entity, IQueuedNavigationConfig config) : base(entity, config)
        {
            _pointQueue = new Queue<Vector3>(config.QueueSize);
            _minDistanceSqr = config.MinSearchDistance * config.MinSearchDistance;
        }

        public void SetPathfinder(IPathfinder value)
        {
            if (_pathfinder != null)
            {
                Unsubscribe(_pathfinder);
            }
            
            _pathfinder = value;
            if (_pathfinder != null)
            {
                Subscribe(_pathfinder);
                
            }
        }

        public void SetDestination(Vector3 value)
        {
            if (_pointQueue.Count >= Config.QueueSize)
            {
                return;
            }

            float distanceSqr = (_lastDestination - value).sqrMagnitude;
            if (distanceSqr < _minDistanceSqr)
            {
                return;
            }
            
            _pointQueue.Enqueue(value);
        }
        
        public override void Dispose()
        {
            base.Dispose();
            OnDisposed?.Invoke(this);
        }
        
        private void Subscribe(IPathfinder pathfinder)
        {
            pathfinder.OnPathUpdated += PathfinderPathUpdatedCallback;
        }

        private void Unsubscribe(IPathfinder pathfinder)
        {
            pathfinder.OnPathUpdated -= PathfinderPathUpdatedCallback;
        }

        private void PathfinderPathUpdatedCallback()
        {
            
        }
    }
}