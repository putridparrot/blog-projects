
using System;
using System.Runtime.InteropServices;

namespace FileLocations
{
    class Program
    {
        [DllImport("shell32.dll")]
        static extern int SHGetKnownFolderPath([MarshalAs(UnmanagedType.LPStruct)] Guid rfid, uint dwFlags, IntPtr hToken, out IntPtr pszPath);

        static void Main(string[] args)
        {
            // c:\Users\<username>\AppData\Roaming
            Print(Environment.SpecialFolder.ApplicationData);
            // c:\ProgramData
            Print(Environment.SpecialFolder.CommonApplicationData);
            // c:\Users\<username>\AppData\Local
            Print(Environment.SpecialFolder.LocalApplicationData);

            // https://stackoverflow.com/questions/4494290/detect-the-location-of-appdata-locallow
            var localLowId = new Guid("A520A1A4-1780-4FF6-BD18-167343C5AF16");
            Print("LocalLow", localLowId);

            Console.WriteLine(Environment.ExpandEnvironmentVariables("%AppData%"));
            Console.WriteLine(Environment.ExpandEnvironmentVariables(@"C:\Users\All Users\"));
        }

        private static void Print(Environment.SpecialFolder folder)
        {
            Console.WriteLine($"{folder} => {Environment.GetFolderPath(folder)}");
        }

        private static void Print(string folderName, Guid folderGuid)
        {
            var pszPath = IntPtr.Zero;
            try
            {
                int hr = SHGetKnownFolderPath(folderGuid, 0, IntPtr.Zero, out pszPath);
                if (hr < 0)
                {
                    throw Marshal.GetExceptionForHR(hr);
                }
                Console.WriteLine($"{folderName} => {Marshal.PtrToStringAuto(pszPath)}");
            }
            finally
            {
                if (pszPath != IntPtr.Zero)
                {
                    Marshal.FreeCoTaskMem(pszPath);
                }
            }
        }
    }

}
