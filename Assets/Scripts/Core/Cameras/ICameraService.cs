using UnityEngine;

namespace TestTask.Cameras
{
    public interface ICameraService
    {
        Ray ScreenPointToRay(Vector2 screenPoint);
        bool TrySetup<TConfig>(TConfig config) where TConfig : ICameraConfig;
        void RemoveCamera();
    }
}