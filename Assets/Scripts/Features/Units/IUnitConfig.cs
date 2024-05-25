using System.Collections.Generic;

namespace TestTask.Units
{
    public interface IUnitConfig
    {
        string Id { get; }
        IReadOnlyList<IComponentConfig> ComponentConfigs { get; }
        string EntityId { get; }
    }
}