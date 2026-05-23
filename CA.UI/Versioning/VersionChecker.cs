using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace CA.UI
{
    public enum UpdateState
    {
        UpdateAvailable,
        NoUpdates,
        ErrorCheckingUpdates
    }

    public class VersionChecker
    {
        public static UpdateState TryFindUpdates()
        {
            UpdateState updateState = UpdateState.NoUpdates;
            try
            {
                WebClient webClient = new WebClient();
                string latestVersion = webClient.DownloadString("http://utborganizations.s3.amazonaws.com/camlvn.vrs");
                Version latest = new Version(latestVersion);
                Version currentProductVersion = new Version(Application.ProductVersion);
                if(latest > currentProductVersion)
                {
                    updateState = UpdateState.UpdateAvailable;
                }
            }
            catch
            {
                updateState = UpdateState.ErrorCheckingUpdates;
            }
            return updateState;
        }

        public static void CheckForUpdates()
        {
            UpdateState updateState = TryFindUpdates();
            if(updateState == UpdateState.UpdateAvailable)
            {
                DialogResult dgResult = MessageBox.Show(Localization.Locales.Resources.Updater_Update_AvailableNewVersion, Localization.Locales.Resources.Updater_Update_Title,
                                                         MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(dgResult == DialogResult.Yes)
                {
                    Process.Start("CA.Updater.exe");
                    Application.Exit();
                }
            }
            else if(updateState == UpdateState.NoUpdates)
            {
                MessageBox.Show(Localization.Locales.Resources.Updater_Update_NotAvailable, Localization.Locales.Resources.Updater_Update_Title,
                                                         MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(Localization.Locales.Resources.Updater_ErrorMessage_Text, Localization.Locales.Resources.Updater_ErrorMessage_Title,
                                                         MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
