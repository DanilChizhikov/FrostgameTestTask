#if UNITY_EDITOR
using Cinemachine;
using UnityEditor;

namespace TestTask.Cameras.Runtime
{
    internal abstract partial class CameraView
    {
        protected virtual void Reset()
        {
            _virtualCamera = GetComponent<CinemachineVirtualCameraBase>();
            EditorUtility.SetDirty(this);
        }
    }
}
#endif