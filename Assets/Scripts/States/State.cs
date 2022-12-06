namespace States
{
    public abstract class State : IState
    {
        public void Enter()
        {
            OnEnter();
        }

        public void End()
        {
            OnEnd();
        }

        protected abstract void OnEnter();
        protected abstract void OnEnd();

    }
}