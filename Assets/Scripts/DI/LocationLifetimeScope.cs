using UnityEngine;
using VContainer;
using VContainer.Unity;

public class LocationLifetimeScope : LifetimeScope
{
    [SerializeField] private UIProviderConfig _uiProviderConfig;
    [SerializeField] private CustomizationDataConfig _customizationDataConfig;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterComponentInHierarchy<InputManager>();
        builder.RegisterComponentInHierarchy<CustomSceneManager>();

        builder.RegisterInstance(_uiProviderConfig);
        builder.RegisterInstance(_customizationDataConfig);

        builder.Register<CustomizationData>(Lifetime.Singleton);
        builder.Register<UIProvider>(Lifetime.Singleton);

        builder.Register<ActionBinder>(Lifetime.Singleton).AsImplementedInterfaces();

        builder.RegisterEntryPoint<Appearance>(Lifetime.Singleton).AsSelf();
        builder.RegisterEntryPoint<CustomSceneManager>(Lifetime.Singleton).AsSelf();
    }
}
