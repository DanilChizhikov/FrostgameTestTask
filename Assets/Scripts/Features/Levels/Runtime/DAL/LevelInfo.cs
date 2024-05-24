using System;
using TestTask.Utils;
using UnityEngine;

namespace TestTask.Levels
{
    [Serializable]
    internal struct LevelInfo
    {
        [SerializeField] private string _id;
        [SerializeField, Scene] private int _sceneIndex;
        
        public string Id => _id;
        public int SceneIndex => _sceneIndex;
    }
}