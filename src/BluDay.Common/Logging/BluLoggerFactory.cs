using System;

namespace BluDay.Common.Logging
{
    public static class BluLoggerFactory
    {
        public static BluLogger Create(object target)
        {
            return Create(target?.GetType(), name: null, format: null);
        }

        public static BluLogger Create(object target, string name)
        {
            return Create(target?.GetType(), name, format: null);
        }

        public static BluLogger Create(Type targetType)
        {
            return Create(targetType, name: null, format: null);
        }

        public static BluLogger Create(Type targetType, string name)
        {
            return Create(targetType, name, format: null);
        }

        public static BluLogger Create(Type targetType, string name, BluLogFormatDescriptor format)
        {
            return new BluLogger(targetType, name, format);
        }
    }
}