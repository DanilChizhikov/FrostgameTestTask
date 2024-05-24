using System;
using TestTask.Utils;

namespace TestTask.Cameras
{
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class CameraIdAttribute : StringIdAttribute
    {
    }
}