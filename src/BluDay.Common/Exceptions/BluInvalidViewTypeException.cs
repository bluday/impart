namespace BluDay.Common.Exceptions
{
    public sealed class BluInvalidViewTypeException : System.Exception
    {
        public BluInvalidViewTypeException(System.Type viewType)
            : base($"{viewType} is not of type {typeof(UI.IBluView)}.") { }
    }
}