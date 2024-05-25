using System;

namespace TestTask.Units
{
    public interface IUnitComponentService
    {
        event Action<uint, IUnitComponent> OnComponentAdded;
        event Action<uint, IUnitComponent> OnComponentRemoved;
        
        void RegisterComponent(uint unitId, IComponentConfig config);
        bool TryGetComponent<TComponent>(uint unitId, out TComponent component) where TComponent : IUnitComponent;
        void RemoveAllComponents(uint unitId);
    }
}