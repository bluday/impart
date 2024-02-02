namespace BluDay.Common.Services;

public sealed class AppNavigationService : IAppNavigationService
{
    private readonly Dictionary<Guid, INavigator> _navigatorMap = new();

    public IReadOnlyDictionary<Guid, INavigator> NavigatorMap => _navigatorMap.AsReadOnly();

    public INavigator CreateNavigator(object source)
    {
        throw new NotImplementedException();
    }
}