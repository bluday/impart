namespace BluDay.Impart.App.WinUI.UI.Controls;

public sealed partial class ChatListItem : UserControl
{
    public static readonly DependencyProperty IsCompactProperty =
        DependencyProperty.Register(
            nameof(IsCompact),
            typeof(bool),
            typeof(ChatListItem),
            new PropertyMetadata(defaultValue: false)
        );

    public static readonly DependencyProperty IsGroupProperty =
        DependencyProperty.Register(
            nameof(IsGroup),
            typeof(bool),
            typeof(ChatListItem),
            new PropertyMetadata(defaultValue: false)
        );

    public static readonly DependencyProperty BadgeCountProperty =
        DependencyProperty.Register(
            nameof(BadgeCount),
            typeof(int),
            typeof(ChatListItem),
            new PropertyMetadata(0)
        );

    public static readonly DependencyProperty TitleProperty =
        DependencyProperty.Register(
            nameof(Title),
            typeof(string),
            typeof(ChatListItem),
            new PropertyMetadata(defaultValue: null)
        );

    public static readonly DependencyProperty DetailsProperty =
        DependencyProperty.Register(
            nameof(Details),
            typeof(string),
            typeof(ChatListItem),
            new PropertyMetadata(defaultValue: null)
        );

    public static readonly DependencyProperty DateTimeProperty =
        DependencyProperty.Register(
            nameof(DateTime),
            typeof(string),
            typeof(ChatListItem),
            new PropertyMetadata(defaultValue: null)
        );

    public static readonly DependencyProperty PictureProperty =
        DependencyProperty.Register(
            nameof(Picture),
            typeof(ImageSource),
            typeof(ChatListItem),
            new PropertyMetadata(defaultValue: null)
        );

    public bool IsCompact
    {
        get => (bool)GetValue(IsCompactProperty);
        set => SetValue(IsCompactProperty, value);
    }

    public bool IsGroup
    {
        get => (bool)GetValue(IsGroupProperty);
        set => SetValue(IsGroupProperty, value);
    }

    public int BadgeCount
    {
        get => (int)GetValue(BadgeCountProperty);
        set => SetValue(BadgeCountProperty, value);
    }

    public string? Title
    {
        get => GetValue(TitleProperty) as string;
        set => SetValue(TitleProperty, value);
    }

    public string? Details
    {
        get => GetValue(DetailsProperty) as string;
        set => SetValue(DetailsProperty, value);
    }

    public string? DateTime
    {
        get => GetValue(DateTimeProperty) as string;
        set => SetValue(DateTimeProperty, value);
    }

    public ImageSource? Picture
    {
        get => GetValue(PictureProperty) as ImageSource;
        set => SetValue(PictureProperty, value);
    }

    public ChatListItem() => InitializeComponent();
}