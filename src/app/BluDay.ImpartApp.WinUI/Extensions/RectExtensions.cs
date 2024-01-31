namespace BluDay.Common.Extensions;

public static class RectExtensions
{
    public static Windows.Graphics.RectInt32 GetScaledRect(this Windows.Foundation.Rect source, double scale = 2.0)
    {
        return new(
            _X: (int)Math.Round(source.X * scale),
            _Y: (int)Math.Round(source.Y * scale),

            _Width:  (int)Math.Round(source.Width  * scale),
            _Height: (int)Math.Round(source.Height * scale)
        );
    }
}