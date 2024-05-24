using System;
using Cysharp.Threading.Tasks;

namespace TestTask.UserInterface
{
    internal abstract class ScreenModel : IDisposable
    {
        public event Action<ScreenModel, ScreenType, TransitionType> OnNext;
        public event Action OnShow;
        public event Action OnHide;
        public event Action OnDisposed;
        
        public abstract ScreenType Type { get; }

        public virtual UniTask ShowAsync()
        {
            OnShow?.Invoke();
            return UniTask.CompletedTask;
        }
        
        public virtual UniTask HideAsync()
        {
            OnHide?.Invoke();
            return UniTask.CompletedTask;
        }
        
        public virtual void Dispose()
        {
            OnDisposed?.Invoke();
        }
        
        protected void SetNext(ScreenType type, TransitionType transition = TransitionType.Instance) => OnNext?.Invoke(this, type, transition);
    }
}