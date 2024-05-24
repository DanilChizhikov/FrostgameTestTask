using UnityEngine;
using UnityEngine.UI;

namespace TestTask.UserInterface
{
    internal sealed class GameplayScreenView : ScreenView<GameplayScreenViewModel>
    {
        [SerializeField] private Button _exitToMenuButton = default;

        protected override void Show()
        {
            base.Show();
            _exitToMenuButton.onClick.AddListener(ExitButtonClickCallback);
        }
        
        protected override void Hide()
        {
            _exitToMenuButton.onClick.RemoveListener(ExitButtonClickCallback);
            base.Hide();
        }

        private void ExitButtonClickCallback()
        {
            ViewModel.ExitToMenu();
        }
    }
}