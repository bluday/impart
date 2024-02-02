namespace BluDay.Common.Services;

public interface IAppWindowService
{
    IWindow? MainWindow { get; }

    int WindowCount { get; }

    IReadOnlyList<IWindow> Windows { get; }

    IWindow? CreateWindow();

    bool HasWindow(IWindow window);
}