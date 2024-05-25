namespace TestTask.Units
{
    public interface IPathMoveConfig : IComponentConfig
    {
        float MoveSpeed { get; }
        float RotationSpeed { get; }
    }
}