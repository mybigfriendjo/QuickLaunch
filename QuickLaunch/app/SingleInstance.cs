using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;

namespace QuickLaunch.app {
    public class SingleInstance {
        public static string AssemblyGuid {
            get {
                object[] attributes = Assembly.GetEntryAssembly().GetCustomAttributes(typeof(GuidAttribute), false);
                return attributes.Length == 0 ? string.Empty : ((GuidAttribute)attributes[0]).Value;
            }
        }

        // ReSharper disable once InconsistentNaming
        public static readonly int WM_SHOWFIRSTINSTANCE = RegisterWindowMessage("WM_SHOWFIRSTINSTANCE|{0}", AssemblyGuid);
        // ReSharper disable once InconsistentNaming
        public const int HWND_BROADCAST = 0xffff;
        // ReSharper disable once InconsistentNaming
        public const int SW_SHOWNORMAL = 1;
        private static Mutex mutex;
        public static bool Start() {
            bool onlyInstance;
            string mutexName = $"Global\\{AssemblyGuid}";

            mutex = new Mutex(true, mutexName, out onlyInstance);
            return onlyInstance;
        }
        public static void ShowFirstInstance() {
            PostMessage(
                (IntPtr)HWND_BROADCAST,
                WM_SHOWFIRSTINSTANCE,
                IntPtr.Zero,
                IntPtr.Zero);
        }
        public static void Stop() {
            mutex.ReleaseMutex();
        }

        [DllImport("user32")]
        public static extern int RegisterWindowMessage(string message);

        public static int RegisterWindowMessage(string format, params object[] args) {
            string message = string.Format(format, args);
            return RegisterWindowMessage(message);
        }


        [DllImport("user32")]
        public static extern bool PostMessage(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam);

        [DllImport("user32")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        public static void ShowToFront(IntPtr window) {
            ShowWindow(window, SW_SHOWNORMAL);
            SetForegroundWindow(window);
        }
    }
}