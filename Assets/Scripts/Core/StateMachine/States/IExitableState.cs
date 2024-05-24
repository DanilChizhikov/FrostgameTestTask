using Cysharp.Threading.Tasks;

namespace TestTask.StateMachine
{
    public interface IExitableState
    {
        UniTask ExitAsync();
    }
}