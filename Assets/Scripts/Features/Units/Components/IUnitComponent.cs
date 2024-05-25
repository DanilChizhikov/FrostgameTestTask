using System;

namespace TestTask.Units
{
    public interface IUnitComponent : IDisposable
    {
    }

    public interface IUnitComponent<out TRequest, in TResponse> : IUnitComponent
    {
        TRequest GetData();
        void SetData(TResponse data);
    } 
}