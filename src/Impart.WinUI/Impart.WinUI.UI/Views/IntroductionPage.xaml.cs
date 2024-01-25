namespace Impart.WinUI.UI.Views;

[UseViewModel<IntroductionViewModel>]
public sealed partial class IntroductionPage : Page
{
    public IntroductionViewModel ViewModel { get; set; } = new();

    public IntroductionPage() => InitializeComponent();
}