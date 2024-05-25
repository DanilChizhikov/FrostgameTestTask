using System;
using TestTask.Units;
using UnityEngine;

namespace TestTask.Player
{
    [Serializable]
    internal struct PlayerInfo
    {
        [SerializeField] private string _id;
        [SerializeField, UnitId] private string _unitId;
        
        public string Id => _id;
        public string UnitId => _unitId;
    }
}