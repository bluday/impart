using SpecifierType      = BluDay.Common.Logging.BluLogFormatSpecifierType;
using SpecifierValueType = BluDay.Common.Logging.BluLogFormatSpecifierValueType;

namespace BluDay.Common.Logging
{
    public struct BluLogFormatSpecifier
    {
        public bool HasKnownValue => ValueType is SpecifierValueType.Known;

        public bool HasLoggerDependentValue => ValueType is SpecifierValueType.LoggerDependent;

        public SpecifierType Type { get; }

        public SpecifierValueType ValueType { get; }

        public BluLogFormatSpecifier(string specifierName)
        {
            Type = System.Enum.Parse<SpecifierType>(specifierName);

            ValueType = GetValueType(specifier: Type);
        }

        public static SpecifierValueType GetValueType(SpecifierType specifier)
        {
            if (specifier is SpecifierType.Level || specifier is SpecifierType.DateTime)
            {
                return SpecifierValueType.Known;
            }

            if (specifier is SpecifierType.Name || specifier is SpecifierType.TargetType)
            {
                return SpecifierValueType.LoggerDependent;
            }

            return SpecifierValueType.Unknown;
        }

        public static System.Func<BluLogInfo, object> CreateValueAccessor(SpecifierType specifier)
        {
            switch (specifier)
            {
                case SpecifierType.Message:    return log => log.Message;
                case SpecifierType.Content:    return log => log.Content;
                case SpecifierType.Level:      return log => log.Level;
                case SpecifierType.Name:       return log => log.Source.Name;
                case SpecifierType.TargetType: return log => log.Source.TargetType;
                case SpecifierType.DateTime:   return log => log.CreatedAt;
                case SpecifierType.NewLine:
                    return log =>
                    {
                        if (log.Content is null)
                        {
                            return null;
                        }

                        return BluConstants.NEW_LINE_CHAR;
                    };
            }

            return _ => BluConstants.None;
        }
    }
}