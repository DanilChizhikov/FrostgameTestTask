using Cysharp.Threading.Tasks;

namespace TestTask.Levels
{
    public interface ILevelService
    {
        UniTask<ILevelView> LoadAsync(string levelId);
        UniTask UnloadAsync();
    }
}