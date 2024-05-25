namespace TestTask.Navigation
{
    public interface IPathfinderFactory
    {
        IPathfinder CreatePathfinder(INavigationAgent agent);
    }
}