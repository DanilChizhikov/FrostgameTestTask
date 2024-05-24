using System;

namespace TestTask.Inputs
{
    public interface IInputService
    {
        void Enable();
        IDisposable Subscribe(IInputListener listener);
        void Disable();
    }
}