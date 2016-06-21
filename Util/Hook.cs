using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace MiddleAge
{
    class Hook
    {
        [DllImport("kernel32.dll")]
        private static extern int GetCurrentThreadId();
        [DllImport("user32.dll")]
        private static extern IntPtr SetWindowsHookEx(int idHook,[MarshalAs(UnmanagedType.FunctionPtr)]HookProc lpfn,IntPtr hinstance,int threadId);
        [DllImport("user32.dll")]
        private static extern void UnhookWindowsHookEx(IntPtr handle);
        [DllImport("user32.dll")]
        private static extern IntPtr CallNextHookEx(IntPtr handle, int code, IntPtr wparam, IntPtr lparam);

        private enum HookType
        {
            Keyborad = 2,
        };

        private delegate IntPtr HookProc(int code, IntPtr wparam, IntPtr lapram);

        private IntPtr _nextHookPtr;
        
        private IntPtr KeyBoardHook(int code, IntPtr wparam, IntPtr lparam)
        {
            if (code < 0)
            {
                return CallNextHookEx(_nextHookPtr, code, wparam, lparam);
            }
            return (IntPtr)1;
        }

        /// <summary>
        /// 加载钩子
        /// </summary>
        public void SetHook()
        {
            if (_nextHookPtr != IntPtr.Zero) return;
            HookProc myhookproc = new HookProc(KeyBoardHook);
            _nextHookPtr = SetWindowsHookEx((int)HookType.Keyborad, myhookproc, IntPtr.Zero, GetCurrentThreadId());
        }

        /// <summary>
        /// 卸载钩子
        /// </summary>
        public void UnHook()
        {
            if (_nextHookPtr != IntPtr.Zero)
            {
                UnhookWindowsHookEx(_nextHookPtr);
                _nextHookPtr = IntPtr.Zero;
            }
        }
    }
}
