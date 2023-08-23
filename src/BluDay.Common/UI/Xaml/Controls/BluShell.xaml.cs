using Windows.UI.Xaml;

namespace BluDay.Common.UI.Xaml.Controls
{
    public sealed partial class BluShell : Windows.UI.Xaml.Controls.UserControl
    {
        public BluShell()
        {
            InitializeComponent();

            Window.Current.Content = this;

            Window.Current.SetTitleBar(TitleBar);

            BluTitleBarManager.Configure();
        }
    }
}