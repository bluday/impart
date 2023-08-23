namespace BluDay.Common.Configuration
{
    public static class BluConfigParser
    {
        public static TConfig Load<TConfig>() where TConfig : IBluConfigurable
        {
            return Load<TConfig>(BluConstants.DEFAULT_CONFIG_PATH);
        }

        public static TConfig Load<TConfig>(string relativePath) where TConfig : IBluConfigurable
        {
            string content = IO.File.ReadFromAssembly(relativePath);

            string extension = System.IO.Path.GetExtension(relativePath);

            if (extension is BluConstants.FILE_EXTENSION_JSON)
            {
                return System.Text.Json.JsonSerializer.Deserialize<TConfig>(content);
            }

            throw new Exceptions.BluConfigFileExtensionNotSupportedException(extension);
        }
    }
}