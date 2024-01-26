namespace Impart.WinUI.UI.WindowManagement;

public interface IWindowService
{
    Shell MainWindow { get; }

    int WindowCount { get; }

    IReadOnlyList<Shell> Windows { get; }

    Shell? CreateWindow();

    bool HasWindow(Window window);

    void ActivateMainWindow();

    void ActivateWindow(Window window);
}