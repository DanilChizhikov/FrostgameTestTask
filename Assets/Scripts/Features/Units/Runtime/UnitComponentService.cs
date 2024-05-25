using System;
using System.Collections.Generic;

namespace TestTask.Units
{
    internal sealed class UnitComponentService : IUnitComponentService
    {
        public event Action<uint, IUnitComponent> OnComponentAdded;
        public event Action<uint, IUnitComponent> OnComponentRemoved;
        
        private readonly IUnitIdService _idService;
        private readonly List<ComponentFactory> _factories;
        private readonly Dictionary<Type, int> _factoriesMap;
        private readonly Dictionary<uint, List<IUnitComponent>> _componentsMap;

        public UnitComponentService(IUnitIdService service, IEnumerable<ComponentFactory> factories)
        {
            _idService = service;
            _factories = new List<ComponentFactory>(factories);
            _factoriesMap = new Dictionary<Type, int>(_factories.Count);
            _componentsMap = new Dictionary<uint, List<IUnitComponent>>();
        }

        public void RegisterComponent(uint unitId, IComponentConfig config)
        {
            if (!_idService.TryGetUnit(unitId, out IUnitEntity entity))
            {
                throw new Exception($"Unit with id {unitId} not found");
            }
            
            if (!TryGetFactory(config, out ComponentFactory factory))
            {
                throw new Exception($"Factory for config {config} not found");
            }
            
            if (!_componentsMap.TryGetValue(unitId, out List<IUnitComponent> components))
            {
                components = new List<IUnitComponent>();
                _componentsMap.Add(unitId, components);
            }

            IUnitComponent component = factory.Create(entity, config);
            components.Add(component);
            _componentsMap[unitId] = components;
            OnComponentAdded?.Invoke(unitId, component);
        }

        public bool TryGetComponent<TComponent>(uint unitId, out TComponent component) where TComponent : IUnitComponent
        {
            component = default;
            if (_componentsMap.TryGetValue(unitId, out List<IUnitComponent> components))
            {
                for (int i = 0; i < components.Count; i++)
                {
                    IUnitComponent unitComponent = components[i];
                    if (unitComponent is TComponent genericComponent)
                    {
                        component = genericComponent;
                        return true;
                    }
                }
            }

            return false;
        }

        public void RemoveAllComponents(uint unitId)
        {
            if (!_componentsMap.Remove(unitId, out List<IUnitComponent> components))
            {
                return;
            }

            for (int i = 0; i < components.Count; i++)
            {
                IUnitComponent component = components[i];
                OnComponentRemoved?.Invoke(unitId, component);
                component.Dispose();
            }
        }

        private bool TryGetFactory(IComponentConfig config, out ComponentFactory factory)
        {
            bool hasFactory = _factoriesMap.TryGetValue(config.GetType(), out int factoryIndex);
            if (!hasFactory)
            {
                factoryIndex = GetFactoryIndex(config);
                hasFactory = factoryIndex >= 0;
                if (hasFactory)
                {
                    _factoriesMap.Add(config.GetType(), factoryIndex);
                }
            }
            
            factory = hasFactory ? _factories[factoryIndex] : null;
            return hasFactory;
        }

        private int GetFactoryIndex(IComponentConfig config)
        {
            int index = -1;
            for (int i = 0; i < _factories.Count; i++)
            {
                ComponentFactory factory = _factories[i];
                if (factory.IsServicedConfig(config))
                {
                    index = i;
                    break;
                }
            }
            
            return index;
        }
    }
}