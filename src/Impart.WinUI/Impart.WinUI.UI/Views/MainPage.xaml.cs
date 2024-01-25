namespace Impart.WinUI.UI.Views;

[UseViewModel<MainViewModel>]
public sealed partial class MainPage : Page
{
    public MainViewModel ViewModel { get; set; } = new();

    public MainPage() => InitializeComponent();
}