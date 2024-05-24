using System.Threading;
using Cysharp.Threading.Tasks;
using TestTask.Inputs;

namespace TestTask.StateMachine.States
{
    internal sealed class GameplayState : IGameplayState
    {
        private readonly IInputService _inputService;

        public GameplayState(IInputService inputService)
        {
            _inputService = inputService;
        }
        
        public async UniTask EnterAsync(CancellationToken token)
        {
            _inputService.Enable();
        }

        public async UniTask ExitAsync()
        {
            _inputService.Disable();
        }
    }
}