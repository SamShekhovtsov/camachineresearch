namespace CA.UI
{
    partial class SelectRules
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOkay = new System.Windows.Forms.Button();
            this.gbSelectRules = new System.Windows.Forms.GroupBox();
            this.lblBirthRules = new System.Windows.Forms.Label();
            this.txbForBirth = new System.Windows.Forms.TextBox();
            this.lblSurvivalRules = new System.Windows.Forms.Label();
            this.txbForSurvival = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.gbSelectRules.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOkay
            // 
            this.btnOkay.Location = new System.Drawing.Point(247, 201);
            this.btnOkay.Name = "btnOkay";
            this.btnOkay.Size = new System.Drawing.Size(75, 23);
            this.btnOkay.TabIndex = 10;
            this.btnOkay.UseVisualStyleBackColor = true;
            this.btnOkay.Click += new System.EventHandler(this.UserAgree);
            // 
            // gbSelectRules
            // 
            this.gbSelectRules.Controls.Add(this.lblBirthRules);
            this.gbSelectRules.Controls.Add(this.txbForBirth);
            this.gbSelectRules.Controls.Add(this.lblSurvivalRules);
            this.gbSelectRules.Controls.Add(this.txbForSurvival);
            this.gbSelectRules.Controls.Add(this.textBox1);
            this.gbSelectRules.Controls.Add(this.comboBox1);
            this.gbSelectRules.Location = new System.Drawing.Point(13, 28);
            this.gbSelectRules.Name = "gbSelectRules";
            this.gbSelectRules.Size = new System.Drawing.Size(547, 157);
            this.gbSelectRules.TabIndex = 14;
            this.gbSelectRules.TabStop = false;
            // 
            // lblBirthRules
            // 
            this.lblBirthRules.AutoSize = true;
            this.lblBirthRules.Location = new System.Drawing.Point(299, 90);
            this.lblBirthRules.Name = "lblBirthRules";
            this.lblBirthRules.Size = new System.Drawing.Size(0, 13);
            this.lblBirthRules.TabIndex = 1;
            // 
            // txbForBirth
            // 
            this.txbForBirth.Location = new System.Drawing.Point(296, 112);
            this.txbForBirth.Name = "txbForBirth";
            this.txbForBirth.Size = new System.Drawing.Size(149, 20);
            this.txbForBirth.TabIndex = 20;
            // 
            // lblSurvivalRules
            // 
            this.lblSurvivalRules.AutoSize = true;
            this.lblSurvivalRules.Location = new System.Drawing.Point(299, 24);
            this.lblSurvivalRules.Name = "lblSurvivalRules";
            this.lblSurvivalRules.Size = new System.Drawing.Size(0, 13);
            this.lblSurvivalRules.TabIndex = 7;
            // 
            // txbForSurvival
            // 
            this.txbForSurvival.Location = new System.Drawing.Point(296, 46);
            this.txbForSurvival.Name = "txbForSurvival";
            this.txbForSurvival.Size = new System.Drawing.Size(149, 20);
            this.txbForSurvival.TabIndex = 16;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.LightGray;
            this.textBox1.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.textBox1.Location = new System.Drawing.Point(6, 46);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(256, 105);
            this.textBox1.TabIndex = 15;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(6, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(256, 21);
            this.comboBox1.TabIndex = 7;
            // 
            // SelectRules
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 232);
            this.ControlBox = false;
            this.Controls.Add(this.gbSelectRules);
            this.Controls.Add(this.btnOkay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SelectRules";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.SelectRules_Load);
            this.gbSelectRules.ResumeLayout(false);
            this.gbSelectRules.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOkay;
        private System.Windows.Forms.GroupBox gbSelectRules;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label lblBirthRules;
        private System.Windows.Forms.TextBox txbForSurvival;
        private System.Windows.Forms.TextBox txbForBirth;
        private System.Windows.Forms.Label lblSurvivalRules;
    }
}