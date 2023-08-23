namespace BluDay.Common.Logging
{
    public struct BluLogInfo
    {
        public string Message { get; }

        public string Content { get; }

        public System.DateTime CreatedAt { get; }

        public BluLogLevel Level { get; }

        public BluLogger Source { get; }

        public BluLogInfo(BluLogger source, BluLogLevel level, string message, string content)
        {
            BluValidator.NotNull(source, nameof(source));

            CreatedAt = System.DateTime.Now;

            Source = source;

            Level = level;

            Message = message;
            Content = content;
        }
    }
}