using Cysharp.Threading.Tasks;

namespace TestTask.Levels
{
    internal sealed class LevelService : ILevelService
    {
        public async UniTask<ILevelView> LoadAsync(string levelId)
        {
            return null;
        }

        public async UniTask UnloadAsync()
        {
        }
    }
}