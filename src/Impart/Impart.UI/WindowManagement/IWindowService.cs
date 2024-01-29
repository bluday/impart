namespace Impart.UI.WindowManagement;

public interface IWindowService : IDisposable
{
    Shell? MainWindow { get; }

    int WindowCount { get; }

    IReadOnlyList<Shell> Windows { get; }

    Shell? CreateWindow();

    bool HasWindow(Window window);
}