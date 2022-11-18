using VContainer;
using VContainer.Unity;

public class LocationLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterComponentInHierarchy<InputManager>();
    }
}
