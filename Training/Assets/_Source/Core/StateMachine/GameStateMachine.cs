using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

namespace Core
{
    public class GameStateMachine<T> : IStateMachine where T : AState
    {
        private Dictionary<Type, T> _states;
        private AState _currentState;

        [Inject]
        public GameStateMachine(IEnumerable<AState> states)
        {
            _states = new Dictionary<Type, T>();
            foreach (AState state in states)
            {
                _states.Add(state.GetType(), (T)state);
            }
        }

        public void ChangeState<T>() where T: AState
        {
            if (!_states.ContainsKey(typeof(T)))
                return;

            _currentState?.Exit();
            _currentState = _states[typeof(T)];
            _currentState.Enter();
        }
    }
}