using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace TestTask.StateMachine
{
    internal sealed class GameStateMachine : IGameStateMachine, IDisposable
    {
        public event Action<IState> OnStateEntered;

        private readonly List<IState> _states;
        private readonly Dictionary<Type, IState> _stateMap;
        
        private IState _currentState;

        public IState CurrentState
        {
            get => _currentState;
            private set => _currentState = value;
        }

        public GameStateMachine(IEnumerable<IState> states)
        {
            _states = new List<IState>(states);
            _stateMap = new Dictionary<Type, IState>(_states.Count);
        }
        
        public async UniTask EnterAsync<TState>(CancellationToken token) where TState : IState
        {
        }

        public async UniTask EnterAsync<TState, TData>(TData data, CancellationToken token) where TState : IState
        {
        }

        public void Dispose()
        {
            
        }
    }
}