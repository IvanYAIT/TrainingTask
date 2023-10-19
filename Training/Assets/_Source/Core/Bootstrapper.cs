using VContainer;
using VContainer.Unity;

namespace Core
{
    public class Bootstrapper : IStartable
    {
        private IStateMachine _stateMachine;

        [Inject]
        public Bootstrapper(IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Start()
        {
            _stateMachine.ChangeState<PauseState>();
        }
    }
}