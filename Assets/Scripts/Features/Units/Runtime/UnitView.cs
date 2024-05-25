using UnityEngine;

namespace TestTask.Units
{
    internal abstract class UnitView : MonoBehaviour, IUnitView
    {
        public GameObject GameObject { get; private set; }
        public Transform Transform { get; private set; }
        
        protected virtual void Awake()
        {
            GameObject = gameObject;
            Transform = transform;
        }
    }
}