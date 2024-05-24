using Cysharp.Threading.Tasks;
using TestTask.StateMachine;

namespace TestTask.UserInterface
{
    internal sealed class LoadingScreenModel : ScreenModel
    {
        private readonly IGameStateMachine _stateMachine;
        
        public override ScreenType Type => ScreenType.Loading;

        public LoadingScreenModel(IGameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
        
        public override async UniTask ShowAsync()
        {
            base.ShowAsync();
            EnterToBootstrap().Forget();
        }
        
        private async UniTask EnterToBootstrap()
        {
            await _stateMachine.EnterAsync<IBootstrapState>(default);
            await UniTask.Delay(5000);
            SetNext(ScreenType.Menu);
        }
    }
}