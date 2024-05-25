using System.Collections.Generic;

namespace TestTask.Units
{
    internal sealed class UnitRepository
    {
        private readonly Dictionary<string, RuntimeUnitConfig> _configsMap;

        public UnitRepository(UnitDatabase unitDatabase, EntityDatabase entityDatabase)
        {
            _configsMap = new Dictionary<string, RuntimeUnitConfig>(unitDatabase.Configs.Count);
            for (int i = 0; i < unitDatabase.Configs.Count; i++)
            {
                IUnitConfig config = unitDatabase.Configs[i];
                if (TryGetEntity(entityDatabase, config.EntityId, out UnitEntity entity))
                {
                    var runtimeConfig = new RuntimeUnitConfig(config.ComponentConfigs, entity);
                    _configsMap.Add(config.Id, runtimeConfig);
                }
            }
        }

        public bool TryGetConfig(string unitId, out RuntimeUnitConfig config)
        {
            return _configsMap.TryGetValue(unitId, out config);
        }

        private static bool TryGetEntity(EntityDatabase database, string entityId, out UnitEntity entity)
        {
            entity = null;
            for (int i = 0; i < database.Infos.Count; i++)
            {
                EntityInfo entityInfo = database.Infos[i];
                if (entityInfo.Id == entityId)
                {
                    entity = entityInfo.Entity;
                    return true;
                }
            }

            return false;
        }
    }
}