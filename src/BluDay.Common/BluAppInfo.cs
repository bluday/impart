namespace BluDay.Common
{
    public sealed class BluAppInfo
    {
        public string Author { get; }

        public string Name { get; } = Windows.ApplicationModel.Package.Current.DisplayName;

        public string Version { get; }

        public string Website { get; }

        [System.Text.Json.Serialization.JsonConstructor]
        public BluAppInfo(string author, string version, string website)
        {
            Author  = author;
            Version = version;
            Website = website;
        }
    }
}