using TestTask.Navigation;
using UnityEngine;

namespace TestTask.Units
{
    [RequireComponent(typeof(Rigidbody))]
    internal sealed partial class UnitEntity :  MonoBehaviour, IUnitEntity
    {
        [SerializeField] private Rigidbody _rigidbody = default;
        [SerializeField] private Animator _animator = default;
        
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

        public Rigidbody Rigidbody => _rigidbody;
        public Animator Animator => _animator;

        public void Initialize(uint id)
        {
            Id = id;
        }

        private void SetPosition(Vector3 value)
        {
            Rigidbody.isKinematic = true;
            _transform.position = value;
            Rigidbody.isKinematic = false;
        }
        
        private void SetRotation(Quaternion value)
        {
            Rigidbody.isKinematic = true;
            _transform.rotation = value;
            Rigidbody.isKinematic = false;
        }

        private void Awake()
        {
            _transform = transform;
        }
    }
}