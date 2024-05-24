using System;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace TestTask.StateMachine
{
    public interface IGameStateMachine
    {
        event Action<IState> OnStateEntered;
        
        IState CurrentState { get; }

        UniTask EnterAsync<TState>(CancellationToken token) where TState : IState;
        UniTask EnterAsync<TState, TData>(TData data, CancellationToken token) where TState : IState;
    }
}