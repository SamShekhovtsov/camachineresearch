namespace CA.UI
{
    partial class GistogrammaOfCurrentPlane
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.lblOfActive = new System.Windows.Forms.Label();
            this.lblCells = new System.Windows.Forms.Label();
            this.btnOkay = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(83, 92);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(400, 400);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = Localization.Locales.Resources.GistogrammaOfCurrentPlane_lblGistogrammaView_Text;
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(12, 253);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(56, 13);
            this.lblCount.TabIndex = 2;
            this.lblCount.Text = Localization.Locales.Resources.GistogrammaOfCurrentPlane_lblCount_Text;
            // 
            // lblOfActive
            // 
            this.lblOfActive.AutoSize = true;
            this.lblOfActive.Location = new System.Drawing.Point(12, 266);
            this.lblOfActive.Name = "lblOfActive";
            this.lblOfActive.Size = new System.Drawing.Size(53, 13);
            this.lblOfActive.TabIndex = 3;
            this.lblOfActive.Text = Localization.Locales.Resources.GistogrammaOfCurrentPlane_lblOfActive_Text;
            // 
            // lblCells
            // 
            this.lblCells.AutoSize = true;
            this.lblCells.Location = new System.Drawing.Point(12, 279);
            this.lblCells.Name = "lblCells";
            this.lblCells.Size = new System.Drawing.Size(38, 13);
            this.lblCells.TabIndex = 4;
            this.lblCells.Text = Localization.Locales.Resources.GistogrammaOfCurrentPlane_lblCells_Text;
            // 
            // btnOkay
            // 
            this.btnOkay.Location = new System.Drawing.Point(13, 469);
            this.btnOkay.Name = "btnOkay";
            this.btnOkay.Size = new System.Drawing.Size(52, 23);
            this.btnOkay.TabIndex = 5;
            this.btnOkay.Text = Localization.Locales.Resources.GistogrammaOfCurrentPlane_btnOkay_Text;
            this.btnOkay.UseVisualStyleBackColor = true;
            this.btnOkay.Click += new System.EventHandler(this.CloseForm);
            // 
            // Gistogramma1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 504);
            this.Controls.Add(this.btnOkay);
            this.Controls.Add(this.lblCells);
            this.Controls.Add(this.lblOfActive);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.ForeColor = System.Drawing.Color.DarkRed;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "GistogrammaOfCurrentPlane";
            this.Text = Localization.Locales.Resources.GistogrammaOfCurrentPlane_Text;
            this.Load += new System.EventHandler(this.Gistogramma1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label lblOfActive;
        private System.Windows.Forms.Label lblCells;
        private System.Windows.Forms.Button btnOkay;
    }
}