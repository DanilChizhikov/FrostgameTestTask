namespace TestTask.UserInterface
{
    public interface IUIService
    {
        bool TryShow(ScreenType type, TransitionType transitionType = TransitionType.Instance);
    }
}