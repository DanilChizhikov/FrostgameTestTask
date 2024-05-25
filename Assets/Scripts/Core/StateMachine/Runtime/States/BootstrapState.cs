using System.Threading;
using Cysharp.Threading.Tasks;
using TestTask.Saves;

namespace TestTask.StateMachine.States
{
    internal sealed class BootstrapState : IBootstrapState
    {
        private readonly ISaveStorage _saveStorage;

        public BootstrapState(ISaveStorage saveStorage)
        {
            _saveStorage = saveStorage;
        }
        
        public async UniTask EnterAsync(CancellationToken token)
        {
            await _saveStorage.InitializeAsync();
        }
    }
}