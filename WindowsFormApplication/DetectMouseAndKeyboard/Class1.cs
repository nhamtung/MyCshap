using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EZDefense
{
    public class MouseKeyboardInput
    {
        public const Int32 WH_KEYBOARD_LL = 13;
        public const Int32 WH_MOUSE_LL = 14;
        public const Int32 WH_KEYBOARD = 2;
        public const Int32 WH_MOUSE = 7;
        public delegate IntPtr HookDelegate(Int32 Code, IntPtr wParam, IntPtr lParam);


        internal struct LASTINPUTINFO
        {
            public uint cbSize;
            public uint dwTime;
        }

        [DllImport("User32.dll")]
        private static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

        [DllImport("Kernel32.dll")]
        private static extern uint GetLastError();

        [DllImport("User32.dll")]
        public static extern IntPtr CallNextHookEx(IntPtr hHook, Int32 nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("User32.dll")]
        public static extern IntPtr UnhookWindowsHookEx(IntPtr hHook);

        [DllImport("User32.dll")]
        public static extern IntPtr SetWindowsHookEx(Int32 idHook, HookDelegate lpfn, IntPtr hmod, Int32 dwThreadId);

        [DllImport("kernel32.dll")]
        public static extern IntPtr GetModuleHandle(string lpModuleName);

        public event Action InputReceive;

        private IntPtr mouseHandle;
        private IntPtr keyboardHandle;
        private event HookDelegate mouseDelegate;
        private event HookDelegate keyboardDelegate;

        public MouseKeyboardInput()
        {
            mouseDelegate = MouseHookDelegate;
            keyboardDelegate = KeyboardHookDelegate;
            keyboardHandle = SetWindowsHookEx(WH_KEYBOARD_LL, keyboardDelegate, IntPtr.Zero, 0);
            mouseHandle = SetWindowsHookEx(WH_MOUSE_LL, mouseDelegate, IntPtr.Zero, 0);
        }

        ~MouseKeyboardInput()
        {
            if (keyboardHandle != IntPtr.Zero)
                UnhookWindowsHookEx(keyboardHandle);

            if (mouseHandle != IntPtr.Zero)
                UnhookWindowsHookEx(mouseHandle);
        }

        public void Dispose()
        {
            if (keyboardHandle != IntPtr.Zero)
                UnhookWindowsHookEx(keyboardHandle);

            if (mouseHandle != IntPtr.Zero)
                UnhookWindowsHookEx(mouseHandle);
        }

        private IntPtr MouseHookDelegate(Int32 Code, IntPtr wParam, IntPtr lParam)
        {
            if (Code >= 0 && InputReceive != null)
                InputReceive?.Invoke();

            return CallNextHookEx(mouseHandle, Code, wParam, lParam);
        }

        private IntPtr KeyboardHookDelegate(Int32 Code, IntPtr wParam, IntPtr lParam)
        {

            if (Code >= 0 && InputReceive != null)
                InputReceive?.Invoke();

            return CallNextHookEx(keyboardHandle, Code, wParam, lParam);
        }

        //public uint GetLastInputTime()
        //{
        //    uint idleTime = 0;
        //    LASTINPUTINFO lastInputInfo = new LASTINPUTINFO();
        //    lastInputInfo.cbSize = (uint)Marshal.SizeOf(lastInputInfo);
        //    lastInputInfo.dwTime = 0;

        //    uint envTicks = (uint)Environment.TickCount;

        //    if (GetLastInputInfo(ref lastInputInfo))
        //    {
        //        uint lastInputTick = lastInputInfo.dwTime;
        //        idleTime = envTicks - lastInputTick;
        //    }

        //    return ((idleTime > 0) ? (idleTime / 1000) : 0);
        //}

        public uint GetIdleTime()
        {
            LASTINPUTINFO lastInPut = new LASTINPUTINFO();
            lastInPut.cbSize = (uint)Marshal.SizeOf(lastInPut);
            GetLastInputInfo(ref lastInPut);

            return ((uint)Environment.TickCount - lastInPut.dwTime);
        }
        /// <summary>
        /// Get the Last input time in milliseconds
        /// </summary>
        /// <returns></returns>
        public long GetLastInputTime()
        {
            LASTINPUTINFO lastInPut = new LASTINPUTINFO();
            lastInPut.cbSize = (uint)Marshal.SizeOf(lastInPut);
            if (!GetLastInputInfo(ref lastInPut))
            {
                throw new Exception(GetLastError().ToString());
            }
            return lastInPut.dwTime;
        }
    }
}
