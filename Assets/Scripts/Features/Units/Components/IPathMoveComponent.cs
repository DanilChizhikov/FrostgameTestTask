using System;
using System.Collections.Generic;
using UnityEngine;

namespace TestTask.Units
{
    public interface IPathMoveComponent : IUnitComponent
    {
        event Action OnReached;
        
        Vector3 TargetPosition { get; }
        
        void SetPath(IReadOnlyList<Vector3> value);
    }
}