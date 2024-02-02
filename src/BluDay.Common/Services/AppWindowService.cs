namespace BluDay.Common.Services;

public sealed class AppWindowService : IAppWindowService
{
    private readonly IAppNavigationService _navigationService;

    private readonly HashSet<IWindow> _windows = new();

    public IWindow? MainWindow => _windows.FirstOrDefault();

    public int WindowCount => _windows.Count;

    public IReadOnlyList<IWindow> Windows
    {
        get => _windows.ToList().AsReadOnly();
    }

    public AppWindowService(IAppNavigationService navigationService)
    {
        _navigationService = navigationService;
    }

    public IWindow? CreateWindow()
    {
        /*
        IWindow window = new...

        bool added = _windows.Add(window);

        return added ? window : null;
        */

        return null;
    }

    public bool HasWindow(IWindow window)
    {
        return _windows.Contains(window);
    }
}