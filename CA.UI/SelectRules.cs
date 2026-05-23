using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using CA.Modes;
using CA.UI.Infrastructure;

namespace CA.UI
{
    public partial class SelectRules : Form
    {
        public AlgorithmConfiguration UserAlgorithmConfiguration;

        public SelectRules()
        {
            InitializeComponent();
            Localize();
        }

        private void UserAgree(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != null)
            {
                UserAlgorithmConfiguration.CurrentAlgorithm = (ITestableModel)comboBox1.SelectedValue;
                UserAlgorithmConfiguration.RuleForSurv = txbForSurvival.Text;
                UserAlgorithmConfiguration.RuleForBirth = txbForBirth.Text;
                UserAlgorithmConfiguration.CurrRule = comboBox1.Text;
                Close();
            }
            else
                System.Media.SystemSounds.Beep.Play();
        }

        private void SelectRules_Load(object sender, EventArgs e)
        {
            txbForSurvival.Text = UserAlgorithmConfiguration.RuleForSurv;
            txbForBirth.Text = UserAlgorithmConfiguration.RuleForBirth;

            #region -- Setup Rules --
            string binariesFolder = Path.GetDirectoryName(Application.ExecutablePath);
            var modelsWithRules = ModelPluginLoader.GetCAModelPluginsFromLibraries();

            DataTable tbl1 = new DataTable("Правила");
            try
            {
                tbl1.ReadXmlSchema(Path.Combine(binariesFolder, "Schema"));
                foreach (ITestableModel plugin in modelsWithRules)
                {
                    DataRow rw1 = tbl1.NewRow();
                    rw1[0] = plugin.Name;
                    rw1[1] = plugin;
                    tbl1.Rows.Add(rw1);
                }

                comboBox1.DataSource = tbl1;
                comboBox1.DisplayMember = "Назва";
                comboBox1.ValueMember = "Об'єкт";
                comboBox1.SelectedValue = UserAlgorithmConfiguration.CurrentAlgorithm;
                this.comboBox1.SelectedIndexChanged +=
                    new System.EventHandler(this.comboBox1_SelectedIndexChanged);
                textBox1.Text = comboBox1.SelectedValue.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            #endregion

            //TODO Sam fix this:
            txbForBirth.Enabled = txbForSurvival.Enabled = false;
            //(comboBox1.SelectedValue.GetType() == typeof(UserOptions));            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = comboBox1.SelectedValue.ToString();
            //TODO Sam fix this:
            txbForSurvival.Enabled = txbForBirth.Enabled = false;
            //(comboBox1.SelectedValue.GetType() == typeof(UserOptions));
        }

        private void Localize()
        {
            this.btnOkay.Text = Localization.Locales.Resources.SelectRules_btnOkay_Text;
            this.gbSelectRules.Text = Localization.Locales.Resources.SelectRules_gbSelectRules_Text;
            this.lblSurvivalRules.Text = Localization.Locales.Resources.SelectRules_lblSurvivalRules_Text;
            this.lblBirthRules.Text = Localization.Locales.Resources.SelectRules_lblBirthRules_Text;
            this.Text = Localization.Locales.Resources.SelectRules_Text;
        }
    }
}
