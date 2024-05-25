using System.Collections.Generic;

namespace TestTask.Units
{
    internal struct RuntimeUnitConfig
    {
        public IReadOnlyList<IComponentConfig> ComponentConfigs { get; }
        public UnitEntity Entity { get; }
        
        public RuntimeUnitConfig(IReadOnlyList<IComponentConfig> componentConfigs, UnitEntity entity)
        {
            ComponentConfigs = componentConfigs;
            Entity = entity;
        }
    }
}