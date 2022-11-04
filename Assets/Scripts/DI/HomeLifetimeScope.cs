using UnityEngine;
using UnityEngine.UI;
using VContainer;
using VContainer.Unity;

public class HomeLifetimeScope : LifetimeScope
{
    [SerializeField] private UIProviderConfig _uiProviderConfig;
    [SerializeField] private CustomizationDataConfig _customizationDataConfig;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterInstance(_uiProviderConfig);
        builder.RegisterInstance(_customizationDataConfig);

        builder.Register<CustomizationData>(Lifetime.Singleton);
        builder.Register<UIProvider>(Lifetime.Singleton);

        builder.Register<ActionBinder>(Lifetime.Singleton).AsImplementedInterfaces();
    }
}
