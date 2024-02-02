namespace BluDay.Common.Services;

public interface INavigationService
{
    IReadOnlyDictionary<Guid, INavigator> NavigatorMap { get; }

    INavigator CreateNavigator(object source);
}