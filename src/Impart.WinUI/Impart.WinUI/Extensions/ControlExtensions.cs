using Windows.Foundation;

namespace Impart.WinUI.Extensions;

public static class ControlExtensions
{
    public static Rect GetVisualTransformBoundsRect(this FrameworkElement source)
    {
        return source
            .TransformToVisual(visual: null)
            .TransformBounds(new Rect(
                x: 0,
                y: 0,
                width:  source.ActualWidth,
                height: source.ActualHeight
            ));
    }
}