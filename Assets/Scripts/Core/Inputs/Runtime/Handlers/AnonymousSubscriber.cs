using System;

namespace TestTask.Inputs
{
    internal sealed class AnonymousSubscriber<T> : IDisposable
        where T : IInputListener
    {
        private bool _isDisposed;
        
        public T Listener { get; }
        public Action<AnonymousSubscriber<T>> DisposedCallback { get; }

        public AnonymousSubscriber(T listener, Action<AnonymousSubscriber<T>> disposedCallback)
        {
            Listener = listener;
            DisposedCallback = disposedCallback;
            _isDisposed = false;
        }
        
        public void Dispose()
        {
            if (_isDisposed)
            {
                return;
            }
            
            DisposedCallback.Invoke(this);
            _isDisposed = true;
        }
    }
}