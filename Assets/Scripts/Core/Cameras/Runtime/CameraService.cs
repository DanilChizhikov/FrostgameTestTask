using System;

namespace TestTask.Cameras.Runtime
{
    internal sealed class CameraService : ICameraService, IDisposable
    {
        private readonly CameraRepository _repository;

        private CameraView _currentCamera;

        public CameraService(CameraRepository repository)
        {
            _repository = repository;
        }
        
        public bool TrySetup<TConfig>(TConfig config) where TConfig : ICameraConfig
        {
            var clone = (TConfig)config.Clone();
            if (!_repository.TryGetCamera(clone.CameraId, out CameraView cameraView) ||
                !cameraView.IsServicedConfig(config))
            {
                if (cameraView != null)
                {
                    cameraView.Dispose();
                }
                
                return false;
            }
            
            CleanupCurrentCamera();
            _currentCamera = cameraView;
            _currentCamera.SetConfig(config);
            return true;
        }

        public void RemoveCamera()
        {
            CleanupCurrentCamera();
        }

        public void Dispose()
        {
            CleanupCurrentCamera();
            _repository.Dispose();
        }

        private void CleanupCurrentCamera()
        {
            if (_currentCamera == null)
            {
                return;
            }
            
            _currentCamera.Dispose();
            _currentCamera = null;
        }
    }
}