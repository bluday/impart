namespace Impart.WinUI.UI.Views;

[UseViewModel<SettingsViewModel>]
public sealed partial class SettingsPage : Page
{
    public SettingsViewModel ViewModel { get; set; } = new();

    public SettingsPage() => InitializeComponent();
}