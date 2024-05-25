namespace TestTask.Units
{
    internal sealed class AnimationComponentFactory : ComponentFactory<IAnimationConfig, AnimationComponent>
    {
        protected override AnimationComponent Create(IUnitEntity entity, IAnimationConfig config)
        {
            return new AnimationComponent(entity, config);
        }
    }
}