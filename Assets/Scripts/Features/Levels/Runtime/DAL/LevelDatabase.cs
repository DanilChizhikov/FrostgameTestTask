using System;
using System.Collections.Generic;
using UnityEngine;

namespace TestTask.Levels
{
    [CreateAssetMenu(fileName = "LevelDatabase", menuName = "Data/LevelDatabase")]
    internal sealed class LevelDatabase : ScriptableObject
    {
        [SerializeField] private LevelInfo[] _infos = Array.Empty<LevelInfo>();
        
        public IReadOnlyList<LevelInfo> Infos => _infos;
    }
}