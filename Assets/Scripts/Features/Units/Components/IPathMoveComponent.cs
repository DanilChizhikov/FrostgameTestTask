using System;
using System.Collections.Generic;
using UnityEngine;

namespace TestTask.Units
{
    public interface IPathMoveComponent : IUnitComponent
    {
        event Action OnReached;
        
        void SetPath(IReadOnlyList<Vector3> value);
    }
}