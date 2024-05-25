using System;
using System.Collections.Generic;
using UnityEngine;

namespace TestTask.Units
{
    [CreateAssetMenu(fileName = "EntityDatabase", menuName = "Data/EntityDatabase", order = 0)]
    internal sealed class EntityDatabase : ScriptableObject
    {
        [SerializeField] private EntityInfo[] _infos = Array.Empty<EntityInfo>();
        
        public IReadOnlyList<EntityInfo> Infos => _infos;
    }
}