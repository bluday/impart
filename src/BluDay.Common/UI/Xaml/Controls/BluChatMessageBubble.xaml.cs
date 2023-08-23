using Windows.UI.Xaml;

namespace BluDay.Common.UI.Xaml.Controls
{
    public sealed partial class BluChatMessageBubble : Windows.UI.Xaml.Controls.UserControl
    {
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(
                "Text",
                typeof(string),
                typeof(BluChatMessageBubble),
                new PropertyMetadata(null)
            );

        public static readonly DependencyProperty SideProperty =
            DependencyProperty.Register(
                "Side",
                typeof(HorizontalAlignment),
                typeof(BluChatMessageBubble),
                new PropertyMetadata(null)
            );

        public string Text
        {
            get => GetValue(TextProperty) as string;
            set => SetValue(TextProperty, value);
        }

        public HorizontalAlignment Side
        {
            get => (HorizontalAlignment)GetValue(SideProperty);
            set => SetValue(SideProperty, value);
        }
        
        public BluChatMessageBubble() => InitializeComponent();
    }
}