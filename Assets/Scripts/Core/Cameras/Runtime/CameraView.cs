using UnityEngine;

namespace TestTask.Cameras.Runtime
{
    internal abstract class CameraView : MonoBehaviour
    {
        public abstract bool IsServicedConfig(ICameraConfig config);
        
        public abstract void SetConfig(ICameraConfig config);
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