using Cysharp.Threading.Tasks;

namespace TestTask.Saves
{
    public interface ISaveStorage
    {
        UniTask InitializeAsync();
        UniTask WriteAsync(string key, string value);
        UniTask<string> ReadAsync(string key, string defaultValue);
        UniTask RemoveAsync(string key);
    }
}