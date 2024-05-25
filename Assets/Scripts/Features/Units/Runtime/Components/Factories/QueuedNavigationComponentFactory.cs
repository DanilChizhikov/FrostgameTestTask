using TestTask.Navigation;

namespace TestTask.Units
{
    internal sealed class QueuedNavigationComponentFactory : ComponentFactory<IQueuedNavigationConfig, QueuedNavigationComponent>
    {
        private readonly IPathfinderFactory _pathfinderFactory;

        public QueuedNavigationComponentFactory(IPathfinderFactory pathfinderFactory)
        {
            _pathfinderFactory = pathfinderFactory;
        }
        
        protected override QueuedNavigationComponent Create(IUnitEntity entity, IQueuedNavigationConfig config)
        {
            var component = new QueuedNavigationComponent(entity, config);
            IPathfinder pathfinder = _pathfinderFactory.CreatePathfinder(component);
            component.SetPathfinder(pathfinder);
            return component;
        }
    }
}