namespace Impart;

public sealed class ImpartApp : IImpartApp
{
    private string? _args;

    private ImpartAppContainer? _container;

    public bool IsDisposed { get; private set; }

    public bool IsInitialized { get; private set; }

    public string? Arguments => _args;

    private void CreateContainer()
    {
        _container = new(this);

        _container.InitializeCoreServices();
    }

    public void Initialize()
    {
        if (IsInitialized) return;

        CreateContainer();

        IsInitialized = true;
    }

    public void Initialize(string args)
    {
        _args = args.NotWhiteSpaceOrDefault();

        Initialize();
    }

    public void Dispose()
    {
        _container?.Dispose();
    }
}