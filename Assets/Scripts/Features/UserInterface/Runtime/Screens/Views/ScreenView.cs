using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace TestTask.UserInterface
{
    [RequireComponent(typeof(Canvas))]
    internal abstract class ScreenView<TViewModel> : UIBehaviour
        where TViewModel : ScreenViewModel
    {
        protected TViewModel ViewModel { get; private set; }
        
        [Inject]
        public void Install(TViewModel viewModel)
        {
            gameObject.SetActive(false);
            ViewModel = viewModel;
            viewModel.OnDisposed += Disposed;
            SubscribeViewModel();
            PostInstall();
        }

        protected virtual void PostInstall()
        {
        }
        
        protected virtual void Show()
        {
            gameObject.SetActive(true);
        }
        
        protected virtual void Hide()
        {
            gameObject.SetActive(false);
        }

        protected sealed override void OnDestroy()
        {
            Disposed();
            base.OnDestroy();
        }

        protected virtual void PreDisposed()
        {
            
        }
        
        private void SubscribeViewModel()
        {
            if (ViewModel == null)
            {
                return;
            }
            
            ViewModel.OnShow += Show;
            ViewModel.OnHide += Hide;
            ViewModel.OnDisposed += Disposed;
        }
        
        private void UnsubscribeViewModel()
        {
            if (ViewModel == null)
            {
                return;
            }
            
            ViewModel.OnShow -= Show;
            ViewModel.OnHide -= Hide;
            ViewModel.OnDisposed -= Disposed;
        }

        private void Disposed()
        {
            if (ViewModel == null)
            {
                return;
            }
            
            UnsubscribeViewModel();
            PreDisposed();
            ViewModel.OnDisposed -= Disposed;
            ViewModel = null;
        }
    }
}