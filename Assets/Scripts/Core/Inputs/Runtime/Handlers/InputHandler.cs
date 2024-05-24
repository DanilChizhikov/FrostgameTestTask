using System;
using System.Collections.Generic;

namespace TestTask.Inputs
{
    internal abstract class InputHandler
    {
        public abstract bool IsServicedListener(IInputListener listener);
        public abstract void Enable(InputControls controls);
        public abstract IDisposable Subscribe(IInputListener listener);
        public abstract void Disable(InputControls controls);
    }
    
    internal abstract class InputHandler<T> : InputHandler
        where T : IInputListener
    {
        private readonly List<T> _listeners;
        private readonly Dictionary<T, IDisposable> _subscriptions;
        
        protected bool IsEnabled = false;
        protected IReadOnlyList<T> Listeners => _listeners;

        public InputHandler()
        {
            _listeners = new List<T>();
            _subscriptions = new Dictionary<T, IDisposable>();
        }
        
        public sealed override bool IsServicedListener(IInputListener listener)
        {
            return listener is T;
        }

        public sealed override void Enable(InputControls controls)
        {
            if (IsEnabled)
            {
                return;
            }

            Subscribe(controls);
            IsEnabled = true;
        }

        public sealed override IDisposable Subscribe(IInputListener listener)
        {
            if (listener is not T genericListener)
            {
                throw new ArgumentException();
            }

            if (!_subscriptions.TryGetValue(genericListener, out IDisposable subscription))
            {
                subscription = new AnonymousSubscriber<T>(genericListener, AnonymousSubscriberDisposed);
                _subscriptions.Add(genericListener, subscription);
                _listeners.Add(genericListener);
                if (IsEnabled)
                {
                    PostAddListener(genericListener);
                }
            }

            return subscription;
        }

        public sealed override void Disable(InputControls controls)
        {
            if (!IsEnabled)
            {
                return;
            }
            
            UnSubscribe(controls);
            IsEnabled = false;
        }

        protected abstract void Subscribe(InputControls controls);
        protected abstract void PostAddListener(T listener);
        protected abstract void UnSubscribe(InputControls controls);
        
        private void AnonymousSubscriberDisposed(AnonymousSubscriber<T> subscriber)
        {
            _subscriptions.Remove(subscriber.Listener);
            _listeners.Remove(subscriber.Listener);
        }
    }
}