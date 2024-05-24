using System;
using TestTask.Inputs;

namespace TestTask.Core.Inputs.Runtime
{
    internal sealed class InputService : IInputService, IDisposable
    {
        public void Enable()
        {
            
        }

        public IDisposable Subscribe(IInputListener listener)
        {
            return null;
        }

        public void Disable()
        {
            
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}