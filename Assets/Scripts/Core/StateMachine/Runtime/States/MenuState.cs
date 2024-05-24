using System.Threading;
using Cysharp.Threading.Tasks;

namespace TestTask.StateMachine.States
{
    internal sealed class MenuState : IMenuState
    {
        public async UniTask EnterAsync(CancellationToken token)
        {
        }
    }
}