namespace TestTask.UserInterface
{
    internal sealed class GameplayScreenModel : ScreenModel
    {
        public override ScreenType Type => ScreenType.Gameplay;

        public void ExitToMenu()
        {
            SetNext(ScreenType.Menu);
        }
    }
}