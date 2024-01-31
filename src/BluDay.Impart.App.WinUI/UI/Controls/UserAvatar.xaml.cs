namespace BluDay.Impart.App.WinUI.UI.Controls;

public sealed partial class UserAvatar : UserControl
{
    public static readonly DependencyProperty AvatarProperty =
        DependencyProperty.Register(
            nameof(Avatar),
            typeof(ImageSource),
            typeof(UserAvatar),
            new PropertyMetadata(defaultValue: null)
        );

    public static readonly DependencyProperty StatusColorProperty =
        DependencyProperty.Register(
            nameof(StatusColor),
            typeof(SolidColorBrush),
            typeof(UserAvatar),
            new PropertyMetadata(defaultValue: new SolidColorBrush(Colors.Lime))
        );

    public ImageSource? Avatar
    {
        get => GetValue(AvatarProperty) as ImageSource;
        set => SetValue(AvatarProperty, value);
    }

    public SolidColorBrush? StatusColor
    {
        get => GetValue(StatusColorProperty) as SolidColorBrush;
        set => SetValue(StatusColorProperty, value);
    }

    public UserAvatar() => InitializeComponent();
}