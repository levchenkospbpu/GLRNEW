namespace GameScripts
{
    public interface IGameScript
    {
        bool IsEnabled { set; get; }
        void OnStart();
        void OnDestroy();
    }
}