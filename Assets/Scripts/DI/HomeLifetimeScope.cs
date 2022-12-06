using Customization;
using SceneControllers;
using States;
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
        [SerializeField] private CustomizationDataConfig _customizationDataConfig;
        [SerializeField] private CharactersDataConfig _charactersDataConfig;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(_playerData);
            builder.RegisterInstance(_uiCanvasData);
            builder.RegisterInstance(_uiProviderConfig);
            builder.RegisterInstance(_customizationDataConfig);
            builder.RegisterInstance(_charactersDataConfig);

            builder.Register<CustomizationData>(Lifetime.Singleton);
            builder.Register<CharactersData>(Lifetime.Singleton);
            builder.Register<UIProvider>(Lifetime.Singleton);

            builder.Register<ActionBinder>(Lifetime.Singleton).AsImplementedInterfaces();

            builder.Register<AuthorizationState>(Lifetime.Singleton);
            builder.Register<AvatarState>(Lifetime.Singleton);
            builder.Register<MainPanelState>(Lifetime.Singleton);

            builder.RegisterEntryPoint<Party>().AsSelf();
            builder.RegisterEntryPoint<Appearance>().AsSelf();
            builder.RegisterEntryPoint<HomeController>().As<ISceneController>();
            builder.RegisterEntryPoint<CustomSceneManager>().AsSelf();
        }
    }
}
