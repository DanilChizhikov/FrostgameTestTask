using System;
using TestTask.Navigation;
using UnityEngine;

namespace TestTask.Tests.Navigation
{
    internal sealed class NavMeshAgent : INavigationAgent
    {
        public event Action<Vector3> OnDestinationChanged;
        public event Action<INavigationAgent> OnDisposed;
        
        public Vector3 Position { get; private set; }

        public void SetDestination(Vector3 destination)
        {
            OnDestinationChanged?.Invoke(destination);
        }
        
        public void Dispose()
        {
            OnDisposed?.Invoke(this);
        }
    }
}