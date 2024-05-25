namespace TestTask.Navigation.NavMesh
{
    internal sealed class NavMeshPathfinderFactory : IPathfinderFactory
    {
        public IPathfinder CreatePathfinder(INavigationAgent agent)
        {
            return new NavMeshPathfinder(agent);
        }
    }
}