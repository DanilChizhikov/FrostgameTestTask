using System;
using System.Collections.Generic;
using UnityEngine;

namespace TestTask.Navigation
{
    internal abstract class Pathfinder : IPathfinder
    {
        public event Action OnPathUpdated;

        private static readonly Vector3[] _emptyPath = Array.Empty<Vector3>();
        
        private readonly INavigationAgent _agent;
        private readonly List<Vector3> _paths;

        public IReadOnlyList<Vector3> Path => _paths;

        public Pathfinder(INavigationAgent agent)
        {
            _agent = agent;
            _paths = new List<Vector3>();
            agent.OnDestinationChanged += AgentDestinationChangedCallback;
            agent.OnDisposed += AgentDisposedCallback;
        }

        public void TryFindPath(Vector3 from, Vector3 to)
        {
            if (TryGetPath(from, to, out Vector3[] path))
            {
                SetPath(path);
            }
        }

        public void ClearPath()
        {
            SetPath(_emptyPath);
        }

        protected abstract bool TryGetPath(Vector3 from, Vector3 to, out Vector3[] path);

        private void SetPath(Vector3[] value)
        {
            _paths.Clear();
            _paths.AddRange(value);
            OnPathUpdated?.Invoke();
        }
        
        private void AgentDestinationChangedCallback(Vector3 destination)
        {
            TryFindPath(_agent.Position, destination);
        }
        
        private void AgentDisposedCallback(INavigationAgent agent)
        {
            agent.OnDestinationChanged -= AgentDestinationChangedCallback;
            agent.OnDisposed -= AgentDisposedCallback;
        }
    }
}