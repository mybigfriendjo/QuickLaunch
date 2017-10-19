using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace QuickLaunch.helper {
    public class FileIconResource {

        [StructLayout(LayoutKind.Sequential)]
        public struct Shfileinfo {
            public IntPtr hIcon;
            public IntPtr iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        };

        private static class Win32 {
            public const uint SHGFI_ICON = 0x100;
            public const uint SHGFI_LARGEICON = 0x0; // Large icon
            public const uint SHGFI_SMALLICON = 0x1; // Small icon

            [DllImport("shell32.dll")]
            public static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref Shfileinfo psfi, uint cbSizeFileInfo, uint uFlags);

            [DllImport("User32.dll")]
            public static extern int DestroyIcon(IntPtr hIcon);

        }

        public static Icon GetSmallIcon(string fileName) {
            return GetIcon(fileName, Win32.SHGFI_SMALLICON);
        }

        public static Icon GetLargeIcon(string fileName) {
            return GetIcon(fileName, Win32.SHGFI_LARGEICON);
        }

        private static Icon GetIcon(string fileName, uint flags) {
            Shfileinfo shinfo = new Shfileinfo();
            Win32.SHGetFileInfo(fileName, 0, ref shinfo, (uint)Marshal.SizeOf(shinfo), Win32.SHGFI_ICON | flags);

            Icon icon = (Icon)Icon.FromHandle(shinfo.hIcon).Clone();
            Win32.DestroyIcon(shinfo.hIcon);
            return icon;
        }
    }
}
