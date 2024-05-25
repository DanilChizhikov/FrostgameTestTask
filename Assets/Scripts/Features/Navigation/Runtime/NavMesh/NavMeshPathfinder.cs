using UnityEngine;
using UnityEngine.AI;

namespace TestTask.Navigation.NavMesh
{
    internal sealed class NavMeshPathfinder : Pathfinder
    {
        private readonly NavMeshPath _meshPath;
        
        public NavMeshPathfinder()
        {
            _meshPath = new NavMeshPath();
        }

        public override bool IsValidPosition(Vector3 point)
        {
            return UnityEngine.AI.NavMesh.SamplePosition(point, out _, 0.1f, UnityEngine.AI.NavMesh.AllAreas);
        }

        protected override bool TryGetPath(Vector3 from, Vector3 to, out Vector3[] path)
        {
            bool canFindPath = UnityEngine.AI.NavMesh.CalculatePath(from, to, UnityEngine.AI.NavMesh.AllAreas, _meshPath);
            path = _meshPath.corners;
            return canFindPath;
        }
    }
}