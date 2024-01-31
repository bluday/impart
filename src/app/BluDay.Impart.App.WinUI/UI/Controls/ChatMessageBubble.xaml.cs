namespace BluDay.Impart.App.WinUI.UI.Controls;

public sealed partial class ChatMessageBubble : UserControl
{
    public static readonly DependencyProperty TextProperty =
        DependencyProperty.Register(
            nameof(Text),
            typeof(string),
            typeof(ChatMessageBubble),
            new PropertyMetadata(defaultValue: null)
        );

    public static readonly DependencyProperty SideProperty =
        DependencyProperty.Register(
            nameof(Side),
            typeof(HorizontalAlignment),
            typeof(ChatMessageBubble),
            new PropertyMetadata(defaultValue: null)
        );

    public string? Text
    {
        get => GetValue(TextProperty) as string;
        set => SetValue(TextProperty, value);
    }

    public HorizontalAlignment Side
    {
        get => (HorizontalAlignment)GetValue(SideProperty);
        set => SetValue(SideProperty, value);
    }
    
    public ChatMessageBubble() => InitializeComponent();
}