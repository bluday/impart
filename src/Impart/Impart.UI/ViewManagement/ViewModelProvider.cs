namespace Impart.UI.ViewManagement;

public sealed class ViewModelProvider : ImplementationProvider<IViewModel>, IViewModelProvider
{
    public ViewModelProvider(IServiceProvider serviceProvider) : base(serviceProvider) { }
}