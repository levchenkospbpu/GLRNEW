using UnityEngine;
using VContainer;
using VContainer.Unity;

public class RhythmGameLifetimeScope : LifetimeScope
{
    [SerializeField] private CustomizationDataConfig _customizationDataConfig;
    [SerializeField] private CharactersDataConfig _charactersDataConfig;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterInstance(_customizationDataConfig);
        builder.RegisterInstance(_charactersDataConfig);

        builder.Register<CustomizationData>(Lifetime.Singleton);
        builder.Register<CharactersData>(Lifetime.Singleton);

        builder.Register<ActionBinder>(Lifetime.Singleton).AsImplementedInterfaces();

        builder.RegisterEntryPoint<Party>(Lifetime.Singleton).AsSelf();
        //builder.RegisterEntryPoint<Appearance>(Lifetime.Singleton).AsSelf();
        builder.RegisterEntryPoint<CustomSceneManager>(Lifetime.Singleton).AsSelf();
    }
}
