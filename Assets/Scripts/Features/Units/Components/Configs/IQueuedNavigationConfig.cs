namespace TestTask.Units
{
    public interface IQueuedNavigationConfig : INavigationConfig
    {
        int QueueSize { get; }
    }
}