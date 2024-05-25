using System;
using UnityEngine;

namespace TestTask.Navigation
{
    public interface INavigationAgent : IDisposable
    {
        event Action<Vector3> OnDestinationChanged;
        event Action<INavigationAgent> OnDisposed;
        
        Vector3 Position { get; }
    }
}