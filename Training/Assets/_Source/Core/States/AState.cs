namespace Core
{
    public abstract class AState
    {
        public virtual void Enter() { }
        public virtual void Exit() { }

        public virtual void Update() { }
    }
}