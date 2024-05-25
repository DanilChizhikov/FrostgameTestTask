using Cysharp.Threading.Tasks;

namespace TestTask.Player
{
    public interface IPlayerSaveService
    {
        UniTask SaveAsync();
        UniTask LoadAsync();
    }
}