namespace GameScripts
{
    public abstract class GameScriptBase : IGameScript
    {
        protected bool IsEnabled;
        public abstract void OnStart();
        public abstract void OnDestroy();

        protected void StopThisGameScript()
        {
            IsEnabled = false;
            OnDestroy();
        }
    }
}