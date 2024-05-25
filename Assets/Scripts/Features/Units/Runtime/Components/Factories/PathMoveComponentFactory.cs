namespace TestTask.Units
{
    internal sealed class PathMoveComponentFactory : ComponentFactory<IPathMoveConfig, PathMoveComponent>
    {
        protected override PathMoveComponent Create(IUnitEntity entity, IPathMoveConfig config)
        {
            return new PathMoveComponent(entity, config);
        }
    }
}