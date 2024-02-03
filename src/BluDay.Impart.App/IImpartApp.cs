namespace BluDay.Impart.App;

public interface IImpartApp : IDisposable
{
    ImpartAppArgs Args { get; }

    bool IsDisposed { get; }

    bool IsInitialized { get; }

    void Initialize();
}