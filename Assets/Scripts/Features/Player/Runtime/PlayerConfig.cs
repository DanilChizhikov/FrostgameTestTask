using System;
using TestTask.Cameras;
using UnityEngine;

namespace TestTask.Player
{
    [Serializable]
    internal struct PlayerConfig
    {
        [SerializeField, PlayerId] private string _player;
        [SerializeField, CameraId] private string _cameraId;
        
        public string Player => _player;
        public string CameraId => _cameraId;
    }
}