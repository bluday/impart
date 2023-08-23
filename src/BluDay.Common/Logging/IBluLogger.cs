using System.Threading.Tasks;

namespace BluDay.Common.Logging
{
    public interface IBluLogger
    {
        string Name { get; }

        System.Type TargetType { get; }

        BluLogFormatDescriptor Format { get; }

        Task LogAsync(BluLogLevel level, object value);

        Task LogAsync(BluLogLevel level, string message);

        Task LogAsync(BluLogLevel level, object value, object content);

        Task LogAsync(BluLogLevel level, string message, string content);

        Task LogAsync(BluLogLevel level, string format, params object[] values);
    }
}