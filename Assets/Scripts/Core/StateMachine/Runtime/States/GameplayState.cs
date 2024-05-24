using System.Threading;
using Cysharp.Threading.Tasks;
using TestTask.Inputs;
using TestTask.Levels;

namespace TestTask.StateMachine.States
{
    internal sealed class GameplayState : IGameplayState
    {
        private readonly IInputService _inputService;
        private readonly ILevelService _levelService;

        public GameplayState(IInputService inputService, ILevelService levelService)
        {
            _inputService = inputService;
            _levelService = levelService;
        }
        
        public async UniTask EnterAsync(CancellationToken token)
        {
            await _levelService.LoadAsync();
            _inputService.Enable();
        }

        public async UniTask ExitAsync()
        {
            _inputService.Disable();
            await _levelService.UnloadAsync();
        }
    }
}