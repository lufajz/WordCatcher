using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WordCatcher
{
    public class GlobalHook
    {
        private static IntPtr _keyHookID = IntPtr.Zero;
        private static IntPtr _mouseHookID = IntPtr.Zero;
        private static LowLevelProc _keyProc = KeyHookCallback;
        private static LowLevelProc _mouseProc = MouseHookCallback;
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_KEYUP = 0x0101;
        private const int WH_MOUSE_LL = 14;

        public const int WM_LBUTTONDOWN = 0x0201;
        public const int WM_LBUTTONUP = 0x0202;
        public const int WM_RBUTTONDOWN = 0x0204;
        public const int WM_RBUTTONUP = 0x0205;
        public const int WM_MBUTTONDOWN = 0x0207;
        public const int WM_MBUTTONUP = 0x0208;

        public static void SetHook()
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                _keyHookID = SetWindowsHookEx(WH_KEYBOARD_LL, _keyProc,
                    GetModuleHandle(curModule.ModuleName), 0);

                _mouseHookID = SetWindowsHookEx(WH_MOUSE_LL, _mouseProc,
                    GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        public static void ReleaseHook()
        {
            UnhookWindowsHookEx(_keyHookID);
            UnhookWindowsHookEx(_mouseHookID);
        }

        public static void ResetHook()
        {
            ReleaseHook();
            SetHook();
        }

        private static IntPtr MouseHookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            MouseHookStruct hookStruct = 
                (MouseHookStruct)Marshal.PtrToStructure(lParam,  typeof(MouseHookStruct));

            if (nCode >= 0)
            {
                int wp = wParam.ToInt32();

                if (wp == WM_LBUTTONDOWN ||
                    wp == WM_LBUTTONUP ||
                    wp == WM_RBUTTONDOWN ||
                    wp == WM_RBUTTONUP ||
                    wp == WM_MBUTTONDOWN ||
                    wp == WM_MBUTTONUP)
                {
                    OnMouseEvent(new MouseHookEventArgs(wp, hookStruct.pt.x, hookStruct.pt.y));    
                }
            }

            return CallNextHookEx(_mouseHookID, nCode, wParam, lParam);
        }

        private static IntPtr KeyHookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                int vkCode = Marshal.ReadInt32(lParam);

                if (wParam == (IntPtr)WM_KEYDOWN)
                {
                    OnKeyPressed(new KeyHookEventArgs(vkCode));
                }
                else if (wParam == (IntPtr)WM_KEYUP)
                {
                    OnKeyReleased(new KeyHookEventArgs(vkCode));
                }
            }

            return CallNextHookEx(_keyHookID, nCode, wParam, lParam);
        }

        #region Win32 API

        [StructLayout(LayoutKind.Sequential)]
        public class POINT
        {
            public int x;
            public int y;
        }

        [StructLayout(LayoutKind.Sequential)]
        public class MouseHookStruct
        {
            public POINT pt;
            public int hwnd;
            public int wHitTestCode;
            public int dwExtraInfo;
        }

        private delegate IntPtr LowLevelProc(int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook,
            LowLevelProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
            IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        #endregion

        #region Events

        public static event KeyHookHandler KeyPressed;
        public static void OnKeyPressed(KeyHookEventArgs args)
        {
            if (KeyPressed != null)
            {
                // AsyncHelper.FireAndForget(KeyPressed, new object[] { args });
                KeyPressed(args);
            }
        }

        public static event KeyHookHandler KeyReleased;
        public static void OnKeyReleased(KeyHookEventArgs args)
        {
            if (KeyReleased != null)
            {
                // AsyncHelper.FireAndForget(KeyReleased, new object[] { args });
                KeyReleased(args);
            }
        }

        public static event MouseHookHandler MouseEvent;
        public static void OnMouseEvent(MouseHookEventArgs args)
        {
            if (MouseEvent != null)
            {
                // AsyncHelper.FireAndForget(MouseEvent, new object[] { args });
                MouseEvent(args);
            }
        }

        #endregion
    }

    public delegate void KeyHookHandler(KeyHookEventArgs args);
    public class KeyHookEventArgs : EventArgs
    {
        private int mKeyCode;

        public int KeyCode
        {
          get { return mKeyCode; }
        }

        public KeyHookEventArgs(int keyCode)
        {
            mKeyCode = keyCode;
        }
    }

    public delegate void MouseHookHandler(MouseHookEventArgs args);
    public class MouseHookEventArgs : EventArgs
    {
        public int WParam { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }

        public MouseHookEventArgs(int wParam, int x, int y)
        {
            WParam = wParam;
            this.X = x;
            this.Y = y;
        }
    }
}
