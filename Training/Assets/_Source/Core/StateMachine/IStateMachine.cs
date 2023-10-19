using System;

namespace Core
{
    public interface IStateMachine
    {
        void ChangeState<T>() where  T : AState;
    }
}