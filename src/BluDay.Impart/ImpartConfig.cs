using BluDay.Common;
using BluDay.Common.Configuration;
using BluDay.Common.Types;

namespace BluDay.Impart
{
    public sealed class ImpartConfig : IImpartConfig
    {
        public BluAppInfo AppInfo { get; }

        public bool PreloadEventTopics { get; }

        public bool PreloadNavigationContexts { get; }

        public int NotificationDuration { get; }
        
        public int SampleDataUserIndex { get; }
        
        public string DefaultView { get; }

        public string LoggerFormat { get; }

        public string[] AllowedFilePickerFileTypes { get; }

        public BluHierarchySection<string>[] ViewHierarchySections { get; }

        public ImpartConfig()
        {
            var config = BluConfigParser.Load<ImpartConfig>();

            // Gotta deal with this mess soon.
            AppInfo                    = config.AppInfo;
            PreloadEventTopics         = config.PreloadEventTopics;
            PreloadNavigationContexts  = config.PreloadNavigationContexts;
            NotificationDuration       = config.NotificationDuration;
            SampleDataUserIndex        = config.SampleDataUserIndex;
            DefaultView                = config.DefaultView;
            LoggerFormat               = config.LoggerFormat;
            AllowedFilePickerFileTypes = config.AllowedFilePickerFileTypes;
            ViewHierarchySections      = config.ViewHierarchySections;
        }

        [System.Text.Json.Serialization.JsonConstructor]
        public ImpartConfig(
            BluAppInfo                    appInfo,
            bool                          preloadEventTopics,
            bool                          preloadNavigationContexts,
            int                           notificationDuration,
            int                           sampleDataUserIndex,
            string                        defaultView,
            string                        loggerFormat,
            string[]                      allowedFilePickerFileTypes,
            BluHierarchySection<string>[] viewHierarchySections)
        {
            // We should probably use some static object-property-updater class for this.
            AppInfo                    = appInfo;
            PreloadEventTopics         = preloadEventTopics;
            PreloadNavigationContexts  = preloadNavigationContexts;
            NotificationDuration       = notificationDuration;
            SampleDataUserIndex        = sampleDataUserIndex;
            DefaultView                = defaultView;
            LoggerFormat               = loggerFormat;
            AllowedFilePickerFileTypes = allowedFilePickerFileTypes;
            ViewHierarchySections      = viewHierarchySections;
        }
    }
}