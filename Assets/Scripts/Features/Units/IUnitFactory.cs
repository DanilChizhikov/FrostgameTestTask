using UnityEngine;

namespace TestTask.Units
{
    public interface IUnitFactory
    {
        uint Create(string unitId, Vector3 position, Quaternion rotation);
        void RemoveUnit(uint unitId);
    }
}