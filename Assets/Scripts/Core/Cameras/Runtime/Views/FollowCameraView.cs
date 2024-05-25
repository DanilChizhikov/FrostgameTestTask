using TestTask.Cameras.Configs;
using UnityEngine;

namespace TestTask.Cameras.Runtime
{
    internal sealed class FollowCameraView : CameraView<FollowConfig>
    {
        protected override void SetConfig(FollowConfig config)
        {
            VirtualCamera.Follow = config.FollowTarget;
            VirtualCamera.LookAt = config.FollowTarget;
            VirtualCamera.transform.rotation = Quaternion.Euler(config.Rotation);
        }
    }
}