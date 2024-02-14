using Windows.Graphics;

namespace BluDay.Impart.App.WinUI.Extensions;

public static class WindowExtensions
{
    public static void MakeTitleBarTransparent(this AppWindow source)
    {
        AppWindowTitleBar titleBar = source.TitleBar;

        titleBar.BackgroundColor
            = titleBar.ButtonBackgroundColor
            = titleBar.ButtonInactiveBackgroundColor
            = Colors.Transparent;
    }

    public static void MoveToCenter(this AppWindow source, DisplayArea? displayArea = null)
    {
        PointInt32 position = source.GetCenteredPosition(displayArea ?? source.GetDisplayArea());

        source.Move(position);
    }

    public static void Resize(this AppWindow source, int size)
    {
        source.Resize(width: size, height: size);
    }

    public static void Resize(this AppWindow source, int width, int height)
    {
        source.Resize(new SizeInt32(width, height));
    }

    public static void SetIsMaximizable(this AppWindow source, bool value)
    {
        source.GetOverlappedPresenter()!.IsMaximizable = value;
    }

    public static void SetIsMinimizable(this AppWindow source, bool value)
    {
        source.GetOverlappedPresenter()!.IsMinimizable = value;
    }

    public static void SetIsResizable(this AppWindow source, bool value)
    {
        source.GetOverlappedPresenter()!.IsResizable = value;
    }

    public static DisplayArea GetDisplayArea(this AppWindow source, DisplayAreaFallback? areaFallback = null)
    {
        return DisplayArea.GetFromWindowId(source.Id, areaFallback ?? DisplayAreaFallback.Nearest);
    }

    public static InputNonClientPointerSource GetNonClientPointerSource(this AppWindow source)
    {
        return InputNonClientPointerSource.GetForWindowId(source.Id);
    }

    public static OverlappedPresenter GetOverlappedPresenter(this AppWindow source)
    {
        return (OverlappedPresenter)source.Presenter;
    }

    public static PointInt32 GetCenteredPosition(this AppWindow source, DisplayArea displayArea)
    {
        return new PointInt32(
            _X: (displayArea.WorkArea.Width - source.Size.Width) / 2,
            _Y: (displayArea.WorkArea.Height - source.Size.Height) / 2
        );
    }
}