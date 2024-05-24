using System;
using Cinemachine;
using UnityEngine;

namespace TestTask.Cameras.Runtime
{
    [RequireComponent(typeof(CinemachineVirtualCameraBase))]
    internal abstract partial class CameraView : MonoBehaviour, IDisposable
    {
        public event Action<CameraView> OnDisposed; 
        
        [SerializeField] private CinemachineVirtualCameraBase _virtualCamera = default;
        
        protected CinemachineVirtualCameraBase VirtualCamera => _virtualCamera;
        
        public abstract bool IsServicedConfig(ICameraConfig config);
        public abstract void SetConfig(ICameraConfig config);
        
        public void Dispose()
        {
            OnDisposed?.Invoke(this);
        }
    }
    
    internal abstract class CameraView<TConfig> : CameraView
        where TConfig : ICameraConfig
    {
        public sealed override bool IsServicedConfig(ICameraConfig config)
        {
            return config is TConfig;
        }
        
        public sealed override void SetConfig(ICameraConfig config)
        {
            if (config is TConfig genericConfig)
            {
                SetConfig(genericConfig);
            }
        }
        
        protected abstract void SetConfig(TConfig config);
    }
}