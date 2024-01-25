namespace Impart.WinUI.UI.Views;

[UseViewModel<ConversationsViewModel>]
public sealed partial class ConversationsPage : Page
{
    public ConversationsViewModel ViewModel { get; set; } = new();

    public ConversationsPage() => InitializeComponent();
}