using System;
using System.Collections.Generic;
using UnityEngine;

namespace TestTask.Units
{
    internal sealed class UnitFactory : IUnitFactory
    {
        private readonly IUnitIdService _idService;
        private readonly IUnitComponentService _componentService;
        private readonly UnitRepository _repository;
        private readonly Dictionary<string, UnitPool> _poolsMap;
        private readonly Dictionary<uint, UnitPool> _targetUnitPools;

        public UnitFactory(IUnitIdService idService, IUnitComponentService componentService, UnitRepository repository)
        {
            _idService = idService;
            _componentService = componentService;
            _repository = repository;
            _poolsMap = new Dictionary<string, UnitPool>();
            _targetUnitPools = new Dictionary<uint, UnitPool>();
        }
        
        public uint Create(string unitId, Vector3 position, Quaternion rotation)
        {
            if (!_repository.TryGetConfig(unitId, out RuntimeUnitConfig config))
            {
                throw new Exception($"Unit with id {unitId} not found");
            }

            uint runtimeUnitId = _idService.GetNextId();
            UnitEntity unit = GetUnit(unitId, runtimeUnitId, config);
            InitializeUnit(unit, runtimeUnitId, position, rotation, config);
            return runtimeUnitId;
        }

        public void RemoveUnit(uint unitId)
        {
            if (!_idService.TryGetUnit(unitId, out IUnitEntity unit))
            {
                return;
            }
            
            _idService.Remove(unit);
            _componentService.RemoveAllComponents(unitId);
            if (_targetUnitPools.Remove(unitId, out UnitPool pool))
            {
                pool.Release((UnitEntity)unit);
            }
        }

        private UnitPool GetPool(string unitId, UnitEntity entity)
        {
            if (!_poolsMap.TryGetValue(unitId, out UnitPool pool))
            {
                pool = new UnitPool(entity);
                _poolsMap.Add(unitId, pool);
            }
            
            return pool;
        }
        
        private UnitEntity GetUnit(string unitId, uint runtimeId, RuntimeUnitConfig config)
        {
            UnitPool unitPool = GetPool(unitId, config.Entity);
            UnitEntity unit = unitPool.Get();
            unit.Initialize(runtimeId);
            _targetUnitPools[runtimeId] = unitPool;
            return unit;
        }
        
        private void InitializeUnit(UnitEntity unit, uint id, Vector3 position, Quaternion rotation, RuntimeUnitConfig config)
        {
            unit.Initialize(id);
            _idService.Add(unit);
            unit.Position = position;
            unit.Rotation = rotation;
            RegisterComponents(unit, config.ComponentConfigs);
        }

        private void RegisterComponents(UnitEntity unit, IReadOnlyList<IComponentConfig> configs)
        {
            for (int i = 0; i < configs.Count; i++)
            {
                IComponentConfig config = configs[i];
                _componentService.RegisterComponent(unit.Id, config);
            }
        }
    }
}