using System;
using System.Collections.Generic;
using UnityEngine;

namespace TestTask.Cameras.Runtime
{
    [CreateAssetMenu(fileName = "CameraDatabase", menuName = "Data/CameraDatabase", order = 0)]
    internal sealed class CameraDatabase : ScriptableObject
    {
        [SerializeField] private CameraInfo[] _infos = Array.Empty<CameraInfo>();
        
        public IReadOnlyList<CameraInfo> Infos => _infos;
    }
}