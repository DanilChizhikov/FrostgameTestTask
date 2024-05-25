using System;

namespace TestTask.Units
{
    internal abstract class ComponentFactory
    {
        public abstract bool IsServicedConfig(IComponentConfig config);

        public abstract IUnitComponent Create(IUnitEntity entity, IComponentConfig config);
    }
    
    internal abstract class ComponentFactory<TConfig, TComponent> : ComponentFactory
        where TConfig : IComponentConfig
        where TComponent : UnitComponent<TConfig>
    {
        public override bool IsServicedConfig(IComponentConfig config)
        {
            return config is TConfig;
        }
        
        public sealed override IUnitComponent Create(IUnitEntity entity, IComponentConfig config)
        {
            if (config is not TConfig genericConfig)
            {
                throw new AggregateException(nameof(config));
            }
            
            return Create(entity, genericConfig);
        }
        
        protected abstract TComponent Create(IUnitEntity entity, TConfig config);
    }
}