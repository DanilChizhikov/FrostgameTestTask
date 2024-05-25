namespace TestTask.Navigation.NavMesh
{
    internal sealed class NavMeshPathfinderFactory : IPathfinderFactory
    {
        public IPathfinder CreatePathfinder()
        {
            return new NavMeshPathfinder();
        }
    }
}