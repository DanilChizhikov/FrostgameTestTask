using System;
using UnityEngine.Pool;
using Object = UnityEngine.Object;

namespace TestTask.Cameras.Runtime
{
    internal sealed class CameraPool : IDisposable
    {
        private readonly CameraView _origin;
        private readonly ObjectPool<CameraView> _pool;

        public CameraPool(CameraView origin)
        {
            _origin = origin;
            _pool = new ObjectPool<CameraView>(CreateFunc, GetFunc, ReleaseFunc, DestroyFunc);
        }

        public CameraView GetClone() => _pool.Get();
        
        public void Dispose()
        {
            _pool.Dispose();
        }
        
        private void Release(CameraView clone)
        {
            _pool.Release(clone);
        }

        private CameraView CreateFunc()
        {
            return Object.Instantiate(_origin);
        }
        
        private void GetFunc(CameraView clone)
        {
            clone.gameObject.SetActive(true);
            clone.OnDisposed += Release;
        }
        
        private void ReleaseFunc(CameraView clone)
        {
            clone.gameObject.SetActive(false);
            clone.OnDisposed -= Release;
        }
        
        private void DestroyFunc(CameraView clone)
        {
            Object.Destroy(clone.gameObject);
        }
    }
}