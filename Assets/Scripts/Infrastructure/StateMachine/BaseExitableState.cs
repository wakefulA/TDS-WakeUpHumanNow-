﻿namespace TDS.Infrastructure.StateMachine
{
    public abstract class BaseExitableState : IExitableState
    {
        protected IGameStateMachine StateMachine { get; }

        protected BaseExitableState(IGameStateMachine gameStateMachine)
        {
            StateMachine = gameStateMachine;
        }


        
        public abstract void Exit();

        public abstract void Enter();
    }
}