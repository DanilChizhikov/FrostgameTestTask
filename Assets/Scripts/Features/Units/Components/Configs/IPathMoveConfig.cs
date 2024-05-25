namespace TestTask.Units
{
    public interface IPathMoveConfig : IComponentConfig
    {
        float MoveSpeed { get; }
        float RotationSpeed { get; }
        float StoppedDistance { get; }
        int QueueSize { get; }
    }
}