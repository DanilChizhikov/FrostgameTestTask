using Cysharp.Threading.Tasks;

namespace TestTask.Levels
{
    public interface ILevelService
    {
        void SetLevel(string levelId);
        UniTask<ILevelView> LoadAsync();
        UniTask UnloadAsync();
    }
}