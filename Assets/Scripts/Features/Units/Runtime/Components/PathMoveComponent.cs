using System;
using System.Collections.Generic;
using TestTask.Cameras;
using TestTask.Inputs;
using TestTask.Navigation;
using UnityEngine;

namespace TestTask.Units
{
    internal sealed class PathMoveComponent : UnitComponent<IPathMoveConfig, MoveRequest, MoveResponse>,
        IPathMoveComponent, IPlayerInputListener
    {
        private readonly IPathfinder _pathfinder;
        private readonly ICameraService _cameraService;
        private readonly Queue<Vector3> _navigationQueue;
        private readonly Queue<Vector3> _pathQueue;
        private readonly float _stoppedDistanceSqr;
        private readonly IDisposable _inputSubscription;
        
        private Vector3 _targetPosition;

        public IReadOnlyList<Vector3> NavigationQueue
        {
            get
            {
                var result = new List<Vector3>();
                result.Add(CurrentPosition);
                result.Add(_targetPosition);
                result.AddRange(_navigationQueue);
                return result;
            }
        }
        public Vector3 CurrentPosition => Entity.Position;
        public Vector3 CurrentDirection => Entity.Rotation * Vector3.forward;

        public PathMoveComponent(IUnitEntity entity, IPathMoveConfig config, IPathfinder pathfinder, ICameraService cameraService,
            IInputService inputService) : base(entity, config)
        {
            _pathfinder = pathfinder;
            _cameraService = cameraService;
            _navigationQueue = new Queue<Vector3>();
            _pathQueue = new Queue<Vector3>();
            _stoppedDistanceSqr = config.StoppedDistance * config.StoppedDistance;
            _inputSubscription = inputService.Subscribe(this);
            _targetPosition = new Vector3(entity.Position.x, 0f, entity.Position.z);
            _pathfinder.OnPathUpdated += PathUpdatedCallback;
        }

        public override MoveRequest GetData()
        {
            return new MoveRequest
            {
                CurrentPosition = new Vector3(Entity.Position.x, 0f, Entity.Position.z),
                TargetPosition = _targetPosition,
                StoppedDistanceSqr = _stoppedDistanceSqr,
                MoveSpeed = Config.MoveSpeed,
                RotateSpeed = Config.RotationSpeed,
            };
        }

        public override void SetData(MoveResponse data)
        {
            if (data.IsReached)
            {
                UpdateTargetPosition();
            }
            else
            {
                Entity.Rigidbody.MovePosition(Entity.Position + data.Velocity);
                Entity.Rotation = data.Rotation;
            }
        }
        
        public void LoadFrom(IReadOnlyList<Vector3> navigationQueue, Vector3 position, Vector3 direction)
        {
            _navigationQueue.Clear();
            for (int i = 0; i < navigationQueue.Count; i++)
            {
                _navigationQueue.Enqueue(navigationQueue[i]);
            }

            Entity.Position = position;
            Entity.Rotation = Quaternion.LookRotation(direction, Vector3.up);
            UpdateTargetPosition();
        }

        public override void Dispose()
        {
            base.Dispose();
            _pathfinder.OnPathUpdated -= PathUpdatedCallback;
            _inputSubscription?.Dispose();
        }

        private void PathUpdatedCallback()
        {
            for (int i = 0; i < _pathfinder.Path.Count; i++)
            {
                _pathQueue.Enqueue(_pathfinder.Path[i]);
            }
        }
        
        private void UpdateTargetPosition()
        {
            _targetPosition = new Vector3(Entity.Position.x, 0f, Entity.Position.z);
            if (_pathQueue.TryDequeue(out Vector3 position))
            {
                _targetPosition = new Vector3(position.x, 0f, position.z);
            }
            else if(_navigationQueue.TryDequeue(out Vector3 navigationPosition))
            {
                _pathfinder.TryFindPath(_targetPosition, navigationPosition);
            }
        }
        
        void IPlayerInputListener.OnMove(Vector2 screenPoint)
        {
            if (_navigationQueue.Count >= Config.QueueSize)
            {
                return;
            }
            
            Ray ray = _cameraService.ScreenPointToRay(screenPoint);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (_pathfinder.IsValidPosition(hit.point))
                {
                    _navigationQueue.Enqueue(hit.point);
                }
            }
        }
    }
}