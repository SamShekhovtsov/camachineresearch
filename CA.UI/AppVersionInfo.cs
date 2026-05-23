using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace CA.UI
{
    partial class AppVersionInfo : Form
    {
        public AppVersionInfo()
        {
            InitializeComponent();
            Localise();
            this.Text = String.Format("{0} {1}", Localization.Locales.Resources.AppVersionInfo_About, AssemblyTitle);
            this.lblProductName.Text = AssemblyProduct;
            this.lblVersion.Text = String.Format("{0} {1} ", Localization.Locales.Resources.AppVersionInfo_Version, AssemblyVersion);
            this.lblCopyright.Text = AssemblyCopyright;
            this.lblCompanyName.Text = AssemblyCompany;
            this.txbDescription.Text = AssemblyDescription;
        }

        private void Localise()
        {
            this.lblProductName.Text = Localization.Locales.Resources.AppVersionInfo_lblProductName_Text;
            this.lblVersion.Text = Localization.Locales.Resources.AppVersionInfo_lblVersion_Text;
            this.lblCopyright.Text = Localization.Locales.Resources.AppVersionInfo_lblCopyright_Text;
            this.lblCompanyName.Text = Localization.Locales.Resources.AppVersionInfo_lblCompanyName_Text;
            this.txbDescription.Text = Localization.Locales.Resources.AppVersionInfo_txbDescription_Text;
            this.btnOkay.Text = Localization.Locales.Resources.AppVersionInfo_btnOkay_Text;
            this.Text = Localization.Locales.Resources.AppVersionInfo_Text;
        }

        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion
    }
}
