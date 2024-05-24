using System;
using System.Collections.Generic;

namespace TestTask.Inputs
{
    internal sealed class InputService : IInputService, IDisposable
    {
        private readonly List<InputHandler> _handlers;
        private readonly Dictionary<Type, int> _handlersMap;
        private readonly InputControls _controls;
        
        private bool _isEnabled;
        private bool _isDisposed;

        public InputService(IEnumerable<InputHandler> handlers)
        {
            _handlers = new List<InputHandler>(handlers);
            _handlersMap = new Dictionary<Type, int>(_handlers.Count);
            _controls = new InputControls();
            _isEnabled = false;
            _isDisposed = false;
        }
        
        public void Enable()
        {
            ThrowIfDisposed();
            if (_isEnabled)
            {
                return;
            }

            EnableHandlers();
            _controls.Enable();
            _isEnabled = true;
        }

        public IDisposable Subscribe(IInputListener listener)
        {
            ThrowIfDisposed();
            if (!TryGetHandler(listener, out InputHandler handler))
            {
                throw new ArgumentException();
            }
            
            return handler.Subscribe(listener);
        }

        public void Disable()
        {
            ThrowIfDisposed();
            if (!_isEnabled)
            {
                return;
            }
            
            _controls.Disable();
            DisableHandlers();
            _isEnabled = false;
        }

        public void Dispose()
        {
            if (_isDisposed)
            {
                return;
            }
            
            Disable();
            _controls.Disable();
            _isDisposed = true;
        }
        
        private void ThrowIfDisposed()
        {
            if (_isDisposed)
            {
                throw new ObjectDisposedException(nameof(InputService));
            }
        }
        
        private void EnableHandlers()
        {
            for (int i = 0; i < _handlers.Count; i++)
            {
                _handlers[i].Enable(_controls);
            }
        }
        
        private bool TryGetHandler(IInputListener listener, out InputHandler inputHandler)
        {
            bool hasHandler = _handlersMap.TryGetValue(listener.GetType(), out int index);
            if (!hasHandler)
            {
                index = GetHandlerIndex(listener);
                hasHandler = index >= 0;
                if (hasHandler)
                {
                    _handlersMap.Add(listener.GetType(), index);
                }
            }
            
            inputHandler = hasHandler ? _handlers[index] : null;
            return hasHandler;
        }

        private int GetHandlerIndex(IInputListener listener)
        {
            for (int i = 0; i < _handlers.Count; i++)
            {
                if (_handlers[i].IsServicedListener(listener))
                {
                    return i;
                }
            }

            return -1;
        }
        
        private void DisableHandlers()
        {
            for (int i = 0; i < _handlers.Count; i++)
            {
                _handlers[i].Disable(_controls);
            }
        }
    }
}