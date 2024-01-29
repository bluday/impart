namespace Impart;

public sealed class ImpartApp : IImpartApp
{
    private readonly ImpartAppContainer _container;

    public bool IsDisposed { get; private set; }

    public bool IsInitialized { get; private set; }

    public string? Args { get; private set; }

    public ImpartApp()
    {
        _container = new(app: this);
    }

    public void Initialize()
    {
        Initialize(args: null);
    }

    public void Initialize(string? args)
    {
        if (IsInitialized) return;

        Args = args!.IsNullOrWhiteSpace() ? null : args;

        _container.InitializeCoreServices();

        IsInitialized = true;
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}