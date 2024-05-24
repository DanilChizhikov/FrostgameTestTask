using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Utils;

namespace TestTask.StateMachine
{
    internal sealed class GameStateMachine : IGameStateMachine, IAsyncDisposable
    {
        public event Action<IState> OnStateEntered;

        private readonly List<IState> _states;
        private readonly Dictionary<Type, int> _stateMap;

        public IState CurrentState { get; private set; }

        public GameStateMachine(IEnumerable<IState> states)
        {
            _states = new List<IState>(states);
            _stateMap = new Dictionary<Type, int>(_states.Count);
        }
        
        public async UniTask EnterAsync<TState>(CancellationToken token) where TState : IState
        {
            if (!TryGetState<TState>(out IState state))
            {
                throw new Exception("State not found: " + typeof(TState));
            }

            ThrowIfSimilar(state);
            await SwitchStates(state, token);
        }

        private void ThrowIfSimilar(IState state)
        {
            if (CurrentState == state)
            {
                throw new Exception("State already entered: " + state.GetType().Name);
            }
        }

        public async UniTask EnterAsync<TState, TData>(TData data, CancellationToken token) where TState : IState
        {
            if (!TryGetState<TState>(out IState state))
            {
                throw new Exception("State not found: " + typeof(TState));
            }

            ThrowIfSimilar(state);
            TryInstallData(state, data);
            await SwitchStates(state, token);
        }

        public async ValueTask DisposeAsync()
        {
            await TryExitCurrentStateAsync();
        }

        private bool TryGetState<TState>(out IState state) where TState : IState
        {
            bool hasState = _stateMap.TryGetValue(typeof(TState), out int stateIndex);
            if (!hasState)
            {
                stateIndex = GetStateIndex<TState>();
                hasState = stateIndex >= 0;
                if (hasState)
                {
                    _stateMap.Add(typeof(TState), stateIndex);
                }
            }

            state = hasState ? _states[stateIndex] : null;
            return hasState;
        }

        private int GetStateIndex<TState>() where TState : IState
        {
            int stateIndex = -1;
            for (int i = 0; i < _states.Count; i++)
            {
                IState state = _states[i];
                if (state is TState)
                {
                    stateIndex = i;
                    break;
                }
            }
            
            return stateIndex;
        }

        private async UniTask SwitchStates(IState nextState, CancellationToken token)
        {
            await TryExitCurrentStateAsync(token);
            if (token.IsCancellationRequested)
            {
                return;
            }
            
            CurrentState = nextState;
            await nextState.EnterAsync(token);
            if (!token.IsCancellationRequested)
            {
                OnStateEntered?.Invoke(CurrentState);
            }
        }
        
        private async UniTask TryExitCurrentStateAsync(CancellationToken token = new CancellationToken())
        {
            if (CurrentState is IExitableState exitableState)
            {
                await exitableState.ExitAsync();
            }

            CurrentState = null;
        }

        private void TryInstallData<T>(IState state, T data)
        {
            if(state is IInstallable<T> installable)
            {
                installable.Install(data);
            }
        }
    }
}