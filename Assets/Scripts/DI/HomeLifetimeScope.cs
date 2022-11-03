using UnityEngine;
using VContainer;
using VContainer.Unity;

public class HomeLifetimeScope : LifetimeScope
{
    [SerializeField] private UIProviderConfig _uiProviderConfig;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<ActionBinder>(Lifetime.Scoped).AsImplementedInterfaces();
        builder.RegisterInstance(_uiProviderConfig);
    }
}
