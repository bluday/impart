namespace Impart.UI.Navigation;

public sealed class NavigationService : INavigationService
{
    private readonly Dictionary<Guid, INavigator> _navigatorMap = new();

    public IReadOnlyDictionary<Guid, INavigator> NavigatorMap => _navigatorMap.AsReadOnly();

    public INavigator CreateNavigator(object source)
    {
        return null!;
    }
}