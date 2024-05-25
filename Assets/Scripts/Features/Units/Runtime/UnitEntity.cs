using UnityEngine;

namespace TestTask.Units
{
    internal abstract class UnitEntity :  MonoBehaviour, IUnitEntity
    {
        private Transform _transform;
        
        public uint Id { get; private set; }

        public Vector3 Position
        {
            get => _transform.position;
            set => SetPosition(value);
        }
        public Quaternion Rotation
        {
            get => _transform.rotation;
            set => SetRotation(value);
        }

        public void Initialize(uint id)
        {
            Id = id;
        }

        private void SetPosition(Vector3 value)
        {
            _transform.position = value;
        }
        
        private void SetRotation(Quaternion value)
        {
            _transform.rotation = value;
        }

        protected virtual void Awake()
        {
            _transform = transform;
        }
    }
}