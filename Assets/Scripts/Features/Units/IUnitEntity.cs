using UnityEngine;

namespace TestTask.Units
{
    public interface IUnitEntity
    {
        uint Id { get; }
        
        Vector3 Position { get; set; }
        Quaternion Rotation { get; set; }
        Rigidbody Rigidbody { get; }
        Animator Animator { get; }
    }
}