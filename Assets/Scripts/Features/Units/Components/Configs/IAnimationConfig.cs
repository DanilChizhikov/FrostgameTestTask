namespace TestTask.Units
{
    public interface IAnimationConfig : IComponentConfig
    {
        string MoveParameterName { get; }
        string MoveSpeedParameterName { get; }
    }
}