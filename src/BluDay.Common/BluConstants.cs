namespace BluDay.Common
{
    public static class BluConstants
    {
        #region Char
        public const char CLOSING_PARENTHESIS_CHAR = ')';

        public const char COMMA_CHAR = ',';

        public const char OPENING_PARENTHESIS_CHAR = '(';

        public const char NEW_LINE_CHAR = '\n';

        public const char PERIOD_CHAR = '.';

        public const char RIGHT_ARROW_CHAR = '>';

        public const char TAB_CHAR = '\t';
        #endregion

        #region Int32
        public const int DEFAULT_NOTIFICATION_DURATION = 10 * 1000;
        #endregion

        #region String
        // Don't f#€k with this. — Joe "I did DMT 3 days in a row" Rogan (Probably)
        public const string ASCII_ELLIPSES = "...";

        public const string APP_RESOURCE_PATH_PREFIX = "ms-appx:///";

        public const string DEFAULT_CONFIG_PATH = "config.json";

        public const string DEFAULT_LOGGER_FORMAT = "{DateTime:yyyy-MM-dd HH:mm:ss.fff} [{Level,-7}] {Message}{NewLine}{Content}";

        public const string FILE_EXTENSION_JSON = ".json";

        public const string FILE_EXTENSION_YAML = ".yml";

        public const string LOGGER_FORMAT_REGEX_PATTERN = @"\{([a-zA-Z0-9]+)((:([a-zA-Z0-9-._\s:]+)))?\}*";

        public const string PRINTABLE_LIST_OUTER_FORMAT = "{{\n{0}\n}}";

        // Should I even do this?
        public const string Contextual = "Contextual";

        public const string DateTime = "DateTime";

        public const string Default = "Default";

        public const string Event = "Event";

        public const string Level = "Level";

        public const string Model = "Model";

        public const string Name = "Name";

        public const string NaN = "NaN";

        public const string None = "None";

        public const string Text = "Text";

        public const string Untitled = "Untitled";

        public const string View = "View";

        public const string ViewModel = "ViewModel";
        #endregion
    }
}