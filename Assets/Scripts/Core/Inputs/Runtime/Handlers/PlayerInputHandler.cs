using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

namespace TestTask.Inputs
{
    internal sealed class PlayerInputHandler : InputHandler<IPlayerInputListener>
    {
        private Vector2 _lastInput;

        public PlayerInputHandler()
        {
            CleanupLastInput();
        }
        
        protected override void Subscribe(InputControls controls)
        {
            CleanupLastInput();
            controls.Player.Click.performed += ClickPerformed;
            controls.Player.Position.performed += PositionPerformed;
        }

        protected override void PostAddListener(IPlayerInputListener listener)
        {
            if (_lastInput != Vector2.positiveInfinity)
            {
                listener.OnMove(_lastInput);
            }
        }

        protected override void UnSubscribe(InputControls controls)
        {
            controls.Player.Click.performed -= ClickPerformed;
            controls.Player.Position.performed -= PositionPerformed;
        }

        private void CleanupLastInput()
        {
            _lastInput = Vector2.positiveInfinity;
        }
        
        private void ClickPerformed(InputAction.CallbackContext context)
        {
            Vector2Control position = Mouse.current.position;
            if (!context.performed)
            {
                return;
            }

            for (int i = 0; i < Listeners.Count; i++)
            {
                Listeners[i].OnMove(_lastInput);
            }
        }
        
        private void PositionPerformed(InputAction.CallbackContext context)
        {
            _lastInput = context.ReadValue<Vector2>();
        }
    }
}