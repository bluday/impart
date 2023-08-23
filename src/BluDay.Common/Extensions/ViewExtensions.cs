namespace BluDay.Common.Extensions
{
    public static class ViewExtensions
    {
        public static System.Type GetAttachedViewModelType(this UI.IBluView source)
        {
            return (source as Windows.UI.Xaml.FrameworkElement)?.GetAttachedViewModelType();
        }
    }
}