using BluDay.Common.Logging;
using System;

namespace BluDay.Common.Services
{
    public interface IBluLoggerService
    {
        BluLogFormatDescriptor Format { get; }

        IBluLogger Create(object target);

        IBluLogger Create(object target, string name);

        IBluLogger Create(Type targetType);

        IBluLogger Create(Type targetType, string name);
    }
}