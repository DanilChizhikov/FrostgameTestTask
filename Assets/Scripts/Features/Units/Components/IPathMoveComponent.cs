using System.Collections.Generic;
using UnityEngine;

namespace TestTask.Units
{
    public interface IPathMoveComponent : IUnitComponent
    {
        public IReadOnlyList<Vector3> NavigationQueue { get; }
        public Vector3 CurrentPosition { get; }
        public Vector3 CurrentDirection { get; }
        
        void LoadFrom(IReadOnlyList<Vector3> navigationQueue, Vector3 position, Vector3 direction);
    }
}