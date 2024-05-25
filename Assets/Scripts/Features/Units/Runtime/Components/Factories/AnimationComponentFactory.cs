namespace TestTask.Units
{
    internal sealed class AnimationComponentFactory : ComponentFactory<IAnimationConfig, AnimationRequest, AnimationResponse, AnimationComponent>
    {
        protected override AnimationComponent Create(IUnitEntity entity, IAnimationConfig config)
        {
            return new AnimationComponent(entity, config);
        }
    }
}