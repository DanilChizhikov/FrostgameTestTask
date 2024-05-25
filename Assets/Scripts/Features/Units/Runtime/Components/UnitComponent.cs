namespace TestTask.Units
{
    internal abstract class UnitComponent<TConfig> : IUnitComponent
        where TConfig : IComponentConfig
    {
        protected IUnitEntity Entity { get; }
        protected TConfig Config { get; }

        public UnitComponent(IUnitEntity entity, TConfig config)
        {
            Entity = entity;
            Config = config;
        }

        public virtual void Dispose()
        {
        }
    }
}