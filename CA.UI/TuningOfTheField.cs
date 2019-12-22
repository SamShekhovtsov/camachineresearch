using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace CA.UI
{
    public partial class TuningOfTheField : Form
    {
        public int y=220, r, g, b, i = 10;
        public bool anime=false;
        public Random Ran=new Random();
        string MainText = Localization.Locales.Resources.TuningOfTheField_MainText;

        public TuningOfTheField()
        {
            InitializeComponent();
        }

        private void abolition(object sender, EventArgs e)
        {
            Close();
        }

        private void anUserAgrees(object sender, EventArgs e)
        {
          Close();  
        }

        public FieldOptions retStruct()
        {
            //!!! TODO SAM cell size have to be specified here!!!
            return new FieldOptions(chbDontShowInnerBorders.Checked, int.Parse(textBox1.Text)); 
        }

        public void set(int c, bool b,int P)
        {
            chbDontShowInnerBorders.Checked = b;
            numericUpDown1.Value = c;
            textBox1.Text = P.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (y ==-60)
                y = pictureBox1.Height-5;
            if (i == 2)
            {
                r = Ran.Next(10, 255);
                g = Ran.Next(10, 255);
                b = Ran.Next(10, 255);
            }

            if(i==250||i==2)anime=!anime;
            if (anime)
            {
                i += 2;
            }
            else
            {
                i -= 2;
            }
            pictureBox1.Invalidate();
            y -= 1;
       }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(i, r,g,b)),0,0,this.Width,this.Height);
            e.Graphics.DrawString(MainText, new Font("Times new roman", 14), Brushes.Red, 20, y);
            e.Graphics.FillRectangle(new LinearGradientBrush(new Rectangle(0, 0, pictureBox1.Width, 5),Color.White , Color.Gray, LinearGradientMode.Vertical), 0, 0, pictureBox1.Width, 5);
            e.Graphics.FillPolygon(new LinearGradientBrush(new Rectangle(0, 0, 5, pictureBox1.Height), Color.White, Color.Gray, LinearGradientMode.Horizontal), new Point[]{
            new Point( 0, 0),new Point(5,5),new Point(5, pictureBox1.Height),new Point(0,pictureBox1.Height),new Point(0,0)});
            e.Graphics.FillPolygon(new LinearGradientBrush(new Rectangle(pictureBox1.Width - 5, 0, 5, pictureBox1.Height), Color.Silver, Color.Black, LinearGradientMode.Horizontal), new Point[]{
            new Point( pictureBox1.Width-5, 5),new Point(pictureBox1.Width,0),new Point(pictureBox1.Width, pictureBox1.Height),new Point(pictureBox1.Width-5,pictureBox1.Height-5),new Point(pictureBox1.Width-5, 5)});
            e.Graphics.DrawLine(new Pen(Brushes.White, 1), pictureBox1.Width-5, 5, pictureBox1.Width-5, pictureBox1.Height-5);
            //    e.Graphics.DrawLine(new Pen(Brushes.Black, 1), pictureBox1.Width, 0, pictureBox1.Width, pictureBox1.Height);
            e.Graphics.FillPolygon(new LinearGradientBrush(new Rectangle(0, pictureBox1.Height - 5, pictureBox1.Width, 5), Color.Silver, Color.Black, LinearGradientMode.Vertical), new Point[]{
            new Point( 5, pictureBox1.Height-5),new Point(pictureBox1.Width-5,pictureBox1.Height-5),new Point(pictureBox1.Width, pictureBox1.Height),new Point(0,pictureBox1.Height),new Point( 5, pictureBox1.Height-5)});
          //  e.Graphics.DrawLine(new Pen(Brushes.Black, 1), 0, 0, 0, pictureBox1.Height);
        }

        private void TuningOfTheField_Load(object sender, EventArgs e)
        {
            Localize();
        }

        private void Localize()
        {
            this.btnAgree.Text = Localization.Locales.Resources.TuningOfTheField_btnAgree_Text;
            this.chbDontShowInnerBorders.Text = Localization.Locales.Resources.TuningOfTheField_chbDontShowInnerBorders_Text;
            this.gbOptions.Text = Localization.Locales.Resources.TuningOfTheField_gbOptions_Text;
            this.lblFieldSize.Text = Localization.Locales.Resources.TuningOfTheField_lblFieldSize_Text;
            this.lblCellSize.Text = Localization.Locales.Resources.TuningOfTheField_lblCellSize_Text;
            this.btnCancel.Text = Localization.Locales.Resources.TuningOfTheField_btnCancel_Text;
            this.Text = Localization.Locales.Resources.TuningOfTheField_Text;
        }
    }
}
