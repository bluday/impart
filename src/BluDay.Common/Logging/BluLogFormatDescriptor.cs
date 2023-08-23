using BluDay.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BluDay.Common.Logging
{
    public sealed class BluLogFormatDescriptor
    {
        public string RawFormat { get; }

        public string FormattableFormat { get; }

        public IReadOnlyList<BluLogFormatSpecifier> Specifiers { get; }

        public BluLogFormatSpecifierType[] SpecifierTypes
        {
            get => Specifiers?.BluSelect(specifier => specifier.Type);
        }

        public Func<BluLogInfo, object>[] FormatValueAccessors { get; }

        public static BluLogFormatDescriptor Default { get; }

        public static Regex FormatRegex { get; }

        static BluLogFormatDescriptor()
        {
            FormatRegex = new Regex(
                pattern: BluConstants.LOGGER_FORMAT_REGEX_PATTERN,
                options: RegexOptions.Compiled
            );

            Default = new BluLogFormatDescriptor(
                rawFormat: BluConstants.DEFAULT_LOGGER_FORMAT
            );
        }

        public BluLogFormatDescriptor(string rawFormat)
        {
            BluValidator.NotWhitespace(rawFormat, nameof(rawFormat));

            RawFormat = rawFormat;

            Specifiers = ParseSpecifiers(rawFormat);

            var specifierTypes = SpecifierTypes;

            FormattableFormat = CreateFormattableFormat(rawFormat, specifierTypes);

            FormatValueAccessors = CreateFormatValueAccessors(specifierTypes);
        }

        public string CreateOutput(BluLogInfo log)
        {
            object[] values = GetFormatValues(log, FormatValueAccessors);

            return FormattableFormat.BluFormat(values);
        }

        private static BluLogFormatSpecifier ParseSpecifierFromRegexMatch(Match match)
        {
            string specifier = match?.Groups.BluAtIndex(1)?.Value;

            return new BluLogFormatSpecifier(specifier);
        }

        public static string CreateFormattableFormat(
            string                      rawFormat,
            BluLogFormatSpecifierType[] specifierTypes)
        {
            return rawFormat.BluReplaceToIndexes(specifierTypes);
        }

        public static object[] GetFormatValues(
            BluLogInfo                 log,
            Func<BluLogInfo, object>[] valueAccessors)
        {
            return valueAccessors.BluSelect(accessor => accessor(log));
        }

        public static Func<BluLogInfo, object> CreateFormatValueAccessor(
            BluLogFormatSpecifierType specifierType)
        {
            return BluLogFormatSpecifier.CreateValueAccessor(specifierType);
        }

        public static BluLogFormatSpecifier[] ParseSpecifiers(string rawFormat)
        {
            return FormatRegex.Matches(rawFormat).BluSelect(ParseSpecifierFromRegexMatch);
        }

        public static Func<BluLogInfo, object>[] CreateFormatValueAccessors(
            BluLogFormatSpecifierType[] specifierTypes)
        {
            return specifierTypes.BluSelect(CreateFormatValueAccessor);
        }
    }
}