using UnityEngine;
using VContainer;
using VContainer.Unity;

public class RootLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<ActionBinder>(Lifetime.Scoped).AsImplementedInterfaces();
        builder.Register<CustomizationData>(Lifetime.Singleton);
        builder.Register<UIProvider>(Lifetime.Singleton);
    }
}
