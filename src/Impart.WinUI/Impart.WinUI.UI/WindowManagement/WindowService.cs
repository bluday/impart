namespace Impart.WinUI.UI.WindowManagement;

public sealed class WindowService : IWindowService, IDisposable
{
    private readonly DispatcherQueue _mainDispatcherQueue;

    private readonly HashSet<Shell> _windows = new();

    public Shell MainWindow { get; } = new();

    public int WindowCount => _windows.Count + 1;

    public IReadOnlyList<Shell> Windows => _windows.ToList();

    public WindowService(DispatcherQueue mainDispatcherQueue)
    {
        _mainDispatcherQueue = mainDispatcherQueue;
    }

    public Shell? CreateWindow()
    {
        Shell window = new();

        if (!_windows.Add(window))
        {
            return null;
        }

        return window;
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
        _mainDispatcherQueue.TryEnqueue(window.Activate);
    }

    public void Dispose() { }
}