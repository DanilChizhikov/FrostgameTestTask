using System;
using System.Collections.Generic;

namespace TestTask.Cameras.Runtime
{
    internal sealed class CameraRepository : IDisposable
    {
        private readonly Dictionary<string, CameraPool> _poolsMap;

        public CameraRepository(CameraDatabase database)
        {
            _poolsMap = new Dictionary<string, CameraPool>(database.Infos.Count);
            for (int i = 0; i < database.Infos.Count; i++)
            {
                CameraInfo cameraInfo = database.Infos[i];
                _poolsMap.Add(cameraInfo.Id, new CameraPool(cameraInfo.Prefab));
            }
        }

        public bool TryGetCamera(string id, out CameraView camera)
        {
            camera = null;
            if (!_poolsMap.TryGetValue(id, out CameraPool pool))
            {
                return false;
            }
            
            camera = pool.GetClone();
            return true;
        }

        public void Dispose()
        {
            foreach (var pool in _poolsMap)
            {
                pool.Value.Dispose();
            }
            
            _poolsMap.Clear();
        }
    }
}