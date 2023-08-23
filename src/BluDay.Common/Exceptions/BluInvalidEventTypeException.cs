namespace BluDay.Common.Exceptions
{
    public sealed class BluInvalidEventTypeException : System.Exception
    {
        public BluInvalidEventTypeException(System.Type eventType)
            : base($"{eventType} is not of type {typeof(Events.IBluEvent)}.") { }
    }
}