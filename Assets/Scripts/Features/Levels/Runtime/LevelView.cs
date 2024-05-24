using UnityEngine;

namespace TestTask.Levels
{
    internal sealed class LevelView : MonoBehaviour, ILevelView
    {
        [SerializeField] private Transform _playerSpawn = default;

        public Vector3 PlayerPosition => _playerSpawn.position;
        public Quaternion PlayerRotation => _playerSpawn.rotation;
    }
}