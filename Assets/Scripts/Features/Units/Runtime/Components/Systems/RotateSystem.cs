using Zenject;

namespace TestTask.Units
{
    internal sealed class RotateSystem : UnitComponentSystem<RotateComponent>, IFixedTickable
    {
        public RotateSystem(IUnitComponentService componentService) : base(componentService)
        {
        }

        void IFixedTickable.FixedTick()
        {
            while (TryMoveNext(out RotateComponent component))
            {
                component.Rotate();
            }
        }
    }
}