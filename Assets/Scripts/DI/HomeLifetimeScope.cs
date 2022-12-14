using Customization;
using SceneControllers;
using States.HomeScene;
using UI;
using UI.Canvas;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace DI
{
    public class HomeLifetimeScope : LifetimeScope
    {
        [SerializeField] private PlayerData _playerData;
        [SerializeField] private UiCanvasData _uiCanvasData;
        [SerializeField] private UIProviderConfig _uiProviderConfig;
        [SerializeField] private CustomizationDataContainer customizationDataContainer;
        [SerializeField] private CharactersDataConfig _charactersDataConfig;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(_playerData);
            builder.RegisterInstance(_uiCanvasData);
            builder.RegisterInstance(_uiProviderConfig);
            builder.RegisterInstance(customizationDataContainer);
            builder.RegisterInstance(_charactersDataConfig);

            builder.Register<ActionBinder>(Lifetime.Singleton).AsImplementedInterfaces();

            builder.Register<AuthorizationState>(Lifetime.Singleton);
            builder.Register<AvatarState>(Lifetime.Singleton);
            builder.Register<MainPanelState>(Lifetime.Singleton);
            builder.Register<CustomizationPanelState>(Lifetime.Singleton);
            builder.Register<MapPanelState>(Lifetime.Singleton);
            builder.Register<PartyPanelState>(Lifetime.Singleton);

            builder.RegisterEntryPoint<Party.Party>().AsSelf();
            builder.RegisterEntryPoint<Appearance>().AsSelf();
            builder.RegisterEntryPoint<HomeController>().As<ISceneController>();
            builder.RegisterEntryPoint<CustomSceneManager>().AsSelf();
        }
    }
}
