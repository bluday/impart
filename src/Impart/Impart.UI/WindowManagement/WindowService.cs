namespace Impart.UI.WindowManagement;

public sealed class WindowService : IWindowService
{
    private readonly INavigationService _navigationService;

    private readonly HashSet<IWindow> _windows = new();

    public IWindow? MainWindow => _windows.FirstOrDefault();

    public int WindowCount => _windows.Count;

    public IReadOnlyList<IWindow> Windows
    {
        get => _windows.ToList().AsReadOnly();
    }

    public WindowService(INavigationService navigationService)
    {
        _navigationService = navigationService;
    }

    public IWindow? CreateWindow()
    {
        var window = (IWindow)new object();

        bool added = _windows.Add(window);

        return added ? window : null;
    }

    public bool HasWindow(IWindow window)
    {
        return _windows.Contains(window);
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}