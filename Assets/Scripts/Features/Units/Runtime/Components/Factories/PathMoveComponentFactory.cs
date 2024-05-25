using TestTask.Cameras;
using TestTask.Inputs;
using TestTask.Navigation;

namespace TestTask.Units
{
    internal sealed class PathMoveComponentFactory : ComponentFactory<IPathMoveConfig, MoveRequest, MoveResponse, PathMoveComponent>
    {
        private readonly IPathfinderFactory _pathfinderFactory;
        private readonly ICameraService _cameraService;
        private readonly IInputService _inputService;

        public PathMoveComponentFactory(IPathfinderFactory pathfinderFactory, ICameraService cameraService, IInputService inputService)
        {
            _pathfinderFactory = pathfinderFactory;
            _cameraService = cameraService;
            _inputService = inputService;
        }

        protected override PathMoveComponent Create(IUnitEntity entity, IPathMoveConfig config)
        {
            IPathfinder pathfinder = _pathfinderFactory.CreatePathfinder();
            return new PathMoveComponent(entity, config, pathfinder, _cameraService, _inputService);
        }
    }
}