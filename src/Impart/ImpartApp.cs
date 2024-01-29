namespace Impart;

public sealed class ImpartApp : IImpartApp
{
    private string? _args;

    private readonly ImpartAppContainer _container;

    public bool IsDisposed { get; private set; }

    public bool IsInitialized { get; private set; }

    public string? Arguments
    {
        get         => _args;
        private set => _args = value!.IsNullOrWhiteSpace() ? null : value;
    }

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

        Arguments = args;

        _container.InitializeCoreServices();

        IsInitialized = true;
    }

    public void Dispose()
    {
        _container?.Dispose();
    }
}