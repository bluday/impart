namespace Impart;

public interface IImpartApp : IDisposable
{
    bool IsDisposed { get; }

    bool IsInitialized { get; }

    string? Args { get; }

    IServiceProvider ServiceProvider { get; }

    IReadOnlyList<ServiceDescriptor> ServiceDescriptors { get; }

    void Initialize();

    void Initialize(string? args);
}