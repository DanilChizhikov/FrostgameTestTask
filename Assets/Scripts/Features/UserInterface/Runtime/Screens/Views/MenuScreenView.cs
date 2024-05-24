using TestTask.Levels;
using UnityEngine;
using UnityEngine.UI;

namespace TestTask.UserInterface
{
    internal sealed class MenuScreenView : ScreenView<MenuScreenViewModel>
    {
        [SerializeField, LevelId] private string _levelId = string.Empty;
        [SerializeField] private Button _loadGameButton = default;

        protected override void Show()
        {
            base.Show();
            _loadGameButton.onClick.AddListener(LoadGameButtonClickCallback);
        }

        protected override void Hide()
        {
            base.Hide();
            _loadGameButton.onClick.RemoveListener(LoadGameButtonClickCallback);
        }

        private void LoadGameButtonClickCallback()
        {
            ViewModel.EnterToGame(_levelId);
        }
    }
}