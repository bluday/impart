namespace BluDay.Common.Exceptions
{
    public sealed class BluInvalidViewModelTypeException : System.Exception
    {
        public BluInvalidViewModelTypeException(System.Type viewModelType)
            : base($"{viewModelType} is not of type {typeof(Domain.ViewModels.IBluViewModel)}.") { }
    }
}