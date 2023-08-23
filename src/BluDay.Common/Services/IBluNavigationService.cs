namespace BluDay.Common.Services
{
    public interface IBluNavigationService
    {
        bool CanGoBack { get; }

        bool CanGoForward { get; }

        System.Collections.Generic.IReadOnlyList<System.Type> CurrentViewStack { get; }

        bool GoBack();
        
        bool GoForward();

        bool Navigate(object viewPropertyValue);

        bool Navigate<TViewPropertyValue>();
    }
}