namespace TestTask.UserInterface
{
    internal sealed class GameplayScreenViewModel : ScreenViewModel<GameplayScreenModel>
    {
        public GameplayScreenViewModel(ScreenModelProvider provider) : base(provider)
        {
        }

        public void ExitToMenu()
        {
            Model.ExitToMenu();
        }
    }
}