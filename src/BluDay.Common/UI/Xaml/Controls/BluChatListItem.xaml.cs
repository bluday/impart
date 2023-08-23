using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace BluDay.Common.UI.Xaml.Controls
{
    public sealed partial class BluChatListItem : Windows.UI.Xaml.Controls.UserControl
    {
        public static readonly DependencyProperty IsCompactProperty =
            DependencyProperty.Register(
                "IsCompact",
                typeof(bool),
                typeof(BluChatListItem),
                new PropertyMetadata(false)
            );

        public static readonly DependencyProperty IsGroupProperty =
            DependencyProperty.Register(
                "IsGroup",
                typeof(bool),
                typeof(BluChatListItem),
                new PropertyMetadata(false)
            );

        public static readonly DependencyProperty BadgeCountProperty =
            DependencyProperty.Register(
                "BadgeCount",
                typeof(int),
                typeof(BluChatListItem),
                new PropertyMetadata(0)
            );

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register(
                "Title",
                typeof(string),
                typeof(BluChatListItem),
                new PropertyMetadata(null)
            );

        public static readonly DependencyProperty DetailsProperty =
            DependencyProperty.Register(
                "Details",
                typeof(string),
                typeof(BluChatListItem),
                new PropertyMetadata(null)
            );

        public static readonly DependencyProperty DateTimeProperty =
            DependencyProperty.Register(
                "DateTime",
                typeof(string),
                typeof(BluChatListItem),
                new PropertyMetadata(null)
            );

        public static readonly DependencyProperty PictureProperty =
            DependencyProperty.Register(
                "Picture",
                typeof(ImageSource),
                typeof(BluChatListItem),
                new PropertyMetadata(null)
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

        public string Title
        {
            get => GetValue(TitleProperty) as string;
            set => SetValue(TitleProperty, value);
        }

        public string Details
        {
            get => GetValue(DetailsProperty) as string;
            set => SetValue(DetailsProperty, value);
        }

        public string DateTime
        {
            get => GetValue(DateTimeProperty) as string;
            set => SetValue(DateTimeProperty, value);
        }

        public ImageSource Picture
        {
            get => GetValue(PictureProperty) as ImageSource;
            set => SetValue(PictureProperty, value);
        }

        public BluChatListItem() => InitializeComponent();
    }
}