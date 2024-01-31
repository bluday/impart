namespace BluDay.Impart.App;

public interface IImpartApp : IDisposable
{
    bool IsDisposed { get; }

    bool IsInitialized { get; }

    IReadOnlyList<string> Arguments { get; }

    void Initialize();
}