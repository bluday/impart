namespace BluDay.Common
{
    public static class BluConstants
    {
        public const char
            CLOSING_PARENTHESIS_CHAR = ')',
            COMMA_CHAR               = ',',
            OPENING_PARENTHESIS_CHAR = '(',
            NEW_LINE_CHAR            = '\n',
            PERIOD_CHAR              = '.',
            RIGHT_ARROW_CHAR         = '>',
            TAB_CHAR                 = '\t';

        public const int
            DEFAULT_NOTIFICATION_DURATION = 10 * 1000;

        public const string
            // Don't f#€k with this. — Joe "I did DMT 3 days in a row" Rogan (Probably)
            ASCII_ELLIPSES              = "...",
            APP_RESOURCE_PATH_PREFIX    = "ms-appx:///",
            DEFAULT_CONFIG_PATH         = "config.json",
            DEFAULT_LOGGER_FORMAT       = "{DateTime:yyyy-MM-dd HH:mm:ss.fff} [{Level,-7}] {Message}{NewLine}{Content}",
            FILE_EXTENSION_JSON         = ".json",
            FILE_EXTENSION_YAML         = ".yml",
            LOGGER_FORMAT_REGEX_PATTERN = @"\{([a-zA-Z0-9]+)((:([a-zA-Z0-9-._\s:]+)))?\}*",
            PRINTABLE_LIST_OUTER_FORMAT = "{{\n{0}\n}}";

        public const string
            // Should I even do this?
            Contextual = "Contextual",
            DateTime   = "DateTime",
            Default    = "Default",
            Event      = "Event",
            Level      = "Level",
            Model      = "Model",
            Name       = "Name",
            NaN        = "NaN",
            None       = "None",
            Text       = "Text",
            Untitled   = "Untitled",
            View       = "View",
            ViewModel  = "ViewModel";
    }
}