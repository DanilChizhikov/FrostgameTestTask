using System;
using UnityEngine.Pool;
using Object = UnityEngine.Object;

namespace TestTask.Units
{
    internal sealed class UnitPool : IDisposable
    {
        private readonly UnitEntity _origin;
        private readonly ObjectPool<UnitEntity> _pool;

        public UnitPool(UnitEntity origin)
        {
            _origin = origin;
            _pool = new ObjectPool<UnitEntity>(CreateUnit, GetClone, ReleaseClone, DestroyClone);
        }
        
        public UnitEntity Get()
        {
            return _pool.Get();
        }
        
        public void Release(UnitEntity unit)
        {
            _pool.Release(unit);
        }

        public void Dispose()
        {
            _pool.Dispose();
        }
        
        private UnitEntity CreateUnit()
        {
            return Object.Instantiate(_origin);
        }
        
        private void GetClone(UnitEntity clone)
        {
            clone.gameObject.SetActive(true);
        }
        
        private void ReleaseClone(UnitEntity clone)
        {
            clone.gameObject.SetActive(false);
        }
        
        private void DestroyClone(UnitEntity clone)
        {
            Object.Destroy(clone.gameObject);
        }
    }
}