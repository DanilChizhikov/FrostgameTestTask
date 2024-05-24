namespace TestTask.UserInterface
{
    internal sealed class MenuScreenViewModel : ScreenViewModel<MenuScreenModel>
    {
        public MenuScreenViewModel(ScreenModelProvider provider) : base(provider)
        {
        }
        
        public void EnterToGame()
        {
            Model.LoadGame();
        }
    }
}