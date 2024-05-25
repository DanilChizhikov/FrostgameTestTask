using UnityEngine;

namespace TestTask.Units
{
    public interface INavigationComponent : IUnitComponent
    {
        void SetDestination(Vector3 value);
    }
}