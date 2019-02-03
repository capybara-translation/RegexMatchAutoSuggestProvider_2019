using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Capybara.EditorPlugin.RegexMASProvider
{
    public static class CaretPositionUtils
    {
        # region Data Members & Structures
        [StructLayout(LayoutKind.Sequential)]    // Required by user32.dll
        public struct RECT
        {
            public uint Left;
            public uint Top;
            public uint Right;
            public uint Bottom;
        };

        [StructLayout(LayoutKind.Sequential)]    // Required by user32.dll
        public struct GUITHREADINFO
        {
            public uint cbSize;
            public uint flags;
            public IntPtr hwndActive;
            public IntPtr hwndFocus;
            public IntPtr hwndCapture;
            public IntPtr hwndMenuOwner;
            public IntPtr hwndMoveSize;
            public IntPtr hwndCaret;
            public RECT rcCaret;
        };

        //Point startPosition = new Point();       // Point required for ToolTip movement by Mouse
        //GUITHREADINFO guiInfo;                     // To store GUI Thread Information
        //Point caretPosition;                     // To store Caret Position
        # endregion

        # region DllImports
        /*- Retrieves Title Information of the specified window -*/
        [DllImport("user32.dll")]
        static extern int GetWindowText(int hWnd, StringBuilder text, int count);

        /*- Retrieves Id of the thread that created the specified window -*/
        [DllImport("user32.dll", SetLastError = true)]
        static extern uint GetWindowThreadProcessId(int hWnd, out uint lpdwProcessId);

        /*- Retrieves information about active window or any specific GUI thread -*/
        [DllImport("user32.dll", EntryPoint = "GetGUIThreadInfo")]
        public static extern bool GetGUIThreadInfo(uint tId, out GUITHREADINFO threadInfo);

        /*- Retrieves Handle to the ForeGroundWindow -*/
        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        /*- Converts window specific point to screen specific -*/
        [DllImport("user32.dll")]
        public static extern bool ClientToScreen(IntPtr hWnd, out Point position);

        [DllImport("user32.dll")]
        public static extern IntPtr SetFocus(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern IntPtr SetForegroundWindow(IntPtr hWnd);
        # endregion

        public static string GetActiveProcess()
        {
            const int nChars = 256;
            int handle = 0;
            StringBuilder Buff = new StringBuilder(nChars);
            handle = (int)GetForegroundWindow();

            // If Active window has some title info
            if (GetWindowText(handle, Buff, nChars) > 0)
            {
                uint lpdwProcessId;
                uint dwCaretID = GetWindowThreadProcessId(handle, out lpdwProcessId);
                uint dwCurrentID = (uint)Thread.CurrentThread.ManagedThreadId;
                return Process.GetProcessById((int)lpdwProcessId).ProcessName;
            }
            // Otherwise either error or non client region
            return String.Empty;
        }

        public static Point GetCaretPosition()
        {
            var guiInfo = new GUITHREADINFO();
            guiInfo.cbSize = (uint) Marshal.SizeOf(guiInfo);
            GetGUIThreadInfo(0, out guiInfo);
            
            var caretPosition = new Point();
            caretPosition.X = (int) guiInfo.rcCaret.Left;
            caretPosition.Y = (int) guiInfo.rcCaret.Bottom;
            
            ClientToScreen(guiInfo.hwndCaret, out caretPosition);

            return caretPosition;
        }

        public static FocusedControlData GetFocusedControlData()
        {
            var guiInfo = new GUITHREADINFO();
            guiInfo.cbSize = (uint)Marshal.SizeOf(guiInfo);
            GetGUIThreadInfo(0, out guiInfo);

            var caretPosition = new Point();
            caretPosition.X = (int)guiInfo.rcCaret.Left;
            caretPosition.Y = (int)guiInfo.rcCaret.Bottom;

            Control control = null;
            var handle = guiInfo.hwndFocus;
            if (handle != IntPtr.Zero)
            {
                control = Control.FromHandle(handle);
            }


            return new FocusedControlData {CaretPosition = caretPosition, FocusedControl = control};
        }
    }

    public class FocusedControlData
    {
        public Point CaretPosition { get; set; }
        public Control FocusedControl { get; set; }
    }
}
