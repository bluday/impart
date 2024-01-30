namespace Impart.UI.WindowManagement;

public sealed class WindowService : IWindowService
{
    private readonly HashSet<Shell> _windows = new();

    public Shell? MainWindow => _windows.FirstOrDefault();

    public int WindowCount => _windows.Count;

    public IReadOnlyList<Shell> Windows => _windows.ToList();

    public Shell? CreateWindow()
    {
        Shell window = new();

        bool added = _windows.Add(window);

        return added ? window : null;
    }

    public bool HasWindow(Window window)
    {
        return _windows.Contains(window);
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}