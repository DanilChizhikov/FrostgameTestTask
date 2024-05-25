using Cysharp.Threading.Tasks;

namespace TestTask.Saves
{
    public interface ISaveService
    {
        UniTask SaveAsync<T>(string key, T value);
        UniTask<T> LoadAsync<T>(string key, T defaultValue);
    }
}