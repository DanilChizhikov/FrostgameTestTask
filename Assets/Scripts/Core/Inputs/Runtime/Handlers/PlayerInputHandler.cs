using UnityEngine;
using UnityEngine.InputSystem;

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
            controls.Player.Move.performed += MovePerformed;
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
            controls.Player.Move.performed -= MovePerformed;
        }

        private void CleanupLastInput()
        {
            _lastInput = Vector2.positiveInfinity;
        }
        
        private void MovePerformed(InputAction.CallbackContext context)
        {
            _lastInput = context.ReadValue<Vector2>();
            for (int i = 0; i < Listeners.Count; i++)
            {
                Listeners[i].OnMove(_lastInput);
            }
        }
    }
}