using Windows.System;
using Windows.UI.Core;

namespace BluDay.Common.IO
{
    public static class Keyboard
    {
        private static CoreWindow Window { get; } = CoreWindow.GetForCurrentThread();

        public static bool IsShiftDown => IsKeyDown(VirtualKey.Shift);

        public static bool IsKeyDown(VirtualKey key)
        {
            return Window.GetKeyState(key).HasFlag(CoreVirtualKeyStates.Down);
        }
    }
}