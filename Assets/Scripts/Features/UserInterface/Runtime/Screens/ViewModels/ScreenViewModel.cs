using System;

namespace TestTask.UserInterface
{
    internal abstract class ScreenViewModel
    {
        public abstract event Action OnShow;
        public abstract event Action OnHide;
        public abstract event Action OnDisposed;
    }

    internal abstract class ScreenViewModel<TModel> : ScreenViewModel
        where TModel : ScreenModel
    {
        public sealed override event Action OnShow;
        public sealed override event Action OnHide;
        public sealed override event Action OnDisposed;
        
        protected TModel Model { get; }

        public ScreenViewModel(ScreenModelProvider provider)
        {
            if (!provider.TryGetScreenModel(typeof(TModel), out ScreenModel model))
            {
                throw new Exception("Model not found");
            }
            
            Model = (TModel) model;
            Subscribe(Model);
        }

        protected virtual void Show()
        {
            OnShow?.Invoke();
        }
        
        protected virtual void Hide()
        {
            OnHide?.Invoke();
        }
        
        private void Subscribe(TModel model)
        {
            model.OnShow += Show;
            model.OnHide += Hide;
            model.OnDisposed += Disposed;
        }
        
        private void Unsubscribe(TModel model)
        {
            model.OnShow -= Show;
            model.OnHide -= Hide;
            model.OnDisposed -= Disposed;
        }
        
        private void Disposed()
        {
            Unsubscribe(Model);
            OnDisposed?.Invoke();
        }
    } 
}