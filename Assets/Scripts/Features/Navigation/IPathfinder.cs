using System;
using System.Collections.Generic;
using UnityEngine;

namespace TestTask.Navigation
{
    public interface IPathfinder
    {
        event Action OnPathUpdated;
        
        IReadOnlyList<Vector3> Path { get; }
        
        bool IsValidPosition(Vector3 point);
        void TryFindPath(Vector3 from, Vector3 to);
        void ClearPath();
    }
}