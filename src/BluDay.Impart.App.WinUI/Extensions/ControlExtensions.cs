using Windows.Foundation;

namespace BluDay.Impart.App.WinUI.Extensions;

public static class ControlExtensions
{
    public static Rect GetVisualTransformBoundsRect(this FrameworkElement source)
    {
        return source
            .TransformToVisual(null)
            .TransformBounds(new Rect(
                x: 0,
                y: 0,
                width: source.ActualWidth,
                height: source.ActualHeight
            ));
    }
}