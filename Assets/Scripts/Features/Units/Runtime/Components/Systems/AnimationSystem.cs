using Zenject;

namespace TestTask.Units
{
    internal sealed class AnimationSystem : UnitComponentSystem<AnimationComponent>, ILateTickable
    {
        public AnimationSystem(IUnitComponentService componentService) : base(componentService)
        {
        }

        void ILateTickable.LateTick()
        {
            while (TryMoveNext(out AnimationComponent component))
            {
                component.Refresh();
            }
        }
    }
}