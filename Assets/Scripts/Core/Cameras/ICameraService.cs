namespace TestTask.Cameras
{
    public interface ICameraService
    {
        bool TrySetup<TConfig>(TConfig config) where TConfig : ICameraConfig;
        void RemoveCamera();
    }
}