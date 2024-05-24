using System;

namespace TestTask.Cameras.Runtime
{
    internal sealed class CameraService : ICameraService, IDisposable
    {
        public bool TrySetup<TConfig>(TConfig config) where TConfig : ICameraConfig
        {
            return false;
        }

        public void Dispose()
        {
            
        }
    }
}