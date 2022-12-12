namespace States
{
    public abstract class State : IState
    {
        public void Enter(DataProvider dataProvider)
        {
            OnEnter(dataProvider);
        }

        public void End(DataProvider dataProvider)
        {
            OnEnd(dataProvider);
        }

        protected abstract void OnEnter(DataProvider dataProvider);
        protected abstract void OnEnd(DataProvider dataProvider);

    }
}