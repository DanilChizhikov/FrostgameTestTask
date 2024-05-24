using Cysharp.Threading.Tasks;
using TestTask.StateMachine;

namespace TestTask.UserInterface
{
    internal sealed class GameplayScreenModel : ScreenModel
    {
        private readonly IGameStateMachine _stateMachine;
        
        public override ScreenType Type => ScreenType.Gameplay;

        public GameplayScreenModel(IGameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public override async UniTask ShowAsync()
        {
            await _stateMachine.EnterAsync<IGameplayState>(default);
            await base.ShowAsync();
        }

        public void ExitToMenu()
        {
            SetNext(ScreenType.Menu);
        }
    }
}