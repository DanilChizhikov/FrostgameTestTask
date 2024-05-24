using Cysharp.Threading.Tasks;
using TestTask.Levels;
using TestTask.StateMachine;

namespace TestTask.UserInterface
{
    internal sealed class MenuScreenModel : ScreenModel
    {
        private readonly IGameStateMachine _stateMachine;
        private readonly ILevelService _levelService;
        
        public override ScreenType Type => ScreenType.Menu;

        public MenuScreenModel(IGameStateMachine stateMachine, ILevelService levelService)
        {
            _stateMachine = stateMachine;
            _levelService = levelService;
        }
        
        public override async UniTask ShowAsync()
        {
            await _stateMachine.EnterAsync<IMenuState>(default);
            await base.ShowAsync();
        }

        public void LoadGame(string levelId)
        {
            _levelService.SetLevel(levelId);
            SetNext(ScreenType.Gameplay);
        }
    }
}