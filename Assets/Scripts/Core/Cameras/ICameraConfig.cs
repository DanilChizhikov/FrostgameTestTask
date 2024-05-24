using System;

namespace TestTask.Cameras
{
    public interface ICameraConfig : ICloneable
    {
        string CameraId { get; }
    }
}