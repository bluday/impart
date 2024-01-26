namespace Impart.WinUI.UI.WindowManagement;

public sealed class WindowService : IWindowService, IDisposable
{
    private readonly HashSet<Shell> _windows;

    public Shell MainWindow { get; }

    public int WindowCount => _windows.Count + 1;

    public IReadOnlyList<Shell> Windows => _windows.ToList();

    public WindowService()
    {
        _windows = new();

        MainWindow = new();
    }

    public Shell? CreateWindow()
    {
        Shell window = new();

        bool added = _windows.Add(window);

        return added ? window : null;
    }

    public bool HasWindow(Window window)
    {
        return window == MainWindow || _windows.Contains(window);
    }

    public void ActivateMainWindow()
    {
        ActivateWindow(MainWindow);
    }

    public void ActivateWindow(Window window)
    {
        window.DispatcherQueue.TryEnqueue(window.Activate);
    }

    public void Dispose() { }
}