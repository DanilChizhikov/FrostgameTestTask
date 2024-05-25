using System.Collections.Generic;

namespace TestTask.Units
{
    internal sealed class UnitIdService : IUnitIdService
    {
        private readonly Dictionary<uint, IUnitEntity> _entitiesMap;

        private uint _lastUnitId;
        
        public UnitIdService()
        {
            _entitiesMap = new Dictionary<uint, IUnitEntity>();
            _lastUnitId = 0;
        }

        public uint GetNextId() => _lastUnitId++;

        public bool TryGetUnit(uint id, out IUnitEntity unit)
        {
            return _entitiesMap.TryGetValue(id, out unit);
        }

        public void Add(IUnitEntity entity)
        {
            _entitiesMap.Add(entity.Id, entity);
        }

        public void Remove(IUnitEntity entity)
        {
            _entitiesMap.Remove(entity.Id);
        }
    }
}