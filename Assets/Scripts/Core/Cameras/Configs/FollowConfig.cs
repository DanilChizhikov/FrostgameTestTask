using UnityEngine;

namespace TestTask.Cameras.Configs
{
    public class FollowConfig : ICameraConfig
    {
        public string CameraId { get; set; }
        public Transform FollowTarget { get; set; }
        public Vector3 Rotation { get; set; }
        
        public object Clone()
        {
            return new FollowConfig
            {
                CameraId = CameraId,
                FollowTarget = FollowTarget,
                Rotation = Rotation,
            };
        }
    }
}