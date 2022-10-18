﻿namespace TDS.Infrastructure.StateMachine
{
    public interface IState : IExitableState
    {
        void Enter();
    
    }

    public interface IExitableState
    {
        void Exit();
    }
}