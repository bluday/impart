namespace Impart;

public sealed class ImpartApp : IImpartApp
{
    private string? _args;

    private ImpartAppContainer _container;

    public bool IsDisposed { get; private set; }

    public bool IsInitialized { get; private set; }

    public string? Arguments => _args;

    public ImpartApp(string args)
    {
        _args = args.NotWhiteSpaceOrDefault();

        _container = new(app: this);
    }

    public void Initialize()
    {
        if (IsInitialized) return;

        _container.InitializeCoreServices();

        IsInitialized = true;
    }

    public void Dispose()
    {
        _container?.Dispose();
    }
}