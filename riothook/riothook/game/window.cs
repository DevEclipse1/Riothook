using System;
using System.Numerics;
using System.Runtime.InteropServices;

namespace riothook.game.window
{
    public class window
    {
        public static RECT windowRect;
        public static Vector2 windowLocation;
        public static Vector2 windowSize;

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        public static void GetWindowRect(IntPtr hWnd)
        {
            RECT rect;
            if (GetWindowRect(hWnd, out rect))
            {
                windowRect = rect;
                windowLocation = new Vector2(rect.Left, rect.Top);
                windowSize = new Vector2(rect.Right - rect.Left, rect.Bottom - rect.Top);
            }
        }
    }
}
