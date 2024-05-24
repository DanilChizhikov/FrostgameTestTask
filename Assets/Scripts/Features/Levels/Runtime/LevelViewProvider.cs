using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace TestTask.Levels
{
    internal sealed class LevelViewProvider : IDisposable
    {
        private readonly Dictionary<int, ILevelView> _viewsMap;
        
        public LevelViewProvider()
        {
            _viewsMap = new Dictionary<int, ILevelView>();
            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.sceneUnloaded += OnSceneUnloaded;
        }

        public async UniTask<ILevelView> GetLevel(int index)
        {
            await UniTask.WaitUntil(() => _viewsMap.ContainsKey(index));
            return _viewsMap[index];
        }

        public void Dispose()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
        
        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            ILevelView levelView = scene.GetLevelView();
            if (levelView != null)
            {
                _viewsMap.Add(scene.buildIndex, levelView);
            }
        }
        
        private void OnSceneUnloaded(Scene scene)
        {
            _viewsMap.Remove(scene.buildIndex);
        }
    }
}