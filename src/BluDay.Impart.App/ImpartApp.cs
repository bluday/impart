namespace BluDay.Impart.App;

public sealed class ImpartApp : IImpartApp
{
    private bool _isDisposed;

    private bool _isInitialized;

    private readonly ImpartAppArgs _args;

    private readonly ImpartAppContainer _container;

    public ImpartAppArgs Args => _args;

    public bool IsDisposed => _isDisposed;

    public bool IsInitialized => _isInitialized;

    public ImpartApp(ImpartAppArgs args)
    {
        _args = args;

        _container = new(app: this);
    }

    private void InitializeCoreServices()
    {
        _container.ServiceProvider
            .GetRequiredService<IAppWindowService>()
            .CreateWindow();
    }

    public void Initialize()
    {
        ObjectDisposedException.ThrowIf(_isDisposed, this);

        if (_isInitialized) return;

        InitializeCoreServices();

        _isInitialized = true;
    }

    public void Dispose()
    {
        if (_isDisposed) return;

        _container?.Dispose();

        _isDisposed = true;
    }
}