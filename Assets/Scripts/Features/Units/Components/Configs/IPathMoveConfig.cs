namespace TestTask.Units
{
    public interface IPathMoveConfig : IComponentConfig
    {
        float Speed { get; }
        float StoppedDistance { get; }
    }
}