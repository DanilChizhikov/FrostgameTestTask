using Zenject;

namespace TestTask.Units
{
    internal sealed class PathMoveSystem : UnitComponentSystem<PathMoveComponent>, IFixedTickable
    {
        public PathMoveSystem(IUnitComponentService componentService) : base(componentService)
        {
        }

        void IFixedTickable.FixedTick()
        {
            while (TryMoveNext(out PathMoveComponent component))
            {
                component.Move();
            }
        }
    }
}