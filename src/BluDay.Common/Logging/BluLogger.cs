using BluDay.Common.Extensions;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace BluDay.Common.Logging
{
    public sealed class BluLogger : IBluLogger
    {
        public string Name { get; }

        public Type TargetType { get; }

        public BluLogFormatDescriptor Format { get; }

        public BluLogger(Type targetType, string name, BluLogFormatDescriptor format)
        {
            BluValidator.NotNull(targetType, nameof(targetType));

            Name = name.BluOr(targetType.Name);

            TargetType = targetType;

            Format = format ?? BluLogFormatDescriptor.Default;
        }

        private BluLogInfo CreateLog(BluLogLevel level, string message, string content)
        {
            return new BluLogInfo(this, level, message, content);
        }

        public Task LogAsync(BluLogLevel level, object value)
        {
            return LogAsync(level, value, content: null);
        }
         
        public Task LogAsync(BluLogLevel level, string message)
        {
            return LogAsync(level, message, content: null);
        }

        public Task LogAsync(BluLogLevel level, object value, object content)
        {
            return LogAsync(
                level:   level,
                message: value?.ToString(),
                content: content?.ToString()
            );
        }

        public Task LogAsync(BluLogLevel level, string message, string content)
        {
            return Task.Run(() =>
            {
                BluLogInfo log = CreateLog(level, message, content);

                Debug.WriteLine(message: Format.CreateOutput(log));
            });
        }

        public Task LogAsync(BluLogLevel level, string format, params object[] values)
        {
            return LogAsync(
                level:   level,
                message: format.BluFormat(values),
                content: null
            );
        }

        public override string ToString()
        {
            return $"{nameof(BluLogger)} \"{Name}\" ({TargetType})";
        }
    }
}