using TestTask.Cameras.Configs;

namespace TestTask.Cameras.Runtime
{
    internal sealed class FollowCameraView : CameraView<FollowConfig>
    {
        protected override void SetConfig(FollowConfig config)
        {
            VirtualCamera.Follow = config.FollowTarget;
            VirtualCamera.LookAt = config.FollowTarget;
        }
    }
}