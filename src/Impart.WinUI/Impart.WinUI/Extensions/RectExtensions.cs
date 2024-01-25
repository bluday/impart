using Windows.Graphics;

namespace Impart.WinUI.Extensions;

public static class RectExtensions
{
    public static RectInt32 GetScaledRect(this Windows.Foundation.Rect source, double scale)
    {
        return new RectInt32(
            _X: (int)Math.Round(source.X * scale),
            _Y: (int)Math.Round(source.Y * scale),

            _Width:  (int)Math.Round(source.Width  * scale),
            _Height: (int)Math.Round(source.Height * scale)
        );
    }
}