using BluDay.Common.Exceptions;
using BluDay.Common.Extensions;
using System;

namespace BluDay.Common
{
    public static class BluValidator
    {
        public static void NotNull(object value, string parameter)
        {
            if (value is null)
            {
                throw new ArgumentNullException(parameter);
            }
        }

        public static void NotNull(params (object, string)[] parameters)
        {
            NotNull(parameters, nameof(parameters));

            foreach (var (value, name) in parameters)
            {
                NotNull(value, name);
            }
        }

        public static void NotWhitespace(string value, string parameter)
        {
            if (value.BluIsWhitespace())
            {
                throw new ArgumentNullException(parameter);
            }
        }

        public static void ValidateEventType(Type value)
        {
            if (!value.Inherits<Events.IBluEvent>())
            {
                throw new BluInvalidEventTypeException(value);
            }
        }

        public static void ValidateViewType(Type value)
        {
            if (!value.IsView())
            {
                throw new BluInvalidViewTypeException(value);
            }
        }

        public static void ValidateViewModelType(Type value)
        {
            if (!value.IsViewModel())
            {
                throw new BluInvalidViewModelTypeException(value);
            }
        }
    }
}