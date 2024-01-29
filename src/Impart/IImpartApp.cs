namespace Impart;

public interface IImpartApp : IDisposable
{
    bool IsDisposed { get; }

    bool IsInitialized { get; }

    string? Args { get; }

    void Initialize();

    void Initialize(string? args);
}