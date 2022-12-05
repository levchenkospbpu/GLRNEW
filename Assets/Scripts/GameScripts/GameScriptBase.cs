namespace GameScripts
{
    public abstract class GameScriptBase : IGameScript
    {
        public bool IsEnabled { get; set; }
        
        public abstract void OnStart();
        public abstract void OnDestroy();

        protected void StopThisGameScript()
        {
            IsEnabled = false;
            OnDestroy();
        }
    }
}