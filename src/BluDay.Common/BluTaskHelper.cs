using Windows.ApplicationModel.Core;

namespace BluDay.Common
{
    public static class BluTaskHelper
    {
        public static Windows.UI.Core.CoreDispatcher MainDispatcher
        {
            get => CoreApplication.MainView.Dispatcher;
        }

        public static Windows.System.DispatcherQueue MainDispatcherQueue
        {
            get => CoreApplication.MainView.DispatcherQueue;
        }
    }
}