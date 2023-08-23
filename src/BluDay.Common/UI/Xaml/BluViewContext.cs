using System;
using Windows.UI.Xaml;

namespace BluDay.Common.UI.Xaml
{
    public static class BluViewContext
    {
        public static DependencyProperty ViewModelProperty =
            DependencyProperty.RegisterAttached(
                BluConstants.ViewModel,
                typeof(Type),
                typeof(BluViewContext),
                new PropertyMetadata(null)
            );

        public static Type GetViewModel(DependencyObject element)
        {
            return element.GetValue(ViewModelProperty) as Type;
        }

        public static void SetViewModel(DependencyObject element, Type value)
        {
            element.SetValue(ViewModelProperty, value);
        }
    }
}