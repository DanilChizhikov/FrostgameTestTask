namespace TestTask.Units
{
    internal abstract class UnitComponent<TConfig, TRequest, TResponse> : IUnitComponent<TRequest, TResponse>
        where TConfig : IComponentConfig
    {
        protected IUnitEntity Entity { get; }
        protected TConfig Config { get; }

        public UnitComponent(IUnitEntity entity, TConfig config)
        {
            Entity = entity;
            Config = config;
        }

        public abstract TRequest GetData();
        public abstract void SetData(TResponse data);

        public virtual void Dispose()
        {
        }
    }
}