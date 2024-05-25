using System;
using System.Collections.Generic;
using UnityEngine;

namespace TestTask.Units
{
    [CreateAssetMenu(fileName = "UnitDatabase", menuName = "Data/UnitDatabase", order = 0)]
    internal sealed class UnitDatabase : ScriptableObject
    {
        [SerializeField] private UnitConfig[] _configs = Array.Empty<UnitConfig>();
        
        public IReadOnlyList<IUnitConfig> Configs => _configs;
    }
}