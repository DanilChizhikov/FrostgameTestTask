using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace TestTask.UserInterface
{
    internal sealed class UIService : IUIService
    {
        private readonly Dictionary<ScreenType, ScreenModel> _screenMap;
        private readonly Stack<ScreenType> _activeScreens;
        
        public UIService(IEnumerable<ScreenModel> models)
        {
            _screenMap = new Dictionary<ScreenType, ScreenModel>();
            _activeScreens = new Stack<ScreenType>();
            foreach (ScreenModel model in models)
            {
                if (_screenMap.TryAdd(model.Type, model))
                {
                    model.OnNext += ModelSetNextCallback;
                }
            }
        }

        public bool TryShow(ScreenType type, TransitionType transitionType = TransitionType.Instance)
        {
            bool result = _activeScreens.Contains(type);
            if (!result)
            {
                if (_screenMap.TryGetValue(type, out ScreenModel nextScreen))
                {
                    while (_activeScreens.TryPop(out ScreenType activeScreen))
                    {
                        _screenMap[activeScreen].HideAsync().Forget();
                    }
                    
                    _activeScreens.Push(type);
                    nextScreen.ShowAsync().Forget();
                    result = true;
                }
            }
            
            return result;
        }
        
        private void ModelSetNextCallback(ScreenModel model, ScreenType nextScreen, TransitionType transition)
        {
            if (!_activeScreens.TryPeek(out ScreenType topScreen) ||
                topScreen  == nextScreen ||
                model.Type == topScreen)
            {
                return;
            }

            TryShow(nextScreen, transition);
        }
    }
}