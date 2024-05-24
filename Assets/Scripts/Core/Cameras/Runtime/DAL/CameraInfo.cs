using System;
using UnityEngine;

namespace TestTask.Cameras.Runtime
{
    [Serializable]
    internal struct CameraInfo
    {
        [SerializeField] private string _id;
        [SerializeField] private CameraView _prefab;
        
        public string Id => _id;
        public CameraView Prefab => _prefab;
    }
}