using System;
using UnityEngine;

namespace TestTask.Player
{
    [Serializable]
    internal struct PlayerConfig
    {
        [SerializeField, PlayerId] private string _player;
        
        public string Player => _player;
    }
}