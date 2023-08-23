using BluDay.Common.Logging;
using BluDay.Common.Extensions;
using System;
using System.Collections.Generic;

namespace BluDay.Common.Services
{
    public sealed class BluLoggerService : Service, IBluLoggerService
    {
        private readonly HashSet<IBluLogger> _loggers = new HashSet<IBluLogger>();

        public BluLogFormatDescriptor Format { get; } = BluLogFormatDescriptor.Default;

        public BluLoggerService() : base(commonServices: null) { }

        private string CreateSuggestedName(string name)
        {
            return _loggers.BluCreateUniqueKey(
                selector:  logger => logger.Name,
                predicate: logger => logger.Name != name
            );
        }

        public IBluLogger Create(object target)
        {
            return Create(target?.GetType(), null);
        }

        public IBluLogger Create(object target, string name)
        {
            return Create(target?.GetType(), name);
        }

        public IBluLogger Create(Type targetType)
        {
            return Create(targetType, targetType?.Name);
        }

        public IBluLogger Create(Type targetType, string name)
        {
            BluValidator.NotNull(targetType, nameof(targetType));

            name = CreateSuggestedName(name ?? targetType.Name);

            var logger = BluLoggerFactory.Create(targetType, name, Format);

            _loggers.Add(logger);

            return logger;
        }
    }
}