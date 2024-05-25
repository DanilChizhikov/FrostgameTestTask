using System;
using System.Collections.Generic;

namespace TestTask.Units
{
    internal abstract class UnitComponentSystem<TComponent> : IDisposable
        where TComponent : IUnitComponent
    {
        private readonly IUnitComponentService _componentService;
        private readonly List<uint> _uints;
        private readonly Queue<uint> _moveQueue;

        public UnitComponentSystem(IUnitComponentService componentService)
        {
            _componentService = componentService;
            _uints = new List<uint>();
            _moveQueue = new Queue<uint>();
            _componentService.OnComponentAdded += ComponentAddedCallback;
            _componentService.OnComponentRemoved += ComponentRemovedCallback;
        }

        public void Dispose()
        {
            _componentService.OnComponentAdded -= ComponentAddedCallback;
            _componentService.OnComponentRemoved -= ComponentRemovedCallback;
        }

        protected void CalculateQueue()
        {
            if (_moveQueue.Count <= 0)
            {
                for (int i = 0; i < _uints.Count; i++)
                {
                    _moveQueue.Enqueue(_uints[i]);
                }
            }
        }

        protected bool TryMoveNext(out TComponent component)
        {
            component = default;
            bool hasNext = false;
            while (_moveQueue.TryDequeue(out uint unitId))
            { 
                hasNext = _componentService.TryGetComponent(unitId, out component);
                if (hasNext)
                {
                    break;
                }
            }
            
            return hasNext;
        }
        
        private void ComponentAddedCallback(uint unitId, IUnitComponent component)
        {
            if (component is TComponent)
            {
                _uints.Add(unitId);
            }
        }
        
        private void ComponentRemovedCallback(uint unitId, IUnitComponent component)
        {
            if (component is TComponent)
            {
                _uints.Remove(unitId);
            }
        }
    }
}