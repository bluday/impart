using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace BluDay.Common.UI.Xaml.Controls
{
    public sealed partial class BluUserAvatar : Windows.UI.Xaml.Controls.UserControl
    {
        public static readonly DependencyProperty AvatarProperty =
            DependencyProperty.Register(
                "Avatar",
                typeof(ImageSource),
                typeof(BluUserAvatar),
                new PropertyMetadata(null)
            );

        public static readonly DependencyProperty StatusColorProperty =
            DependencyProperty.Register(
                "StatusColor",
                typeof(SolidColorBrush),
                typeof(BluUserAvatar),
                new PropertyMetadata(new SolidColorBrush(Windows.UI.Colors.Lime))
            );

        public ImageSource Avatar
        {
            get => GetValue(AvatarProperty) as ImageSource;
            set => SetValue(AvatarProperty, value);
        }

        public SolidColorBrush StatusColor
        {
            get => GetValue(StatusColorProperty) as SolidColorBrush;
            set => SetValue(StatusColorProperty, value);
        }

        public BluUserAvatar() => InitializeComponent();
    }
}