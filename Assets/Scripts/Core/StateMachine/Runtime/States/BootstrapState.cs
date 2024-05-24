using System.Threading;
using Cysharp.Threading.Tasks;

namespace TestTask.StateMachine.States
{
    internal sealed class BootstrapState : IBootstrapState
    {
        public async UniTask EnterAsync(CancellationToken token)
        {
        }
    }
}