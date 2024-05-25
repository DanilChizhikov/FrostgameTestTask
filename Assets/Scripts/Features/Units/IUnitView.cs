using UnityEngine;

namespace TestTask.Units
{
    public interface IUnitView
    {
        GameObject GameObject { get; }
        Transform Transform { get; }
    }
}