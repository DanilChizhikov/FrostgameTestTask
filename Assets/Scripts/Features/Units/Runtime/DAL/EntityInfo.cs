using System;
using UnityEngine;

namespace TestTask.Units
{
    [Serializable]
    internal struct EntityInfo
    {
        [SerializeField] private string _id;
        [SerializeField] private UnitEntity _entity;
        
        public string Id => _id;
        public UnitEntity Entity => _entity;
    }
}