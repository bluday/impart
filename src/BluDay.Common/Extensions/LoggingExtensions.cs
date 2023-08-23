using BluDay.Common.Logging;
using System.Diagnostics;

namespace BluDay.Common.Extensions
{
    public static class LoggingExtensions
    {
        private static void Log(
            this IBluLogger  logger,
                 BluLogLevel level,
                 object      value,
                 object      content = null)
        {
            logger
                .LogAsync(level, value, content)
                .ConfigureAwait(false);
        }

        private static void Log(
            this IBluLogger  logger,
                 BluLogLevel level,
                 string      message,
                 object      content = null)
        {
            logger
                .LogAsync(level, message, content?.ToString())
                .ConfigureAwait(false);
        }

        private static void Log(
            this   IBluLogger  logger,
                   BluLogLevel level,
                   string      format,
            params object[]    values)
        {
            logger
                .LogAsync(level, format, values)
                .ConfigureAwait(false);
        }

        [Conditional("DEBUG")]
        public static void LogDebug(this IBluLogger logger, object value, object content = null)
        {
            logger.Log(BluLogLevel.Debug, value, content);
        }

        [Conditional("DEBUG")]
        public static void LogDebug(this IBluLogger logger, string message, object content = null)
        {
            logger.Log(BluLogLevel.Debug, message, content);
        }

        [Conditional("DEBUG")]
        public static void LogDebug(this IBluLogger logger, string format, params object[] values)
        {
            logger.Log(BluLogLevel.Debug, format, values);
        }

        public static void LogInfo(this IBluLogger logger, object value, object content = null)
        {
            logger.Log(BluLogLevel.Info, value, content);
        }

        public static void LogInfo(this IBluLogger logger, string message, object content = null)
        {
            logger.Log(BluLogLevel.Info, message, content);
        }

        public static void LogInfo(this IBluLogger logger, string format, params object[] values)
        {
            logger.Log(BluLogLevel.Info, format, values);
        }

        public static void LogSuccess(this IBluLogger logger, object value, object content = null)
        {
            logger.Log(BluLogLevel.Success, value, content);
        }

        public static void LogSuccess(this IBluLogger logger, string message, object content = null)
        {
            logger.Log(BluLogLevel.Success, message, content);
        }

        public static void LogSuccess(this IBluLogger logger, string format, params object[] values)
        {
            logger.Log(BluLogLevel.Success, format, values);
        }

        public static void LogWarning(this IBluLogger logger, object value, object content = null)
        {
            logger.Log(BluLogLevel.Warning, value, content);
        }

        public static void LogWarning(this IBluLogger logger, string message, object content = null)
        {
            logger.Log(BluLogLevel.Warning, message, content);
        }

        public static void LogWarning(this IBluLogger logger, string format, params object[] values)
        {
            logger.Log(BluLogLevel.Warning, format, values);
        }

        public static void LogError(this IBluLogger logger, object value, object content = null)
        {
            logger.Log(BluLogLevel.Error, value, content);
        }

        public static void LogError(this IBluLogger logger, string message, object content = null)
        {
            logger.Log(BluLogLevel.Error, message, content);
        }

        public static void LogError(this IBluLogger logger, string format, params object[] values)
        {
            logger.Log(BluLogLevel.Error, format, values);
        }
    }
}