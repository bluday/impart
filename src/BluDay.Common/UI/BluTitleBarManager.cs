using Windows.ApplicationModel.Core;
using Windows.UI.ViewManagement;

namespace BluDay.Common.UI
{
    public static class BluTitleBarManager
    {
        public static ApplicationViewTitleBar App
        {
            get => ApplicationView.GetForCurrentView().TitleBar;
        }

        public static CoreApplicationViewTitleBar Core
        {
            get => CoreApplication.GetCurrentView().TitleBar;
        }

        public static void Configure()
        {
            App.BackgroundColor
                = App.ButtonBackgroundColor
                = App.ButtonInactiveBackgroundColor
                = App.InactiveBackgroundColor
                = Windows.UI.Colors.Transparent;

            Core.ExtendViewIntoTitleBar = true;
        }
    }
}