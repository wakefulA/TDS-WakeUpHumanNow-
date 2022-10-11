﻿using System.Collections.Generic;
using System;

namespace TDS.Infrastructure.StateMachine
{
    public class GameStateMachine : IGameStateMachine
    {
        private readonly Dictionary<Type, IState> _states;

        private IState _currentState;

        public GameStateMachine()
        {
            _states = new Dictionary<Type, IState>()
            {
                {typeof(BootstrapeState), new BootstrapeState(this)},
                {typeof(MenuState), new MenuState(this)},
                {typeof(GameState), new GameState(this)},
            };
        }
        
        
        


        public void Enter<TState>() where TState : IState
        {
            _currentState?.Exit();
            _currentState = _states[typeof(TState)];
            _currentState.Enter();
        }
    }
}