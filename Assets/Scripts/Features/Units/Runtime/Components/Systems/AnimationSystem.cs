using Zenject;

namespace TestTask.Units
{
    internal sealed class AnimationSystem : UnitComponentSystem<AnimationComponent>, ILateTickable
    {
        public AnimationSystem(IUnitComponentService componentService) : base(componentService)
        {
        }

        public void LateTick()
        {
            CalculateQueue();
            while (TryMoveNext(out AnimationComponent component))
            {
                AnimationRequest request = component.GetData();
                float velocity = (request.CurrentPosition - request.LastPosition).magnitude;
                component.SetData(new AnimationResponse
                {
                    Velocity = velocity
                });
            }
        }
    }
}