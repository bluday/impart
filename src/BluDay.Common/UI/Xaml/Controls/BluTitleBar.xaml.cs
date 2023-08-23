using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace BluDay.Common.UI.Xaml.Controls
{
    public sealed partial class BluTitleBar : Windows.UI.Xaml.Controls.UserControl
    {
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register(
                "Title",
                typeof(string),
                typeof(BluTitleBar),
                new PropertyMetadata(null)
            );

        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register(
                "Icon",
                typeof(ImageSource),
                typeof(BluTitleBar),
                new PropertyMetadata(null)
            );

        public string Title
        {
            get => GetValue(TitleProperty) as string;
            set => SetValue(TitleProperty, value);
        }

        public ImageSource Icon
        {
            get => GetValue(IconProperty) as ImageSource;
            set => SetValue(IconProperty, value);
        }

        public BluTitleBar() => InitializeComponent();
    }
}