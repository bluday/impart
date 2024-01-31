namespace BluDay.ImpartApp.UI.Navigation;

public interface INavigationService
{
    IReadOnlyDictionary<Guid, INavigator> NavigatorMap { get; }

    INavigator CreateNavigator(object source);
}