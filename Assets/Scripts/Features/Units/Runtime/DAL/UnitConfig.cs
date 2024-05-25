using System;
using System.Collections.Generic;
using UnityEngine;

namespace TestTask.Units
{
    [Serializable]
    internal sealed class UnitConfig : IUnitConfig
    {
        [SerializeField] private string _id = string.Empty;
        [SerializeField] private ComponentConfig[] _componentConfigs = Array.Empty<ComponentConfig>();
        [SerializeField, EntityId] private string _entityId = string.Empty;

        public string Id => _id;
        public IReadOnlyList<IComponentConfig> ComponentConfigs => _componentConfigs;
        public string EntityId => _entityId;
    }
}