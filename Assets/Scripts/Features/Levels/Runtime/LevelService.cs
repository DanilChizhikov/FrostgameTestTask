using System;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace TestTask.Levels
{
    internal sealed class LevelService : ILevelService
    {
        private readonly LevelRepository _repository;
        private readonly LevelViewProvider _viewProvider;

        private int _currentSceneIndex;

        public LevelService(LevelRepository repository, LevelViewProvider viewProvider)
        {
            _repository = repository;
            _viewProvider = viewProvider;
            CleanupSceneIndex();
        }
        
        public async UniTask<ILevelView> LoadAsync(string levelId)
        {
            if (!_repository.TryGetScene(levelId, out int sceneIndex))
            {
                throw new Exception($"Level {levelId} not found");
            }

            await SceneManager.LoadSceneAsync(sceneIndex).ToUniTask();
            _currentSceneIndex = sceneIndex;
            ILevelView levelView = await _viewProvider.GetLevel(sceneIndex);
            return levelView;
        }

        public void SetLevel(string levelId)
        {
            if (!_repository.TryGetScene(levelId, out int sceneIndex))
            {
                throw new Exception($"Level {levelId} not found");
            }
            
            _currentSceneIndex = sceneIndex;
        }

        public async UniTask<ILevelView> LoadAsync()
        {
            if (_currentSceneIndex < 0)
            {
                throw new Exception("Level not selected");
            }

            await SceneManager.LoadSceneAsync(_currentSceneIndex, LoadSceneMode.Additive).ToUniTask();
            ILevelView levelView = await _viewProvider.GetLevel(_currentSceneIndex);
            return levelView;
        }

        public async UniTask UnloadAsync()
        {
            if (_currentSceneIndex < 0)
            {
                return;
            }
            
            await SceneManager.UnloadSceneAsync(_currentSceneIndex).ToUniTask();
            CleanupSceneIndex();
        }

        private void CleanupSceneIndex()
        {
            _currentSceneIndex = -1;
        }
    }
}