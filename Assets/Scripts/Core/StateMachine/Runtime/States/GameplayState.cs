using System.Threading;
using Cysharp.Threading.Tasks;
using TestTask.Inputs;
using TestTask.Levels;
using TestTask.Player;

namespace TestTask.StateMachine.States
{
    internal sealed class GameplayState : IGameplayState
    {
        private readonly IInputService _inputService;
        private readonly ILevelService _levelService;
        private readonly IPlayerService _playerService;

        public GameplayState(IInputService inputService, ILevelService levelService, IPlayerService playerService)
        {
            _inputService = inputService;
            _levelService = levelService;
            _playerService = playerService;
        }
        
        public async UniTask EnterAsync(CancellationToken token)
        {
            ILevelView levelView = await _levelService.LoadAsync();
            await _playerService.CreatePlayerAsync(levelView.PlayerPosition, levelView.PlayerRotation);
            _inputService.Enable();
        }

        public async UniTask ExitAsync()
        {
            _inputService.Disable();
            await _playerService.RemovePlayerAsync();
            await _levelService.UnloadAsync();
        }
    }
}