using System.Threading;
using Cysharp.Threading.Tasks;

namespace TestTask.StateMachine
{
    public interface IState
    {
        UniTask EnterAsync(CancellationToken token);
    }
}