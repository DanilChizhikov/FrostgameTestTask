using UnityEngine;

namespace TestTask.Levels
{
    public interface ILevelView
    {
        Vector3 PlayerPosition { get; }
        Quaternion PlayerRotation { get; }
    }
}