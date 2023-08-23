namespace BluDay.Impart
{
    public interface IImpartConfig : Common.Configuration.IBluConfigurable
    {
        Common.BluAppInfo AppInfo { get; }

        bool PreloadEventTopics { get; }

        bool PreloadNavigationContexts { get; }

        int NotificationDuration { get; }
        
        int SampleDataUserIndex { get; }
        
        string DefaultView { get; }

        string LoggerFormat { get; }

        string[] AllowedFilePickerFileTypes { get; }

        Common.Types.BluHierarchySection<string>[] ViewHierarchySections { get; }
    }
}