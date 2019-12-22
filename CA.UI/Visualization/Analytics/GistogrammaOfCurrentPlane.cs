using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CA.UI
{
    public partial class GistogrammaOfCurrentPlane : Form
    {
        public int rozm = 400;
        public Bitmap b;
        public string str = "";
        public GistogrammaOfCurrentPlane()
        {
            InitializeComponent();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.AliceBlue , 0, 0, rozm,rozm);
            e.Graphics.DrawImage(b,0,0);
        }

        private void Gistogramma1_Load(object sender, EventArgs e)
        {
            pictureBox1.Height=rozm;
            pictureBox1.Width=rozm;
            label1.Text += str;
        }

        private void CloseForm(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}
