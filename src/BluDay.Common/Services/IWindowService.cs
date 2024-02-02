namespace BluDay.Common.Services;

public interface IWindowService
{
    IWindow? MainWindow { get; }

    int WindowCount { get; }

    IReadOnlyList<IWindow> Windows { get; }

    IWindow? CreateWindow();

    bool HasWindow(IWindow window);
}