namespace BluDay.Common.Extensions
{
    public static class XamlExtensions
    {
        public static System.Type GetAttachedViewModelType(this Windows.UI.Xaml.FrameworkElement source)
        {
            return source?.GetValue(UI.Xaml.BluViewContext.ViewModelProperty) as System.Type;
        }
    }
}