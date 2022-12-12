using Customization;
using UI;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class LocationLifetimeScope : LifetimeScope
{
    [SerializeField] private UIProviderConfig _uiProviderConfig;
    [SerializeField] private CustomizationDataContainer customizationDataContainer;
    [SerializeField] private CharactersDataConfig _charactersDataConfig;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterInstance(_uiProviderConfig);
        builder.RegisterInstance(customizationDataContainer);
        builder.RegisterInstance(_charactersDataConfig);

        builder.Register<ActionBinder>(Lifetime.Singleton).AsImplementedInterfaces();

        builder.RegisterEntryPoint<Party>(Lifetime.Singleton).AsSelf();
        builder.RegisterEntryPoint<Appearance>(Lifetime.Singleton).AsSelf();
        builder.RegisterEntryPoint<CustomSceneManager>(Lifetime.Singleton).AsSelf();
    }
}
