using BluDay.Common.Extensions;
using System;

namespace BluDay.Common.Messaging
{
    public sealed class BluEventTopic
    {
        public static Type CreateGenericType(Type eventType)
        {
            return typeof(BluEventTopic<>).MakeGenericType(eventType);
        }

        public static Predicate<IBluEventTopic> GetPredicateByPropertyValue(object value)
        {
            if (value is string)
            {
                return topic => topic.Name == value as string;
            }

            if (value is Guid)
            {
                return topic => topic.Id == (Guid)value;
            }

            return topic => topic.EventType == value as Type;
        }

        public static IBluEventTopic CreateInstance(Type eventType)
        {
            return CreateInstance(eventType, name: null);
        }

        public static IBluEventTopic CreateInstance(Type eventType, string name)
        {
            var parameters = new object[] { name };

            return CreateGenericType(eventType).BluInstantiate<IBluEventTopic>(parameters);
        }
    }
}