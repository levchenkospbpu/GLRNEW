namespace States
{
    public interface IState
    {
        void Enter(DataProvider dataProvider);
        void End(DataProvider dataProvider);
    }
}