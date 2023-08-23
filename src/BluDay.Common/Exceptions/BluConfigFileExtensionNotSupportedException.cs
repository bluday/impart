namespace BluDay.Common.Exceptions
{
    public sealed class BluConfigFileExtensionNotSupportedException : System.Exception
    {
        public BluConfigFileExtensionNotSupportedException(string extension)
            : base($"Extension {extension} is not supported.") { }
    }
}