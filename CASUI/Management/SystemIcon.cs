using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace CAS.UI.Management
{
    public class SystemIcon
    {
        #region Local Constants
        private const int MAX_PATH = 256;
        private const uint SHGFI_ICON = 0x000000100;
        private const uint SHGFI_DISPLAYNAM = 0x000000200;
        private const uint SHGFI_TYPENAME = 0x000000400;
        private const uint SHGFI_ATTRIBUTES = 0x000000800;
        private const uint SHGFI_ICONLOCATION = 0x000001000;
        private const uint SHGFI_EXETYPE = 0x000002000;
        private const uint SHGFI_SYSICONINDEX = 0x000004000;
        private const uint SHGFI_LINKOVERLAY = 0x000008000;
        private const uint SHGFI_SELECTED = 0x000010000;
        private const uint SHGFI_ATTR_SPECIFIED = 0x000020000;
        private const uint SHGFI_LARGEICON = 0x000000000;
        private const uint SHGFI_SMALLICON = 0x000000001;
        private const uint SHGFI_OPENICON = 0x000000002;
        private const uint SHGFI_SHELLICONSIZE = 0x000000004;
        private const uint SHGFI_PIDL = 0x000000008;
        private const uint SHGFI_USEFILEATTRIBUTES = 0x000000010;
        private const uint SHGFI_ADDOVERLAYS = 0x000000020;
        private const uint SHGFI_OVERLAYINDEX = 0x000000040;
        private const uint FILE_ATTRIBUTE_DIRECTORY = 0x00000010;
        private const uint FILE_ATTRIBUTE_NORMAL = 0x00000080;
        private const uint FILE_ATTRIBUTE_DEVICE = 0x00000040;
        #endregion

        #region Local API
        [StructLayout(LayoutKind.Sequential)]
        private struct SHFILEINFO
        {
            public const int NAMESIZE = 80;
            public IntPtr hIcon;
            public int iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NAMESIZE)]
            public string szTypeName;
        };
        [DllImport("Shell32.dll")]
        private static extern IntPtr SHGetFileInfo(
            string pszPath,
            uint dwFileAttributes,
            ref SHFILEINFO psfi,
            uint cbFileInfo,
            uint uFlags
            );
        [DllImport("User32.dll")]
        private static extern int DestroyIcon(IntPtr hIcon);
        #endregion

        #region Public Enums
        /// <summary>
        /// The available icon sizes.
        /// </summary>
        public enum IconSize
        {
            /// <summary>
            /// Large Icons - 32 pixels by 32 pixels.
            /// </summary>
            Large = 0,
            /// <summary>
            /// Small Icons - 16 pixels by 16 pixels.
            /// </summary>
            Small = 1
        }
        #endregion

        #region Local Methods
        /// <summary>
        /// Returns the system icon for the given item
        /// </summary>
        /// <param name="path">The full path of for the item</param>
        /// <param name="fileAttributes">The type of item to get the icon for</param>
        /// <param name="size">The size of the icon to get</param>
        /// <param name="addFlags">Additional flags</param>
        /// <returns>The icon to use for the item</returns>
        private static Icon GetIcon(string path, uint fileAttributes, IconSize size, uint addFlags)
        {
            SHFILEINFO shfi = new SHFILEINFO();
            uint flags = SHGFI_ICON | SHGFI_USEFILEATTRIBUTES | addFlags;
            Icon icon = null;
            try
            {
                if (IconSize.Small == size)
                    flags += SHGFI_SMALLICON;
                else
                    flags += SHGFI_LARGEICON;
                SHGetFileInfo(path, fileAttributes, ref shfi, (uint)Marshal.SizeOf(shfi), flags);
                // copy the icon to a .NET managed icon
                //
                icon = (Icon)Icon.FromHandle(shfi.hIcon).Clone();
            }
            catch { }
            finally
            {
                // destroy the original
                //
                DestroyIcon(shfi.hIcon);
            }
            return icon;
        }
        #endregion

        #region Public Interface
        /// <summary>
        /// Returns the display icon to use for a given file.
        /// </summary>
        /// <param name="fileName">The full path of the file to get the icon for</param>
        /// <param name="size">The size of the icon to get</param>
        /// <param name="shortcut">If true draw the short cut arrow</param>
        /// <returns>The icon for the given file</returns>
        public static Icon GetFileIcon(string fileName, IconSize size, bool shortcut)
        {
            return GetIcon(fileName, FILE_ATTRIBUTE_NORMAL, size, (shortcut) ? SHGFI_LINKOVERLAY : 0);
        }
        /// <summary>
        /// Return the display icon to use for a given folder
        /// </summary>
        /// <param name="folderName">The full path of the folder</param>
        /// <param name="size">The size of icon to get</param>
        /// <param name="open">Is the folder open or closed</param>
        /// <returns>The icon to use</returns>
        public static Icon GetFolderIcon(string folderName, IconSize size, bool open)
        {
            return GetIcon(folderName, FILE_ATTRIBUTE_DIRECTORY, size, (open) ? SHGFI_OPENICON : 0);
        }
        /// <summary>
        /// Return the display icon to use for a given drive
        /// </summary>
        /// <param name="driveName">The full path of the drive</param>
        /// <param name="size">The size of icon to get</param>
        /// <returns>The icon to use</returns>
        public static Icon GetDriveIcon(string driveName, IconSize size)
        {
            return GetIcon(driveName, FILE_ATTRIBUTE_DEVICE, size, 0);
        }
        #endregion
    }
}
