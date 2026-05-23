using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using Ionic.Zip;

namespace CA.Updater
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BackgroundWorker _loader = new BackgroundWorker();
        private string PWD { get; set; }
        private string FileLication { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            PWD = "cawtomataw345";
            FileLication = "http://utborganizations.s3.amazonaws.com/camlvn.bin";
            Loaded += FormLoaded;
        }

        private void FormLoaded(object sender, RoutedEventArgs e)
        {
            //Console.ReadLine();
            _loader.DoWork += LoadNewVersion;
            _loader.RunWorkerCompleted += Completed;
            _loader.RunWorkerAsync();
            txbUpdateMessage.Text = "Update to the new version";
        }

        private void Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            if(e.Cancelled || e.Error !=null || e.Result != null)
            {
                MessageBox.Show("Unable to get version information from the server. Please check your internet connection or firewall rules.",
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Process.Start("CA.UI.exe");
            }
            else
            {
                Process.Start("CA.UI.exe");
            }
            Application.Current.Shutdown();
        }

        private void LoadNewVersion(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = null;
                WebClient webLoader = new WebClient();
                string currentFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                string zipFileName = Path.Combine(currentFolder, "camlvn.bin");
                webLoader.DownloadFile(FileLication, zipFileName);
                using (ZipFile zipFile = ZipFile.Read(webLoader.OpenRead(new Uri(zipFileName))))
                {
                    foreach (ZipEntry entry in zipFile.Entries)
                    {
                        // no need to update updater for now
                        //Console.WriteLine(entry.FileName);
                        if (entry.FileName.Contains("CA.Updater") || entry.FileName.Contains("camlvn.bin") || entry.FileName.Contains("Ionic.Zip.dll"))
                        {
                            continue;
                        }
                        entry.ExtractWithPassword(currentFolder, ExtractExistingFileAction.OverwriteSilently, PWD);
                    }
                }
                TryRemoveUpdateFile(zipFileName);
            }
            catch(Exception ex)
            {
                if (!EventLog.SourceExists("CAMACHINE"))
                {
                    EventLog.CreateEventSource("CAMACHINE", "Application");
                }
                EventLog.WriteEntry("CAMACHINE", ex.ToString(), EventLogEntryType.Error, 110007, 333);
                e.Cancel = true;
                e.Result = ex;
            }
        }

        private void TryRemoveUpdateFile(string zipFileName)
        {
            try
            {
                File.Delete(zipFileName);
            }
            catch
            {
            }
        }
    }
}
