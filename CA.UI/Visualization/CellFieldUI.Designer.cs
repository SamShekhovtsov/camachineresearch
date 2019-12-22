namespace CA.UI
{
    partial class CellFieldUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region -- Windows Form Designer generated code --

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.btnGoToNextGeneration = new System.Windows.Forms.Button();
			this.TimerForAutoTransitions = new System.Windows.Forms.Timer(this.components);
			this.btnStart = new System.Windows.Forms.Button();
			this.gpbAutoTransitions = new System.Windows.Forms.GroupBox();
			this.lblSpeed = new System.Windows.Forms.Label();
			this.btnAccelerate = new System.Windows.Forms.Button();
			this.btnSlowDown = new System.Windows.Forms.Button();
			this.headMenu = new System.Windows.Forms.MenuStrip();
			this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.новоеПолеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.загрузитьИзФайлаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.сохранитьВФайлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiExec = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
			this.перейтиНаХХХПоколіньToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.tsmiCreateGraph = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiBuildHistogram = new System.Windows.Forms.ToolStripMenuItem();
			this.camOptions = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiAdditionalFieldOptions = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiSetRules = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiDefaultConfigurations = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiCheckNewVersion = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiHelpCategory = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiViewHelp = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiAboutApp = new System.Windows.Forms.ToolStripMenuItem();
			this.btnClearAllMatrices = new System.Windows.Forms.Button();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.tsslTransitionStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
			this.btnExit = new System.Windows.Forms.Button();
			this.tbCellSize = new System.Windows.Forms.TrackBar();
			this.gbCellSize = new System.Windows.Forms.GroupBox();
			this.cbxCellSize = new System.Windows.Forms.ComboBox();
			this.gbMessage = new System.Windows.Forms.GroupBox();
			this.btmGbMessageOK = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this._timerForAutoGeneration = new System.Windows.Forms.Timer(this.components);
			this.button8 = new System.Windows.Forms.Button();
			this.button9 = new System.Windows.Forms.Button();
			this.button10 = new System.Windows.Forms.Button();
			this.button11 = new System.Windows.Forms.Button();
			this.timer3 = new System.Windows.Forms.Timer(this.components);
			this.gbFieldLocation = new System.Windows.Forms.GroupBox();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tpMainControlBox = new System.Windows.Forms.TabPage();
			this.tpFieldOptions = new System.Windows.Forms.TabPage();
			this.gbPlanesToShow = new System.Windows.Forms.GroupBox();
			this.btnDisplayMatrContent = new System.Windows.Forms.Button();
			this.cbxMatrix10 = new System.Windows.Forms.CheckBox();
			this.cbxMatrix9 = new System.Windows.Forms.CheckBox();
			this.cbxMatrix8 = new System.Windows.Forms.CheckBox();
			this.cbxMatrix4 = new System.Windows.Forms.CheckBox();
			this.cbxMatrix7 = new System.Windows.Forms.CheckBox();
			this.cbxMatrix3 = new System.Windows.Forms.CheckBox();
			this.cbxMatrix6 = new System.Windows.Forms.CheckBox();
			this.cbxMatrix2 = new System.Windows.Forms.CheckBox();
			this.cbxMatrix5 = new System.Windows.Forms.CheckBox();
			this.cbxMatrix1 = new System.Windows.Forms.CheckBox();
			this.cbxMatrix0 = new System.Windows.Forms.CheckBox();
			this.gbGenerateRandomPattern = new System.Windows.Forms.GroupBox();
			this.btnStartGenerateRandomPattern = new System.Windows.Forms.Button();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.btnClearSelectedPlane = new System.Windows.Forms.Button();
			this.btnSwapMatrices = new System.Windows.Forms.Button();
			this.gbSelectPlane = new System.Windows.Forms.GroupBox();
			this.rbPlane8 = new System.Windows.Forms.RadioButton();
			this.rbPlane3 = new System.Windows.Forms.RadioButton();
			this.rbPlane2 = new System.Windows.Forms.RadioButton();
			this.rbPlane1 = new System.Windows.Forms.RadioButton();
			this.rbPlane0 = new System.Windows.Forms.RadioButton();
			this.tpAnalytics = new System.Windows.Forms.TabPage();
			this.gbGraphs = new System.Windows.Forms.GroupBox();
			this.btnMakeGistogramma = new System.Windows.Forms.Button();
			this.btnShowGraph = new System.Windows.Forms.Button();
			this.btnStartPoint = new System.Windows.Forms.Button();
			this.tpDemography = new System.Windows.Forms.TabPage();
			this.plMatrixOptions = new System.Windows.Forms.Panel();
			this.lblMouseCurrentPosition = new System.Windows.Forms.Label();
			this.lblCellValDesc = new System.Windows.Forms.Label();
			this.lblCellValue = new System.Windows.Forms.Label();
			this.txbCellValue = new System.Windows.Forms.TextBox();
			this.btnSetCell = new System.Windows.Forms.Button();
			this.btnGetCell = new System.Windows.Forms.Button();
			this.cbxLayer = new System.Windows.Forms.ComboBox();
			this.txbYAxes = new System.Windows.Forms.TextBox();
			this.txbXAxes = new System.Windows.Forms.TextBox();
			this.groupBox11 = new System.Windows.Forms.GroupBox();
			this.gbPredatorsConf = new System.Windows.Forms.GroupBox();
			this.numericUpDown5 = new System.Windows.Forms.NumericUpDown();
			this.gbIntervalForBirth = new System.Windows.Forms.GroupBox();
			this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
			this.lblPredators = new System.Windows.Forms.Label();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.lblHerbivorous = new System.Windows.Forms.Label();
			this.lblEmulatorConfiguration = new System.Windows.Forms.Label();
			this.btnApplyemulatorRules = new System.Windows.Forms.Button();
			this.gbLifeDuration = new System.Windows.Forms.GroupBox();
			this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
			this.label6 = new System.Windows.Forms.Label();
			this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
			this.label7 = new System.Windows.Forms.Label();
			this.tabControl2 = new System.Windows.Forms.TabControl();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.tsbsaveResultsToFile = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbSelectRules = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbSetstartPoint = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbClearSelectedPlane = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbDoTransition = new System.Windows.Forms.ToolStripButton();
			this.toolStripTextBox2 = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.tmrMouseLocation = new System.Windows.Forms.Timer(this.components);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.gpbAutoTransitions.SuspendLayout();
			this.headMenu.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tbCellSize)).BeginInit();
			this.gbCellSize.SuspendLayout();
			this.gbMessage.SuspendLayout();
			this.gbFieldLocation.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tpMainControlBox.SuspendLayout();
			this.tpFieldOptions.SuspendLayout();
			this.gbPlanesToShow.SuspendLayout();
			this.gbGenerateRandomPattern.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.gbSelectPlane.SuspendLayout();
			this.tpAnalytics.SuspendLayout();
			this.gbGraphs.SuspendLayout();
			this.tpDemography.SuspendLayout();
			this.plMatrixOptions.SuspendLayout();
			this.groupBox11.SuspendLayout();
			this.gbPredatorsConf.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).BeginInit();
			this.gbIntervalForBirth.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			this.gbLifeDuration.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
			this.tabControl2.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pictureBox1.Location = new System.Drawing.Point(218, 78);
			this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(700, 700);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Visible = false;
			this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
			this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.uiField_MouseClick);
			this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.uiField_MouseMove);
			// 
			// btnGoToNextGeneration
			// 
			this.btnGoToNextGeneration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnGoToNextGeneration.Location = new System.Drawing.Point(29, 15);
			this.btnGoToNextGeneration.Name = "btnGoToNextGeneration";
			this.btnGoToNextGeneration.Size = new System.Drawing.Size(126, 22);
			this.btnGoToNextGeneration.TabIndex = 1;
			this.btnGoToNextGeneration.Text = "Наступне покоління";
			this.btnGoToNextGeneration.UseVisualStyleBackColor = true;
			this.btnGoToNextGeneration.Click += new System.EventHandler(this.GoToNextGeneration);
			// 
			// TimerForAutoTransitions
			// 
			this.TimerForAutoTransitions.Interval = 10;
			this.TimerForAutoTransitions.Tick += new System.EventHandler(this.TimerForAutoTransitions_Tick);
			// 
			// btnStart
			// 
			this.btnStart.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.btnStart.BackColor = System.Drawing.Color.Transparent;
			this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btnStart.Location = new System.Drawing.Point(6, 40);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(112, 23);
			this.btnStart.TabIndex = 2;
			this.btnStart.Text = "Пуск";
			this.btnStart.UseVisualStyleBackColor = false;
			this.btnStart.Click += new System.EventHandler(this.ChangeAutomaticTransitionMode);
			// 
			// gpbAutoTransitions
			// 
			this.gpbAutoTransitions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.gpbAutoTransitions.Controls.Add(this.lblSpeed);
			this.gpbAutoTransitions.Controls.Add(this.btnAccelerate);
			this.gpbAutoTransitions.Controls.Add(this.btnSlowDown);
			this.gpbAutoTransitions.Controls.Add(this.btnStart);
			this.gpbAutoTransitions.Location = new System.Drawing.Point(31, 47);
			this.gpbAutoTransitions.Name = "gpbAutoTransitions";
			this.gpbAutoTransitions.Size = new System.Drawing.Size(124, 127);
			this.gpbAutoTransitions.TabIndex = 3;
			this.gpbAutoTransitions.TabStop = false;
			this.gpbAutoTransitions.Text = "Автоматична зміна поколінь";
			// 
			// lblSpeed
			// 
			this.lblSpeed.AutoSize = true;
			this.lblSpeed.Location = new System.Drawing.Point(36, 80);
			this.lblSpeed.Name = "lblSpeed";
			this.lblSpeed.Size = new System.Drawing.Size(59, 13);
			this.lblSpeed.TabIndex = 5;
			this.lblSpeed.Text = "Швидкість";
			// 
			// btnAccelerate
			// 
			this.btnAccelerate.Enabled = false;
			this.btnAccelerate.Location = new System.Drawing.Point(76, 96);
			this.btnAccelerate.Name = "btnAccelerate";
			this.btnAccelerate.Size = new System.Drawing.Size(42, 23);
			this.btnAccelerate.TabIndex = 4;
			this.btnAccelerate.UseVisualStyleBackColor = true;
			this.btnAccelerate.Click += new System.EventHandler(this.AccelerateTheSpeed);
			// 
			// btnSlowDown
			// 
			this.btnSlowDown.Location = new System.Drawing.Point(6, 96);
			this.btnSlowDown.Name = "btnSlowDown";
			this.btnSlowDown.Size = new System.Drawing.Size(45, 23);
			this.btnSlowDown.TabIndex = 3;
			this.btnSlowDown.UseVisualStyleBackColor = true;
			this.btnSlowDown.Click += new System.EventHandler(this.SlowDownTheSpeed);
			// 
			// headMenu
			// 
			this.headMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.tsmiExec,
            this.camOptions,
            this.tsmiHelpCategory});
			this.headMenu.Location = new System.Drawing.Point(0, 0);
			this.headMenu.Name = "headMenu";
			this.headMenu.Size = new System.Drawing.Size(1107, 24);
			this.headMenu.TabIndex = 4;
			this.headMenu.Text = "headMenu";
			// 
			// файлToolStripMenuItem
			// 
			this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.новоеПолеToolStripMenuItem,
            this.toolStripSeparator1,
            this.загрузитьИзФайлаToolStripMenuItem,
            this.сохранитьВФайлToolStripMenuItem,
            this.toolStripSeparator2,
            this.выходToolStripMenuItem});
			this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
			this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
			this.файлToolStripMenuItem.Text = "&Файл";
			// 
			// новоеПолеToolStripMenuItem
			// 
			this.новоеПолеToolStripMenuItem.Name = "новоеПолеToolStripMenuItem";
			this.новоеПолеToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
			this.новоеПолеToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
			this.новоеПолеToolStripMenuItem.Text = "Очистити всі площини";
			this.новоеПолеToolStripMenuItem.Click += new System.EventHandler(this.новоеПолеClick);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(240, 6);
			// 
			// загрузитьИзФайлаToolStripMenuItem
			// 
			this.загрузитьИзФайлаToolStripMenuItem.Name = "загрузитьИзФайлаToolStripMenuItem";
			this.загрузитьИзФайлаToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.загрузитьИзФайлаToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
			this.загрузитьИзФайлаToolStripMenuItem.Text = " Завантажити з файлу";
			this.загрузитьИзФайлаToolStripMenuItem.Click += new System.EventHandler(this.загрузитьИзФайлаClick);
			// 
			// сохранитьВФайлToolStripMenuItem
			// 
			this.сохранитьВФайлToolStripMenuItem.Name = "сохранитьВФайлToolStripMenuItem";
			this.сохранитьВФайлToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.сохранитьВФайлToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
			this.сохранитьВФайлToolStripMenuItem.Text = " Зберегти в файл";
			this.сохранитьВФайлToolStripMenuItem.Click += new System.EventHandler(this.сохранитьВФайлClick);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(240, 6);
			// 
			// выходToolStripMenuItem
			// 
			this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
			this.выходToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
			this.выходToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
			this.выходToolStripMenuItem.Text = " Залишити программу";
			this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходClick);
			// 
			// tsmiExec
			// 
			this.tsmiExec.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator7,
            this.перейтиНаХХХПоколіньToolStripMenuItem,
            this.toolStripTextBox1,
            this.toolStripSeparator6,
            this.tsmiCreateGraph,
            this.tsmiBuildHistogram});
			this.tsmiExec.Name = "tsmiExec";
			this.tsmiExec.Size = new System.Drawing.Size(70, 20);
			this.tsmiExec.Text = "&Завдання";
			// 
			// toolStripSeparator7
			// 
			this.toolStripSeparator7.Name = "toolStripSeparator7";
			this.toolStripSeparator7.Size = new System.Drawing.Size(251, 6);
			// 
			// перейтиНаХХХПоколіньToolStripMenuItem
			// 
			this.перейтиНаХХХПоколіньToolStripMenuItem.Name = "перейтиНаХХХПоколіньToolStripMenuItem";
			this.перейтиНаХХХПоколіньToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
			this.перейтиНаХХХПоколіньToolStripMenuItem.Size = new System.Drawing.Size(254, 22);
			this.перейтиНаХХХПоколіньToolStripMenuItem.Text = "Перейти на ХХХ поколінь";
			this.перейтиНаХХХПоколіньToolStripMenuItem.Click += new System.EventHandler(this.перейтиНаХХХПоколіньClick);
			// 
			// toolStripTextBox1
			// 
			this.toolStripTextBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.toolStripTextBox1.MaxLength = 6;
			this.toolStripTextBox1.Name = "toolStripTextBox1";
			this.toolStripTextBox1.Size = new System.Drawing.Size(100, 23);
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(251, 6);
			// 
			// tsmiCreateGraph
			// 
			this.tsmiCreateGraph.Enabled = false;
			this.tsmiCreateGraph.Name = "tsmiCreateGraph";
			this.tsmiCreateGraph.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
			this.tsmiCreateGraph.Size = new System.Drawing.Size(254, 22);
			this.tsmiCreateGraph.Text = "Побудувати графік";
			this.tsmiCreateGraph.Click += new System.EventHandler(this.RepresentGrаph_1);
			// 
			// tsmiBuildHistogram
			// 
			this.tsmiBuildHistogram.Enabled = false;
			this.tsmiBuildHistogram.Name = "tsmiBuildHistogram";
			this.tsmiBuildHistogram.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
			this.tsmiBuildHistogram.Size = new System.Drawing.Size(254, 22);
			this.tsmiBuildHistogram.Text = "Побудувати гістограму";
			this.tsmiBuildHistogram.Click += new System.EventHandler(this.toRepresentTheHistogrаm_1);
			// 
			// camOptions
			// 
			this.camOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAdditionalFieldOptions,
            this.tsmiSetRules,
            this.tsmiDefaultConfigurations,
            this.tsmiCheckNewVersion});
			this.camOptions.Name = "camOptions";
			this.camOptions.Size = new System.Drawing.Size(48, 20);
			this.camOptions.Text = "&Опції";
			// 
			// tsmiAdditionalFieldOptions
			// 
			this.tsmiAdditionalFieldOptions.Enabled = false;
			this.tsmiAdditionalFieldOptions.Name = "tsmiAdditionalFieldOptions";
			this.tsmiAdditionalFieldOptions.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
			this.tsmiAdditionalFieldOptions.Size = new System.Drawing.Size(329, 22);
			this.tsmiAdditionalFieldOptions.Text = "Дод. парметри поля";
			this.tsmiAdditionalFieldOptions.Click += new System.EventHandler(this.ChooseParametersOfTheField);
			// 
			// tsmiSetRules
			// 
			this.tsmiSetRules.Name = "tsmiSetRules";
			this.tsmiSetRules.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
			this.tsmiSetRules.Size = new System.Drawing.Size(329, 22);
			this.tsmiSetRules.Text = "Встановити правила";
			this.tsmiSetRules.Click += new System.EventHandler(this.SetRules);
			// 
			// tsmiDefaultConfigurations
			// 
			this.tsmiDefaultConfigurations.Name = "tsmiDefaultConfigurations";
			this.tsmiDefaultConfigurations.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Space)));
			this.tsmiDefaultConfigurations.Size = new System.Drawing.Size(329, 22);
			this.tsmiDefaultConfigurations.Text = "Стандартні налаштування";
			this.tsmiDefaultConfigurations.Click += new System.EventHandler(this.DefaultConfigurationsClick);
			// 
			// tsmiCheckNewVersion
			// 
			this.tsmiCheckNewVersion.Name = "tsmiCheckNewVersion";
			this.tsmiCheckNewVersion.Size = new System.Drawing.Size(329, 22);
			this.tsmiCheckNewVersion.Text = "Перевірити доступність нової версії програми";
			this.tsmiCheckNewVersion.Click += new System.EventHandler(this.checkNewVersionToolStripMenuItem_Click);
			// 
			// tsmiHelpCategory
			// 
			this.tsmiHelpCategory.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiViewHelp,
            this.tsmiAboutApp});
			this.tsmiHelpCategory.Name = "tsmiHelpCategory";
			this.tsmiHelpCategory.Size = new System.Drawing.Size(75, 20);
			this.tsmiHelpCategory.Text = "&Допомога";
			// 
			// tsmiViewHelp
			// 
			this.tsmiViewHelp.Enabled = false;
			this.tsmiViewHelp.Name = "tsmiViewHelp";
			this.tsmiViewHelp.ShortcutKeys = System.Windows.Forms.Keys.F1;
			this.tsmiViewHelp.Size = new System.Drawing.Size(221, 22);
			this.tsmiViewHelp.Text = "Переглянути допомогу";
			this.tsmiViewHelp.Visible = false;
			this.tsmiViewHelp.Click += new System.EventHandler(this.tsmiViewHelpClick);
			// 
			// tsmiAboutApp
			// 
			this.tsmiAboutApp.Name = "tsmiAboutApp";
			this.tsmiAboutApp.Size = new System.Drawing.Size(221, 22);
			this.tsmiAboutApp.Text = "Про програму";
			this.tsmiAboutApp.Click += new System.EventHandler(this.проПрограмуClick);
			// 
			// btnClearAllMatrices
			// 
			this.btnClearAllMatrices.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClearAllMatrices.Location = new System.Drawing.Point(29, 274);
			this.btnClearAllMatrices.Name = "btnClearAllMatrices";
			this.btnClearAllMatrices.Size = new System.Drawing.Size(126, 23);
			this.btnClearAllMatrices.TabIndex = 5;
			this.btnClearAllMatrices.Text = "Очистити всі поля";
			this.btnClearAllMatrices.UseVisualStyleBackColor = true;
			this.btnClearAllMatrices.Click += new System.EventHandler(this.ClearAllMatrices);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tsslTransitionStatus,
            this.toolStripProgressBar1});
			this.statusStrip1.Location = new System.Drawing.Point(0, 786);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(1107, 22);
			this.statusStrip1.SizingGrip = false;
			this.statusStrip1.TabIndex = 6;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
			// 
			// tsslTransitionStatus
			// 
			this.tsslTransitionStatus.Name = "tsslTransitionStatus";
			this.tsslTransitionStatus.Size = new System.Drawing.Size(182, 17);
			this.tsslTransitionStatus.Text = "|    Хід виконання перерахунку:  ";
			// 
			// toolStripProgressBar1
			// 
			this.toolStripProgressBar1.Name = "toolStripProgressBar1";
			this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
			// 
			// btnExit
			// 
			this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnExit.Location = new System.Drawing.Point(29, 309);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(126, 23);
			this.btnExit.TabIndex = 7;
			this.btnExit.Text = "Залишити програму";
			this.btnExit.UseVisualStyleBackColor = true;
			this.btnExit.Click += new System.EventHandler(this.exitProgram);
			// 
			// tbCellSize
			// 
			this.tbCellSize.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.tbCellSize.Location = new System.Drawing.Point(6, 31);
			this.tbCellSize.Maximum = 30;
			this.tbCellSize.Minimum = 1;
			this.tbCellSize.Name = "tbCellSize";
			this.tbCellSize.Size = new System.Drawing.Size(104, 45);
			this.tbCellSize.TabIndex = 2;
			this.tbCellSize.Value = 1;
			this.tbCellSize.Visible = false;
			this.tbCellSize.Scroll += new System.EventHandler(this.SizeOfCellBeenChanged);
			// 
			// gbCellSize
			// 
			this.gbCellSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.gbCellSize.Controls.Add(this.cbxCellSize);
			this.gbCellSize.Controls.Add(this.tbCellSize);
			this.gbCellSize.Location = new System.Drawing.Point(31, 181);
			this.gbCellSize.Name = "gbCellSize";
			this.gbCellSize.Size = new System.Drawing.Size(124, 78);
			this.gbCellSize.TabIndex = 10;
			this.gbCellSize.TabStop = false;
			// 
			// cbxCellSize
			// 
			this.cbxCellSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxCellSize.Items.AddRange(new object[] {
            "1 px",
            "4 px",
            "8 px"});
			this.cbxCellSize.Location = new System.Drawing.Point(11, 49);
			this.cbxCellSize.Name = "cbxCellSize";
			this.cbxCellSize.Size = new System.Drawing.Size(101, 21);
			this.cbxCellSize.TabIndex = 10;
			this.cbxCellSize.SelectedIndexChanged += new System.EventHandler(this.cbxCellSize_SelectedIndexChanged);
			// 
			// gbMessage
			// 
			this.gbMessage.Controls.Add(this.btmGbMessageOK);
			this.gbMessage.Controls.Add(this.label3);
			this.gbMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.gbMessage.Location = new System.Drawing.Point(406, 225);
			this.gbMessage.Name = "gbMessage";
			this.gbMessage.Size = new System.Drawing.Size(375, 315);
			this.gbMessage.TabIndex = 11;
			this.gbMessage.TabStop = false;
			this.gbMessage.Text = "Повідомлення";
			this.gbMessage.Visible = false;
			// 
			// btmGbMessageOK
			// 
			this.btmGbMessageOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btmGbMessageOK.Location = new System.Drawing.Point(177, 271);
			this.btmGbMessageOK.Name = "btmGbMessageOK";
			this.btmGbMessageOK.Size = new System.Drawing.Size(192, 38);
			this.btmGbMessageOK.TabIndex = 1;
			this.btmGbMessageOK.Text = "ОК";
			this.btmGbMessageOK.UseVisualStyleBackColor = true;
			this.btmGbMessageOK.Click += new System.EventHandler(this.UserIsNotified);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Arial", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label3.ForeColor = System.Drawing.Color.Red;
			this.label3.Location = new System.Drawing.Point(7, 23);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(0, 41);
			this.label3.TabIndex = 0;
			// 
			// _timerForAutoGeneration
			// 
			this._timerForAutoGeneration.Interval = 50;
			this._timerForAutoGeneration.Tick += new System.EventHandler(this.SetRandomValueToSelectedMatrix);
			// 
			// button8
			// 
			this.button8.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.button8.Location = new System.Drawing.Point(48, 68);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(27, 23);
			this.button8.TabIndex = 13;
			this.button8.Text = "\\/";
			this.button8.UseVisualStyleBackColor = true;
			this.button8.Click += new System.EventHandler(this.button8_Click);
			this.button8.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button8_MouseDown);
			this.button8.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button8_MouseUp);
			// 
			// button9
			// 
			this.button9.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.button9.Location = new System.Drawing.Point(75, 45);
			this.button9.Name = "button9";
			this.button9.Size = new System.Drawing.Size(27, 23);
			this.button9.TabIndex = 14;
			this.button9.Text = ">>";
			this.button9.UseVisualStyleBackColor = true;
			this.button9.Click += new System.EventHandler(this.button9_Click);
			this.button9.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button9_MouseDown);
			this.button9.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button9_MouseUp);
			// 
			// button10
			// 
			this.button10.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.button10.Location = new System.Drawing.Point(48, 22);
			this.button10.Name = "button10";
			this.button10.Size = new System.Drawing.Size(27, 23);
			this.button10.TabIndex = 15;
			this.button10.Text = "/\\";
			this.button10.UseVisualStyleBackColor = true;
			this.button10.Click += new System.EventHandler(this.button10_Click);
			this.button10.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button10_MouseDown);
			this.button10.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button10_MouseUp);
			// 
			// button11
			// 
			this.button11.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.button11.Location = new System.Drawing.Point(21, 45);
			this.button11.Name = "button11";
			this.button11.Size = new System.Drawing.Size(27, 23);
			this.button11.TabIndex = 16;
			this.button11.Text = "<<";
			this.button11.UseVisualStyleBackColor = true;
			this.button11.Click += new System.EventHandler(this.button11_Click);
			this.button11.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button11_MouseDown);
			this.button11.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button11_MouseUp);
			// 
			// timer3
			// 
			this.timer3.Interval = 5;
			this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
			// 
			// gbFieldLocation
			// 
			this.gbFieldLocation.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.gbFieldLocation.Controls.Add(this.button10);
			this.gbFieldLocation.Controls.Add(this.button11);
			this.gbFieldLocation.Controls.Add(this.button8);
			this.gbFieldLocation.Controls.Add(this.button9);
			this.gbFieldLocation.Location = new System.Drawing.Point(31, 344);
			this.gbFieldLocation.Name = "gbFieldLocation";
			this.gbFieldLocation.Size = new System.Drawing.Size(124, 105);
			this.gbFieldLocation.TabIndex = 17;
			this.gbFieldLocation.TabStop = false;
			this.gbFieldLocation.Text = "Розміщення поля";
			this.gbFieldLocation.Visible = false;
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.tabControl1.Controls.Add(this.tpMainControlBox);
			this.tabControl1.Controls.Add(this.tpFieldOptions);
			this.tabControl1.Controls.Add(this.tpAnalytics);
			this.tabControl1.Location = new System.Drawing.Point(0, 52);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(200, 726);
			this.tabControl1.TabIndex = 18;
			// 
			// tpMainControlBox
			// 
			this.tpMainControlBox.Controls.Add(this.gpbAutoTransitions);
			this.tpMainControlBox.Controls.Add(this.gbFieldLocation);
			this.tpMainControlBox.Controls.Add(this.btnGoToNextGeneration);
			this.tpMainControlBox.Controls.Add(this.btnClearAllMatrices);
			this.tpMainControlBox.Controls.Add(this.gbCellSize);
			this.tpMainControlBox.Controls.Add(this.btnExit);
			this.tpMainControlBox.Location = new System.Drawing.Point(4, 22);
			this.tpMainControlBox.Name = "tpMainControlBox";
			this.tpMainControlBox.Padding = new System.Windows.Forms.Padding(3);
			this.tpMainControlBox.Size = new System.Drawing.Size(192, 700);
			this.tpMainControlBox.TabIndex = 0;
			this.tpMainControlBox.Text = "Головна";
			this.tpMainControlBox.UseVisualStyleBackColor = true;
			// 
			// tpFieldOptions
			// 
			this.tpFieldOptions.Controls.Add(this.gbPlanesToShow);
			this.tpFieldOptions.Controls.Add(this.gbGenerateRandomPattern);
			this.tpFieldOptions.Controls.Add(this.groupBox6);
			this.tpFieldOptions.Controls.Add(this.gbSelectPlane);
			this.tpFieldOptions.Location = new System.Drawing.Point(4, 22);
			this.tpFieldOptions.Name = "tpFieldOptions";
			this.tpFieldOptions.Padding = new System.Windows.Forms.Padding(3);
			this.tpFieldOptions.Size = new System.Drawing.Size(192, 700);
			this.tpFieldOptions.TabIndex = 1;
			this.tpFieldOptions.Text = "Поле";
			this.tpFieldOptions.UseVisualStyleBackColor = true;
			// 
			// gbPlanesToShow
			// 
			this.gbPlanesToShow.Controls.Add(this.btnDisplayMatrContent);
			this.gbPlanesToShow.Controls.Add(this.cbxMatrix10);
			this.gbPlanesToShow.Controls.Add(this.cbxMatrix9);
			this.gbPlanesToShow.Controls.Add(this.cbxMatrix8);
			this.gbPlanesToShow.Controls.Add(this.cbxMatrix4);
			this.gbPlanesToShow.Controls.Add(this.cbxMatrix7);
			this.gbPlanesToShow.Controls.Add(this.cbxMatrix3);
			this.gbPlanesToShow.Controls.Add(this.cbxMatrix6);
			this.gbPlanesToShow.Controls.Add(this.cbxMatrix2);
			this.gbPlanesToShow.Controls.Add(this.cbxMatrix5);
			this.gbPlanesToShow.Controls.Add(this.cbxMatrix1);
			this.gbPlanesToShow.Controls.Add(this.cbxMatrix0);
			this.gbPlanesToShow.Location = new System.Drawing.Point(19, 121);
			this.gbPlanesToShow.Name = "gbPlanesToShow";
			this.gbPlanesToShow.Size = new System.Drawing.Size(150, 200);
			this.gbPlanesToShow.TabIndex = 3;
			this.gbPlanesToShow.TabStop = false;
			this.gbPlanesToShow.Text = "Оберіть площини для перегляду";
			// 
			// btnDisplayMatrContent
			// 
			this.btnDisplayMatrContent.Location = new System.Drawing.Point(14, 170);
			this.btnDisplayMatrContent.Name = "btnDisplayMatrContent";
			this.btnDisplayMatrContent.Size = new System.Drawing.Size(120, 23);
			this.btnDisplayMatrContent.TabIndex = 5;
			this.btnDisplayMatrContent.Text = "Переглянути";
			this.btnDisplayMatrContent.UseVisualStyleBackColor = true;
			this.btnDisplayMatrContent.Click += new System.EventHandler(this.DisplayContenOfTheSelectedMatrices);
			// 
			// cbxMatrix10
			// 
			this.cbxMatrix10.AutoSize = true;
			this.cbxMatrix10.Location = new System.Drawing.Point(87, 122);
			this.cbxMatrix10.Name = "cbxMatrix10";
			this.cbxMatrix10.Size = new System.Drawing.Size(38, 17);
			this.cbxMatrix10.TabIndex = 4;
			this.cbxMatrix10.Text = "10";
			this.cbxMatrix10.UseVisualStyleBackColor = true;
			this.cbxMatrix10.CheckedChanged += new System.EventHandler(this.DisplayContenOfTheSelectedMatrices);
			// 
			// cbxMatrix9
			// 
			this.cbxMatrix9.AutoSize = true;
			this.cbxMatrix9.Location = new System.Drawing.Point(87, 98);
			this.cbxMatrix9.Name = "cbxMatrix9";
			this.cbxMatrix9.Size = new System.Drawing.Size(32, 17);
			this.cbxMatrix9.TabIndex = 4;
			this.cbxMatrix9.Text = "9";
			this.cbxMatrix9.UseVisualStyleBackColor = true;
			this.cbxMatrix9.CheckedChanged += new System.EventHandler(this.DisplayContenOfTheSelectedMatrices);
			// 
			// cbxMatrix8
			// 
			this.cbxMatrix8.AutoSize = true;
			this.cbxMatrix8.Location = new System.Drawing.Point(87, 77);
			this.cbxMatrix8.Name = "cbxMatrix8";
			this.cbxMatrix8.Size = new System.Drawing.Size(32, 17);
			this.cbxMatrix8.TabIndex = 3;
			this.cbxMatrix8.Text = "8";
			this.cbxMatrix8.UseVisualStyleBackColor = true;
			this.cbxMatrix8.CheckedChanged += new System.EventHandler(this.DisplayContenOfTheSelectedMatrices);
			// 
			// cbxMatrix4
			// 
			this.cbxMatrix4.AutoSize = true;
			this.cbxMatrix4.Location = new System.Drawing.Point(12, 121);
			this.cbxMatrix4.Name = "cbxMatrix4";
			this.cbxMatrix4.Size = new System.Drawing.Size(32, 17);
			this.cbxMatrix4.TabIndex = 4;
			this.cbxMatrix4.Text = "4";
			this.cbxMatrix4.UseVisualStyleBackColor = true;
			this.cbxMatrix4.CheckedChanged += new System.EventHandler(this.DisplayContenOfTheSelectedMatrices);
			// 
			// cbxMatrix7
			// 
			this.cbxMatrix7.AutoSize = true;
			this.cbxMatrix7.Location = new System.Drawing.Point(87, 55);
			this.cbxMatrix7.Name = "cbxMatrix7";
			this.cbxMatrix7.Size = new System.Drawing.Size(32, 17);
			this.cbxMatrix7.TabIndex = 2;
			this.cbxMatrix7.Text = "7";
			this.cbxMatrix7.UseVisualStyleBackColor = true;
			this.cbxMatrix7.CheckedChanged += new System.EventHandler(this.DisplayContenOfTheSelectedMatrices);
			// 
			// cbxMatrix3
			// 
			this.cbxMatrix3.AutoSize = true;
			this.cbxMatrix3.Location = new System.Drawing.Point(12, 100);
			this.cbxMatrix3.Name = "cbxMatrix3";
			this.cbxMatrix3.Size = new System.Drawing.Size(32, 17);
			this.cbxMatrix3.TabIndex = 3;
			this.cbxMatrix3.Text = "3";
			this.cbxMatrix3.UseVisualStyleBackColor = true;
			this.cbxMatrix3.CheckedChanged += new System.EventHandler(this.DisplayContenOfTheSelectedMatrices);
			// 
			// cbxMatrix6
			// 
			this.cbxMatrix6.AutoSize = true;
			this.cbxMatrix6.Location = new System.Drawing.Point(87, 31);
			this.cbxMatrix6.Name = "cbxMatrix6";
			this.cbxMatrix6.Size = new System.Drawing.Size(32, 17);
			this.cbxMatrix6.TabIndex = 1;
			this.cbxMatrix6.Text = "6";
			this.cbxMatrix6.UseVisualStyleBackColor = true;
			this.cbxMatrix6.CheckedChanged += new System.EventHandler(this.DisplayContenOfTheSelectedMatrices);
			// 
			// cbxMatrix2
			// 
			this.cbxMatrix2.AutoSize = true;
			this.cbxMatrix2.Location = new System.Drawing.Point(12, 77);
			this.cbxMatrix2.Name = "cbxMatrix2";
			this.cbxMatrix2.Size = new System.Drawing.Size(32, 17);
			this.cbxMatrix2.TabIndex = 2;
			this.cbxMatrix2.Text = "2";
			this.cbxMatrix2.UseVisualStyleBackColor = true;
			this.cbxMatrix2.CheckedChanged += new System.EventHandler(this.DisplayContenOfTheSelectedMatrices);
			// 
			// cbxMatrix5
			// 
			this.cbxMatrix5.AutoSize = true;
			this.cbxMatrix5.Location = new System.Drawing.Point(12, 144);
			this.cbxMatrix5.Name = "cbxMatrix5";
			this.cbxMatrix5.Size = new System.Drawing.Size(32, 17);
			this.cbxMatrix5.TabIndex = 0;
			this.cbxMatrix5.Text = "5";
			this.cbxMatrix5.UseVisualStyleBackColor = true;
			this.cbxMatrix5.CheckedChanged += new System.EventHandler(this.DisplayContenOfTheSelectedMatrices);
			// 
			// cbxMatrix1
			// 
			this.cbxMatrix1.AutoSize = true;
			this.cbxMatrix1.Location = new System.Drawing.Point(12, 54);
			this.cbxMatrix1.Name = "cbxMatrix1";
			this.cbxMatrix1.Size = new System.Drawing.Size(32, 17);
			this.cbxMatrix1.TabIndex = 1;
			this.cbxMatrix1.Text = "1";
			this.cbxMatrix1.UseVisualStyleBackColor = true;
			this.cbxMatrix1.CheckedChanged += new System.EventHandler(this.DisplayContenOfTheSelectedMatrices);
			// 
			// cbxMatrix0
			// 
			this.cbxMatrix0.AutoSize = true;
			this.cbxMatrix0.Location = new System.Drawing.Point(12, 30);
			this.cbxMatrix0.Name = "cbxMatrix0";
			this.cbxMatrix0.Size = new System.Drawing.Size(32, 17);
			this.cbxMatrix0.TabIndex = 0;
			this.cbxMatrix0.Text = "0";
			this.cbxMatrix0.UseVisualStyleBackColor = true;
			this.cbxMatrix0.CheckedChanged += new System.EventHandler(this.DisplayContenOfTheSelectedMatrices);
			// 
			// gbGenerateRandomPattern
			// 
			this.gbGenerateRandomPattern.Controls.Add(this.btnStartGenerateRandomPattern);
			this.gbGenerateRandomPattern.Location = new System.Drawing.Point(19, 333);
			this.gbGenerateRandomPattern.Name = "gbGenerateRandomPattern";
			this.gbGenerateRandomPattern.Size = new System.Drawing.Size(150, 76);
			this.gbGenerateRandomPattern.TabIndex = 2;
			this.gbGenerateRandomPattern.TabStop = false;
			this.gbGenerateRandomPattern.Text = "Генерація випадкового патерну для обраної площини";
			// 
			// btnStartGenerateRandomPattern
			// 
			this.btnStartGenerateRandomPattern.Location = new System.Drawing.Point(13, 47);
			this.btnStartGenerateRandomPattern.Name = "btnStartGenerateRandomPattern";
			this.btnStartGenerateRandomPattern.Size = new System.Drawing.Size(120, 23);
			this.btnStartGenerateRandomPattern.TabIndex = 0;
			this.btnStartGenerateRandomPattern.Text = "Розпочати";
			this.btnStartGenerateRandomPattern.UseVisualStyleBackColor = true;
			this.btnStartGenerateRandomPattern.Click += new System.EventHandler(this.GenerateRandomPattern);
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.btnClearSelectedPlane);
			this.groupBox6.Controls.Add(this.btnSwapMatrices);
			this.groupBox6.Location = new System.Drawing.Point(19, 420);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(150, 91);
			this.groupBox6.TabIndex = 1;
			this.groupBox6.TabStop = false;
			// 
			// btnClearSelectedPlane
			// 
			this.btnClearSelectedPlane.Location = new System.Drawing.Point(13, 21);
			this.btnClearSelectedPlane.Name = "btnClearSelectedPlane";
			this.btnClearSelectedPlane.Size = new System.Drawing.Size(121, 23);
			this.btnClearSelectedPlane.TabIndex = 3;
			this.btnClearSelectedPlane.Text = "Очистити площину";
			this.btnClearSelectedPlane.UseVisualStyleBackColor = true;
			this.btnClearSelectedPlane.Click += new System.EventHandler(this.ClearSelectedPlane_Click);
			// 
			// btnSwapMatrices
			// 
			this.btnSwapMatrices.Location = new System.Drawing.Point(13, 50);
			this.btnSwapMatrices.Name = "btnSwapMatrices";
			this.btnSwapMatrices.Size = new System.Drawing.Size(120, 23);
			this.btnSwapMatrices.TabIndex = 0;
			this.btnSwapMatrices.Text = "Обміняти масиви";
			this.btnSwapMatrices.UseVisualStyleBackColor = true;
			this.btnSwapMatrices.Click += new System.EventHandler(this.toExchangePlanes);
			// 
			// gbSelectPlane
			// 
			this.gbSelectPlane.Controls.Add(this.rbPlane8);
			this.gbSelectPlane.Controls.Add(this.rbPlane3);
			this.gbSelectPlane.Controls.Add(this.rbPlane2);
			this.gbSelectPlane.Controls.Add(this.rbPlane1);
			this.gbSelectPlane.Controls.Add(this.rbPlane0);
			this.gbSelectPlane.Location = new System.Drawing.Point(19, 18);
			this.gbSelectPlane.Name = "gbSelectPlane";
			this.gbSelectPlane.Size = new System.Drawing.Size(150, 91);
			this.gbSelectPlane.TabIndex = 0;
			this.gbSelectPlane.TabStop = false;
			this.gbSelectPlane.Text = "Вибір площини для змін";
			// 
			// rbPlane8
			// 
			this.rbPlane8.AutoSize = true;
			this.rbPlane8.Location = new System.Drawing.Point(67, 44);
			this.rbPlane8.Name = "rbPlane8";
			this.rbPlane8.Size = new System.Drawing.Size(31, 17);
			this.rbPlane8.TabIndex = 11;
			this.rbPlane8.TabStop = true;
			this.rbPlane8.Text = "8";
			this.rbPlane8.UseVisualStyleBackColor = true;
			// 
			// rbPlane3
			// 
			this.rbPlane3.AutoSize = true;
			this.rbPlane3.Location = new System.Drawing.Point(67, 21);
			this.rbPlane3.Name = "rbPlane3";
			this.rbPlane3.Size = new System.Drawing.Size(31, 17);
			this.rbPlane3.TabIndex = 6;
			this.rbPlane3.TabStop = true;
			this.rbPlane3.Text = "3";
			this.rbPlane3.UseVisualStyleBackColor = true;
			// 
			// rbPlane2
			// 
			this.rbPlane2.AutoSize = true;
			this.rbPlane2.Location = new System.Drawing.Point(13, 67);
			this.rbPlane2.Name = "rbPlane2";
			this.rbPlane2.Size = new System.Drawing.Size(31, 17);
			this.rbPlane2.TabIndex = 5;
			this.rbPlane2.TabStop = true;
			this.rbPlane2.Text = "2";
			this.rbPlane2.UseVisualStyleBackColor = true;
			// 
			// rbPlane1
			// 
			this.rbPlane1.AutoSize = true;
			this.rbPlane1.Location = new System.Drawing.Point(13, 44);
			this.rbPlane1.Name = "rbPlane1";
			this.rbPlane1.Size = new System.Drawing.Size(31, 17);
			this.rbPlane1.TabIndex = 2;
			this.rbPlane1.TabStop = true;
			this.rbPlane1.Text = "1";
			this.rbPlane1.UseVisualStyleBackColor = true;
			// 
			// rbPlane0
			// 
			this.rbPlane0.AutoSize = true;
			this.rbPlane0.Location = new System.Drawing.Point(13, 21);
			this.rbPlane0.Name = "rbPlane0";
			this.rbPlane0.Size = new System.Drawing.Size(31, 17);
			this.rbPlane0.TabIndex = 1;
			this.rbPlane0.TabStop = true;
			this.rbPlane0.Text = "0";
			this.rbPlane0.UseVisualStyleBackColor = true;
			// 
			// tpAnalytics
			// 
			this.tpAnalytics.Controls.Add(this.gbGraphs);
			this.tpAnalytics.Location = new System.Drawing.Point(4, 22);
			this.tpAnalytics.Name = "tpAnalytics";
			this.tpAnalytics.Padding = new System.Windows.Forms.Padding(3);
			this.tpAnalytics.Size = new System.Drawing.Size(192, 700);
			this.tpAnalytics.TabIndex = 2;
			this.tpAnalytics.Text = "Відстеження";
			this.tpAnalytics.UseVisualStyleBackColor = true;
			// 
			// gbGraphs
			// 
			this.gbGraphs.Controls.Add(this.btnMakeGistogramma);
			this.gbGraphs.Controls.Add(this.btnShowGraph);
			this.gbGraphs.Controls.Add(this.btnStartPoint);
			this.gbGraphs.Enabled = false;
			this.gbGraphs.Location = new System.Drawing.Point(12, 6);
			this.gbGraphs.Name = "gbGraphs";
			this.gbGraphs.Size = new System.Drawing.Size(174, 123);
			this.gbGraphs.TabIndex = 19;
			this.gbGraphs.TabStop = false;
			this.gbGraphs.Text = "Графіки";
			this.gbGraphs.Visible = false;
			// 
			// btnMakeGistogramma
			// 
			this.btnMakeGistogramma.Enabled = false;
			this.btnMakeGistogramma.Location = new System.Drawing.Point(10, 81);
			this.btnMakeGistogramma.Name = "btnMakeGistogramma";
			this.btnMakeGistogramma.Size = new System.Drawing.Size(151, 23);
			this.btnMakeGistogramma.TabIndex = 19;
			this.btnMakeGistogramma.Text = "Побудувати гістограму";
			this.btnMakeGistogramma.UseVisualStyleBackColor = true;
			this.btnMakeGistogramma.Click += new System.EventHandler(this.RepresentTheHistogram);
			// 
			// btnShowGraph
			// 
			this.btnShowGraph.Enabled = false;
			this.btnShowGraph.Location = new System.Drawing.Point(10, 50);
			this.btnShowGraph.Name = "btnShowGraph";
			this.btnShowGraph.Size = new System.Drawing.Size(151, 23);
			this.btnShowGraph.TabIndex = 0;
			this.btnShowGraph.Text = "Показати графік";
			this.btnShowGraph.UseVisualStyleBackColor = true;
			this.btnShowGraph.Click += new System.EventHandler(this.toRepresentTheGraph);
			// 
			// btnStartPoint
			// 
			this.btnStartPoint.Enabled = false;
			this.btnStartPoint.Location = new System.Drawing.Point(10, 21);
			this.btnStartPoint.Name = "btnStartPoint";
			this.btnStartPoint.Size = new System.Drawing.Size(151, 23);
			this.btnStartPoint.TabIndex = 18;
			this.btnStartPoint.Text = "Точка відліку";
			this.btnStartPoint.UseVisualStyleBackColor = true;
			this.btnStartPoint.Click += new System.EventHandler(this.SetAPoint_1);
			// 
			// tpDemography
			// 
			this.tpDemography.Controls.Add(this.plMatrixOptions);
			this.tpDemography.Controls.Add(this.groupBox11);
			this.tpDemography.Location = new System.Drawing.Point(4, 22);
			this.tpDemography.Name = "tpDemography";
			this.tpDemography.Padding = new System.Windows.Forms.Padding(3);
			this.tpDemography.Size = new System.Drawing.Size(152, 700);
			this.tpDemography.TabIndex = 1;
			this.tpDemography.Text = "Демографія";
			this.tpDemography.UseVisualStyleBackColor = true;
			// 
			// plMatrixOptions
			// 
			this.plMatrixOptions.Controls.Add(this.lblMouseCurrentPosition);
			this.plMatrixOptions.Controls.Add(this.lblCellValDesc);
			this.plMatrixOptions.Controls.Add(this.lblCellValue);
			this.plMatrixOptions.Controls.Add(this.txbCellValue);
			this.plMatrixOptions.Controls.Add(this.btnSetCell);
			this.plMatrixOptions.Controls.Add(this.btnGetCell);
			this.plMatrixOptions.Controls.Add(this.cbxLayer);
			this.plMatrixOptions.Controls.Add(this.txbYAxes);
			this.plMatrixOptions.Controls.Add(this.txbXAxes);
			this.plMatrixOptions.Location = new System.Drawing.Point(1, 0);
			this.plMatrixOptions.Name = "plMatrixOptions";
			this.plMatrixOptions.Size = new System.Drawing.Size(151, 403);
			this.plMatrixOptions.TabIndex = 5;
			// 
			// lblMouseCurrentPosition
			// 
			this.lblMouseCurrentPosition.AutoSize = true;
			this.lblMouseCurrentPosition.Location = new System.Drawing.Point(19, 206);
			this.lblMouseCurrentPosition.Name = "lblMouseCurrentPosition";
			this.lblMouseCurrentPosition.Size = new System.Drawing.Size(35, 13);
			this.lblMouseCurrentPosition.TabIndex = 8;
			this.lblMouseCurrentPosition.Text = "label1";
			// 
			// lblCellValDesc
			// 
			this.lblCellValDesc.AutoSize = true;
			this.lblCellValDesc.Location = new System.Drawing.Point(15, 127);
			this.lblCellValDesc.Name = "lblCellValDesc";
			this.lblCellValDesc.Size = new System.Drawing.Size(0, 13);
			this.lblCellValDesc.TabIndex = 7;
			// 
			// lblCellValue
			// 
			this.lblCellValue.AutoSize = true;
			this.lblCellValue.Location = new System.Drawing.Point(16, 20);
			this.lblCellValue.Name = "lblCellValue";
			this.lblCellValue.Size = new System.Drawing.Size(35, 13);
			this.lblCellValue.TabIndex = 6;
			this.lblCellValue.Text = "label1";
			// 
			// txbCellValue
			// 
			this.txbCellValue.Location = new System.Drawing.Point(50, 124);
			this.txbCellValue.Name = "txbCellValue";
			this.txbCellValue.Size = new System.Drawing.Size(58, 20);
			this.txbCellValue.TabIndex = 5;
			this.txbCellValue.Text = "100";
			// 
			// btnSetCell
			// 
			this.btnSetCell.Location = new System.Drawing.Point(86, 161);
			this.btnSetCell.Name = "btnSetCell";
			this.btnSetCell.Size = new System.Drawing.Size(54, 23);
			this.btnSetCell.TabIndex = 4;
			this.btnSetCell.Text = "button2";
			this.btnSetCell.UseVisualStyleBackColor = true;
			this.btnSetCell.Click += new System.EventHandler(this.btnSetCell_Click);
			// 
			// btnGetCell
			// 
			this.btnGetCell.Location = new System.Drawing.Point(17, 161);
			this.btnGetCell.Name = "btnGetCell";
			this.btnGetCell.Size = new System.Drawing.Size(61, 23);
			this.btnGetCell.TabIndex = 3;
			this.btnGetCell.Text = "button1";
			this.btnGetCell.UseVisualStyleBackColor = true;
			this.btnGetCell.Click += new System.EventHandler(this.btnGetCell_Click);
			// 
			// cbxLayer
			// 
			this.cbxLayer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxLayer.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
			this.cbxLayer.Location = new System.Drawing.Point(16, 44);
			this.cbxLayer.Name = "cbxLayer";
			this.cbxLayer.Size = new System.Drawing.Size(124, 21);
			this.cbxLayer.TabIndex = 2;
			// 
			// txbYAxes
			// 
			this.txbYAxes.Location = new System.Drawing.Point(95, 80);
			this.txbYAxes.Name = "txbYAxes";
			this.txbYAxes.Size = new System.Drawing.Size(44, 20);
			this.txbYAxes.TabIndex = 1;
			this.txbYAxes.Text = "40";
			// 
			// txbXAxes
			// 
			this.txbXAxes.Location = new System.Drawing.Point(16, 80);
			this.txbXAxes.Name = "txbXAxes";
			this.txbXAxes.Size = new System.Drawing.Size(45, 20);
			this.txbXAxes.TabIndex = 0;
			this.txbXAxes.Text = "25";
			// 
			// groupBox11
			// 
			this.groupBox11.Controls.Add(this.gbPredatorsConf);
			this.groupBox11.Controls.Add(this.gbIntervalForBirth);
			this.groupBox11.Controls.Add(this.lblEmulatorConfiguration);
			this.groupBox11.Controls.Add(this.btnApplyemulatorRules);
			this.groupBox11.Controls.Add(this.gbLifeDuration);
			this.groupBox11.Location = new System.Drawing.Point(6, 6);
			this.groupBox11.Name = "groupBox11";
			this.groupBox11.Size = new System.Drawing.Size(140, 364);
			this.groupBox11.TabIndex = 22;
			this.groupBox11.TabStop = false;
			this.groupBox11.Visible = false;
			// 
			// gbPredatorsConf
			// 
			this.gbPredatorsConf.Controls.Add(this.numericUpDown5);
			this.gbPredatorsConf.Location = new System.Drawing.Point(5, 236);
			this.gbPredatorsConf.Name = "gbPredatorsConf";
			this.gbPredatorsConf.Size = new System.Drawing.Size(150, 53);
			this.gbPredatorsConf.TabIndex = 4;
			this.gbPredatorsConf.TabStop = false;
			this.gbPredatorsConf.Text = "Час голодної смерті у хижаків";
			// 
			// numericUpDown5
			// 
			this.numericUpDown5.Location = new System.Drawing.Point(75, 21);
			this.numericUpDown5.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.numericUpDown5.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDown5.Name = "numericUpDown5";
			this.numericUpDown5.Size = new System.Drawing.Size(71, 20);
			this.numericUpDown5.TabIndex = 8;
			this.numericUpDown5.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// gbIntervalForBirth
			// 
			this.gbIntervalForBirth.Controls.Add(this.numericUpDown2);
			this.gbIntervalForBirth.Controls.Add(this.lblPredators);
			this.gbIntervalForBirth.Controls.Add(this.numericUpDown1);
			this.gbIntervalForBirth.Controls.Add(this.lblHerbivorous);
			this.gbIntervalForBirth.Location = new System.Drawing.Point(5, 42);
			this.gbIntervalForBirth.Name = "gbIntervalForBirth";
			this.gbIntervalForBirth.Size = new System.Drawing.Size(150, 94);
			this.gbIntervalForBirth.TabIndex = 0;
			this.gbIntervalForBirth.TabStop = false;
			this.gbIntervalForBirth.Text = "Інтервал народження потомства";
			// 
			// numericUpDown2
			// 
			this.numericUpDown2.Location = new System.Drawing.Point(75, 61);
			this.numericUpDown2.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.numericUpDown2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDown2.Name = "numericUpDown2";
			this.numericUpDown2.Size = new System.Drawing.Size(71, 20);
			this.numericUpDown2.TabIndex = 3;
			this.numericUpDown2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// lblPredators
			// 
			this.lblPredators.AutoSize = true;
			this.lblPredators.Location = new System.Drawing.Point(6, 61);
			this.lblPredators.Name = "lblPredators";
			this.lblPredators.Size = new System.Drawing.Size(46, 13);
			this.lblPredators.TabIndex = 2;
			this.lblPredators.Text = "Хижаки";
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.Location = new System.Drawing.Point(75, 35);
			this.numericUpDown1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(71, 20);
			this.numericUpDown1.TabIndex = 1;
			this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// lblHerbivorous
			// 
			this.lblHerbivorous.AutoSize = true;
			this.lblHerbivorous.Location = new System.Drawing.Point(6, 35);
			this.lblHerbivorous.Name = "lblHerbivorous";
			this.lblHerbivorous.Size = new System.Drawing.Size(58, 13);
			this.lblHerbivorous.TabIndex = 0;
			this.lblHerbivorous.Text = "Травоядні";
			// 
			// lblEmulatorConfiguration
			// 
			this.lblEmulatorConfiguration.AutoSize = true;
			this.lblEmulatorConfiguration.Location = new System.Drawing.Point(9, 21);
			this.lblEmulatorConfiguration.Name = "lblEmulatorConfiguration";
			this.lblEmulatorConfiguration.Size = new System.Drawing.Size(138, 13);
			this.lblEmulatorConfiguration.TabIndex = 3;
			this.lblEmulatorConfiguration.Text = "Налаштування емулятора";
			// 
			// btnApplyemulatorRules
			// 
			this.btnApplyemulatorRules.Location = new System.Drawing.Point(5, 305);
			this.btnApplyemulatorRules.Name = "btnApplyemulatorRules";
			this.btnApplyemulatorRules.Size = new System.Drawing.Size(150, 23);
			this.btnApplyemulatorRules.TabIndex = 2;
			this.btnApplyemulatorRules.Text = "Застосувати";
			this.btnApplyemulatorRules.UseVisualStyleBackColor = true;
			this.btnApplyemulatorRules.Click += new System.EventHandler(this.ApplyTuning);
			// 
			// gbLifeDuration
			// 
			this.gbLifeDuration.Controls.Add(this.numericUpDown3);
			this.gbLifeDuration.Controls.Add(this.label6);
			this.gbLifeDuration.Controls.Add(this.numericUpDown4);
			this.gbLifeDuration.Controls.Add(this.label7);
			this.gbLifeDuration.Location = new System.Drawing.Point(5, 145);
			this.gbLifeDuration.Name = "gbLifeDuration";
			this.gbLifeDuration.Size = new System.Drawing.Size(150, 82);
			this.gbLifeDuration.TabIndex = 1;
			this.gbLifeDuration.TabStop = false;
			this.gbLifeDuration.Text = "Час життя";
			// 
			// numericUpDown3
			// 
			this.numericUpDown3.Location = new System.Drawing.Point(74, 49);
			this.numericUpDown3.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.numericUpDown3.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDown3.Name = "numericUpDown3";
			this.numericUpDown3.Size = new System.Drawing.Size(71, 20);
			this.numericUpDown3.TabIndex = 7;
			this.numericUpDown3.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(6, 51);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(46, 13);
			this.label6.TabIndex = 6;
			this.label6.Text = "Хижаки";
			// 
			// numericUpDown4
			// 
			this.numericUpDown4.Location = new System.Drawing.Point(74, 20);
			this.numericUpDown4.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.numericUpDown4.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDown4.Name = "numericUpDown4";
			this.numericUpDown4.Size = new System.Drawing.Size(71, 20);
			this.numericUpDown4.TabIndex = 5;
			this.numericUpDown4.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(5, 20);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(58, 13);
			this.label7.TabIndex = 4;
			this.label7.Text = "Травоядні";
			// 
			// tabControl2
			// 
			this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl2.Controls.Add(this.tpDemography);
			this.tabControl2.Location = new System.Drawing.Point(941, 52);
			this.tabControl2.Multiline = true;
			this.tabControl2.Name = "tabControl2";
			this.tabControl2.SelectedIndex = 0;
			this.tabControl2.Size = new System.Drawing.Size(160, 726);
			this.tabControl2.TabIndex = 20;
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbsaveResultsToFile,
            this.toolStripSeparator9,
            this.tsbSelectRules,
            this.toolStripSeparator5,
            this.tsbSetstartPoint,
            this.toolStripSeparator4,
            this.tsbClearSelectedPlane,
            this.toolStripSeparator3,
            this.tsbDoTransition,
            this.toolStripTextBox2,
            this.toolStripSeparator8});
			this.toolStrip1.Location = new System.Drawing.Point(0, 24);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(1107, 25);
			this.toolStrip1.TabIndex = 21;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// tsbsaveResultsToFile
			// 
			this.tsbsaveResultsToFile.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbsaveResultsToFile.Name = "tsbsaveResultsToFile";
			this.tsbsaveResultsToFile.Size = new System.Drawing.Size(61, 22);
			this.tsbsaveResultsToFile.Text = "Зберегти";
			this.tsbsaveResultsToFile.ToolTipText = "Зберегти результати до файлу";
			this.tsbsaveResultsToFile.Click += new System.EventHandler(this.Save);
			// 
			// toolStripSeparator9
			// 
			this.toolStripSeparator9.Name = "toolStripSeparator9";
			this.toolStripSeparator9.Size = new System.Drawing.Size(6, 25);
			// 
			// tsbSelectRules
			// 
			this.tsbSelectRules.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbSelectRules.Name = "tsbSelectRules";
			this.tsbSelectRules.Size = new System.Drawing.Size(101, 22);
			this.tsbSelectRules.Text = "Обрати правила";
			this.tsbSelectRules.ToolTipText = "Обрати варіант правил розвитку";
			this.tsbSelectRules.Click += new System.EventHandler(this.ChooseRules1);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
			// 
			// tsbSetstartPoint
			// 
			this.tsbSetstartPoint.Enabled = false;
			this.tsbSetstartPoint.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbSetstartPoint.Name = "tsbSetstartPoint";
			this.tsbSetstartPoint.Size = new System.Drawing.Size(148, 22);
			this.tsbSetstartPoint.Text = "Встановити точку відліку";
			this.tsbSetstartPoint.ToolTipText = "Встановити точку відліку для побудови графіка";
			this.tsbSetstartPoint.Click += new System.EventHandler(this.SetAPoint);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
			// 
			// tsbClearSelectedPlane
			// 
			this.tsbClearSelectedPlane.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbClearSelectedPlane.Name = "tsbClearSelectedPlane";
			this.tsbClearSelectedPlane.Size = new System.Drawing.Size(64, 22);
			this.tsbClearSelectedPlane.Text = "Очистити";
			this.tsbClearSelectedPlane.ToolTipText = "Очистити обрану площину";
			this.tsbClearSelectedPlane.Click += new System.EventHandler(this.CleanCurrentPlane);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
			// 
			// tsbDoTransition
			// 
			this.tsbDoTransition.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbDoTransition.Name = "tsbDoTransition";
			this.tsbDoTransition.Size = new System.Drawing.Size(107, 22);
			this.tsbDoTransition.Text = "Виконати перехід";
			this.tsbDoTransition.ToolTipText = "Виконати перехід у фоновому режимі на задану кількість поколінь";
			this.tsbDoTransition.Click += new System.EventHandler(this.ExecuteTransition);
			// 
			// toolStripTextBox2
			// 
			this.toolStripTextBox2.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.toolStripTextBox2.MaxLength = 6;
			this.toolStripTextBox2.Name = "toolStripTextBox2";
			this.toolStripTextBox2.Size = new System.Drawing.Size(100, 25);
			this.toolStripTextBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.acceptDown);
			// 
			// toolStripSeparator8
			// 
			this.toolStripSeparator8.Name = "toolStripSeparator8";
			this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
			// 
			// tmrMouseLocation
			// 
			this.tmrMouseLocation.Enabled = true;
			this.tmrMouseLocation.Interval = 50;
			this.tmrMouseLocation.Tick += new System.EventHandler(this.tmrMouseLocation_Tick);
			// 
			// CellFieldUI
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1107, 808);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.tabControl2);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.gbMessage);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.headMenu);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.MainMenuStrip = this.headMenu;
			this.MaximizeBox = false;
			this.MinimumSize = new System.Drawing.Size(688, 488);
			this.Name = "CellFieldUI";
			this.ShowIcon = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = " ";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CellFieldUI_FormClosing);
			this.Load += new System.EventHandler(this.CellFieldUI_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.gpbAutoTransitions.ResumeLayout(false);
			this.gpbAutoTransitions.PerformLayout();
			this.headMenu.ResumeLayout(false);
			this.headMenu.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.tbCellSize)).EndInit();
			this.gbCellSize.ResumeLayout(false);
			this.gbCellSize.PerformLayout();
			this.gbMessage.ResumeLayout(false);
			this.gbMessage.PerformLayout();
			this.gbFieldLocation.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tpMainControlBox.ResumeLayout(false);
			this.tpFieldOptions.ResumeLayout(false);
			this.gbPlanesToShow.ResumeLayout(false);
			this.gbPlanesToShow.PerformLayout();
			this.gbGenerateRandomPattern.ResumeLayout(false);
			this.groupBox6.ResumeLayout(false);
			this.gbSelectPlane.ResumeLayout(false);
			this.gbSelectPlane.PerformLayout();
			this.tpAnalytics.ResumeLayout(false);
			this.gbGraphs.ResumeLayout(false);
			this.tpDemography.ResumeLayout(false);
			this.plMatrixOptions.ResumeLayout(false);
			this.plMatrixOptions.PerformLayout();
			this.groupBox11.ResumeLayout(false);
			this.groupBox11.PerformLayout();
			this.gbPredatorsConf.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).EndInit();
			this.gbIntervalForBirth.ResumeLayout(false);
			this.gbIntervalForBirth.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			this.gbLifeDuration.ResumeLayout(false);
			this.gbLifeDuration.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
			this.tabControl2.ResumeLayout(false);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnGoToNextGeneration;
        private System.Windows.Forms.Timer TimerForAutoTransitions;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.GroupBox gpbAutoTransitions;
        private System.Windows.Forms.MenuStrip headMenu;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem camOptions;
        private System.Windows.Forms.ToolStripMenuItem tsmiHelpCategory;
        private System.Windows.Forms.ToolStripMenuItem tsmiViewHelp;
        private System.Windows.Forms.ToolStripMenuItem новоеПолеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьИзФайлаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьВФайлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.Button btnAccelerate;
        private System.Windows.Forms.Button btnSlowDown;
        private System.Windows.Forms.Button btnClearAllMatrices;
        private System.Windows.Forms.ToolStripMenuItem tsmiDefaultConfigurations;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TrackBar tbCellSize;
        private System.Windows.Forms.GroupBox gbCellSize;
        private System.Windows.Forms.GroupBox gbMessage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btmGbMessageOK;
        private System.Windows.Forms.ToolStripMenuItem tsmiAdditionalFieldOptions;
        private System.Windows.Forms.ToolStripMenuItem tsmiSetRules;
        private System.Windows.Forms.ToolStripMenuItem tsmiExec;
        private System.Windows.Forms.ToolStripMenuItem перейтиНаХХХПоколіньToolStripMenuItem;
        private System.Windows.Forms.Timer _timerForAutoGeneration;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.GroupBox gbFieldLocation;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpMainControlBox;
        private System.Windows.Forms.TabPage tpFieldOptions;
        private System.Windows.Forms.GroupBox gbSelectPlane;
        private System.Windows.Forms.Button btnSwapMatrices;
        private System.Windows.Forms.RadioButton rbPlane1;
        private System.Windows.Forms.RadioButton rbPlane0;
        private System.Windows.Forms.RadioButton rbPlane3;
        private System.Windows.Forms.RadioButton rbPlane2;
        private System.Windows.Forms.TabPage tpAnalytics;
        private System.Windows.Forms.Button btnShowGraph;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RadioButton rbPlane8;
        private System.Windows.Forms.Button btnClearSelectedPlane;
        private System.Windows.Forms.TabPage tpDemography;
        private System.Windows.Forms.Label lblEmulatorConfiguration;
        private System.Windows.Forms.GroupBox gbIntervalForBirth;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label lblPredators;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label lblHerbivorous;
        private System.Windows.Forms.GroupBox gbLifeDuration;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDown4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnApplyemulatorRules;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.ToolStripStatusLabel tsslTransitionStatus;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.GroupBox gbPredatorsConf;
        private System.Windows.Forms.NumericUpDown numericUpDown5;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.Button btnStartPoint;
        private System.Windows.Forms.GroupBox gbGraphs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbClearSelectedPlane;
        private System.Windows.Forms.ToolStripButton tsbsaveResultsToFile;
        private System.Windows.Forms.ToolStripButton tsbSelectRules;
        private System.Windows.Forms.ToolStripButton tsbSetstartPoint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiCreateGraph;
        private System.Windows.Forms.ToolStripMenuItem tsmiBuildHistogram;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbDoTransition;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.Button btnMakeGistogramma;
        private System.Windows.Forms.ToolStripMenuItem tsmiAboutApp;
        private System.Windows.Forms.ToolStripMenuItem tsmiCheckNewVersion;
        private System.Windows.Forms.GroupBox gbPlanesToShow;
        private System.Windows.Forms.CheckBox cbxMatrix4;
        private System.Windows.Forms.CheckBox cbxMatrix3;
        private System.Windows.Forms.CheckBox cbxMatrix2;
        private System.Windows.Forms.CheckBox cbxMatrix1;
        private System.Windows.Forms.CheckBox cbxMatrix0;
        private System.Windows.Forms.CheckBox cbxMatrix10;
        private System.Windows.Forms.CheckBox cbxMatrix9;
        private System.Windows.Forms.CheckBox cbxMatrix8;
        private System.Windows.Forms.CheckBox cbxMatrix7;
        private System.Windows.Forms.CheckBox cbxMatrix6;
        private System.Windows.Forms.CheckBox cbxMatrix5;
        private System.Windows.Forms.Button btnDisplayMatrContent;
        private System.Windows.Forms.GroupBox gbGenerateRandomPattern;
        private System.Windows.Forms.Button btnStartGenerateRandomPattern;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ComboBox cbxCellSize;
        private System.Windows.Forms.Panel plMatrixOptions;
        private System.Windows.Forms.Label lblCellValue;
        private System.Windows.Forms.TextBox txbCellValue;
        private System.Windows.Forms.Button btnSetCell;
        private System.Windows.Forms.Button btnGetCell;
        private System.Windows.Forms.ComboBox cbxLayer;
        private System.Windows.Forms.TextBox txbYAxes;
        private System.Windows.Forms.TextBox txbXAxes;
        private System.Windows.Forms.Label lblCellValDesc;
        private System.Windows.Forms.Label lblMouseCurrentPosition;
        private System.Windows.Forms.Timer tmrMouseLocation;
    }
}

