using UnityEngine;
using UnityEngine.AI;

namespace TestTask.Navigation.NavMesh
{
    internal sealed class NavMeshPathfinder : Pathfinder
    {
        private readonly NavMeshPath _meshPath;
        
        public NavMeshPathfinder(INavigationAgent agent) : base(agent)
        {
            _meshPath = new NavMeshPath();
        }

        protected override bool TryGetPath(Vector3 from, Vector3 to, out Vector3[] path)
        {
            bool canFindPath = UnityEngine.AI.NavMesh.CalculatePath(from, to, UnityEngine.AI.NavMesh.AllAreas, _meshPath);
            path = _meshPath.corners;
            return canFindPath;
        }
    }
}