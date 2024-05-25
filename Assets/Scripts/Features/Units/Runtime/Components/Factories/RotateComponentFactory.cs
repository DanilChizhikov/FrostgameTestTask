namespace TestTask.Units
{
    internal sealed class RotateComponentFactory : ComponentFactory<IRotateConfig, RotateComponent>
    {
        protected override RotateComponent Create(IUnitEntity entity, IRotateConfig config)
        {
            return new RotateComponent(entity, config);
        }
    }
}