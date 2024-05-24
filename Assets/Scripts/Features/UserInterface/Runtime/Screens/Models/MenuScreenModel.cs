using Cysharp.Threading.Tasks;
using TestTask.StateMachine;

namespace TestTask.UserInterface
{
    internal sealed class MenuScreenModel : ScreenModel
    {
        private readonly IGameStateMachine _stateMachine;
        
        public override ScreenType Type => ScreenType.Menu;

        public MenuScreenModel(IGameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
        
        public override async UniTask ShowAsync()
        {
            await _stateMachine.EnterAsync<IMenuState>(default);
            await base.ShowAsync();
        }

        public void LoadGame()
        {
            SetNext(ScreenType.Gameplay);
        }
    }
}