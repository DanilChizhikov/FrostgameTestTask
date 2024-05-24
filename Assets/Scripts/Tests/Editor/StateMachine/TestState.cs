using System.Threading;
using Cysharp.Threading.Tasks;
using TestTask.StateMachine;
using Utils;

namespace TestTask.Tests.StateMachine
{
    internal sealed class TestState : IState, IInstallable<bool>
    {
        public bool IsInstalled { get; private set; }
        
        public async UniTask EnterAsync(CancellationToken token)
        {
        }

        void IInstallable<bool>.Install(bool data)
        {
            IsInstalled = data;
        }
    }
}