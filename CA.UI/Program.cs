using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace CA.UI
{
    [StructLayout(LayoutKind.Sequential)]
    public struct COPYDATASTRUCT
    {
        public int dwData;
        public int cbData;
        public int lpData;
    }

    static class Program
    {
        private const int WM_RESTORESTATE = 0x4A;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int SendMessage(IntPtr hwnd, int wMsg, int
        wParam, ref COPYDATASTRUCT lParam);

        [DllImport("user32.dll")]
        public static extern int SetForegroundWindow(IntPtr hWnd);

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        [STAThread]
        static void Main()
        {
            string[] args = Environment.GetCommandLineArgs();
            string filename = GetFileNameFromArgs(args);

            Process currentProcess = Process.GetCurrentProcess();
            Process[] processCollection = Process.GetProcessesByName(currentProcess.ProcessName);
            if (processCollection.Length > 1)
            {
                IntPtr mainWinHandle = IntPtr.Zero;
                Process p1 = processCollection.FirstOrDefault(pr => pr.Id != currentProcess.Id);
                if(p1!=null)
                {
                    mainWinHandle = p1.MainWindowHandle;
                }

                if (string.IsNullOrEmpty(filename))
                {
                    SetForegroundWindow(mainWinHandle);
                }
                else
                {
                    COPYDATASTRUCT cds;
                    cds.dwData = 0;
                    cds.lpData = (int)Marshal.StringToHGlobalAnsi(filename);
                    cds.cbData = filename.Length;
                    SendMessage(mainWinHandle, (int)WM_RESTORESTATE, 0, ref cds);
                }
            }
            else
            {
                if (VersionChecker.TryFindUpdates() == UpdateState.UpdateAvailable)
                {
                    DialogResult installUpdateConfResult = MessageBox.Show(Localization.Locales.Resources.Updater_Update_AvailableNewVersion,
                        Localization.Locales.Resources.Updater_Update_Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (installUpdateConfResult == DialogResult.Yes)
                    {
                        Process.Start("CA.Updater.exe");
                        return;
                    }
                }
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Thread.CurrentThread.CurrentCulture = Localization.LocalizationInfo.UserCulture;
                Thread.CurrentThread.CurrentUICulture = Localization.LocalizationInfo.UserCulture;
                Application.Run(new CellFieldUI(filename));
            }
        }

        private static string GetFileNameFromArgs(string[] args)
        {
            string filename = string.Empty;
            if (args.Length > 0)
            {
                if (args.Length == 1 && args[0].EndsWith(".camodel"))
                {
                    filename = args[0];
                }
                else if (args.Length == 2 && args[1].EndsWith(".camodel"))
                {
                    filename = args[1];
                }
            }
            return filename;
        }
    }
}
