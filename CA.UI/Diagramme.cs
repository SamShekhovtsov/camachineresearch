using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Pie3D;

namespace CA.UI
{
    public partial class Diagramme : Form
    {
        Pie3D pie;
        List<long>[] listOfLiveCell;
        int currAmount;
        float koofForGoriz, koofForVert = 20;
        public Diagramme(List<long>[] dem)
        {
            try
            {
            listOfLiveCell = dem;
            InitializeComponent();
            pie = new Pie3D(new long[] { (listOfLiveCell[0][0]>0) ? listOfLiveCell[0][0]:100, 
                (listOfLiveCell[1][0]>0)?listOfLiveCell[1][0]: 100},
                new Brush[]{ new SolidBrush(Color.FromArgb(120,Color.Blue)), 
                    new SolidBrush(Color.FromArgb(120,Color.Red))}, null,
                new RectangleF(60, 40, pictureBox2.Width - 70, pictureBox2.Height - 80));
            pie.Height = 30;
            pictureBox2.Invalidate();
            trackBar1.Maximum = dem[0].Count-20;
            koofForGoriz = (listOfLiveCell[0].Count - pictureBox1.Width) / (float)trackBar1.Maximum; 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
            if ((int)numericUpDown1.Value < trackBar1.Maximum)
                currAmount = (int)numericUpDown1.Value;
                if (listOfLiveCell[0][currAmount] > 0 && listOfLiveCell[1][currAmount] > 0)
                    currAmount = currAmount;
                List<long> l = new List<long>();
                foreach (List<long> ll in listOfLiveCell)
                    l.Add((ll[currAmount] > 0) ? ll[currAmount] : 100);
                pie.Resize(l.ToArray());
                trackBar1.Value = currAmount;
                pictureBox1.Invalidate();
                pictureBox2.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                List<PointF> list0 = new List<PointF>();
                List<PointF> list1 = new List<PointF>();
                int start = (int)(koofForGoriz * currAmount);
                e.Graphics.DrawLine(new Pen(Brushes.Black, 4), 0, 0, 0, pictureBox1.Height);
                e.Graphics.DrawLine(new Pen(Brushes.Black, 4), 0, pictureBox1.Height,
                    pictureBox1.Width, pictureBox1.Height);
                if (koofForGoriz > 0)
                {
                    int y_null = pictureBox1.Height;
                    int fin = start + pictureBox1.Width;
                    for (int i = 0, j = start; j < fin; i++, j++)
                    {
                        list0.Add(new PointF(i, y_null - listOfLiveCell[0][j] / koofForVert));
                        list1.Add(new PointF(i, y_null - listOfLiveCell[1][j] / koofForVert));
                    }
                    for (int i = 50; i < pictureBox1.Width; i += 50)
                    {
                        e.Graphics.DrawString((start + i).ToString(), new Font("Microsoft Sans Serif", 8),
                            Brushes.DarkGreen, i, pictureBox1.Height - 12);
                    }
                }
                else
                {
                    float k_x = pictureBox1.Width / listOfLiveCell[0].Count;
                    for (int i = 0; i < listOfLiveCell[0].Count; i++)
                    {
                        list0.Add(new PointF(i * k_x, listOfLiveCell[0][i] / koofForVert));
                        list1.Add(new PointF(i * k_x, listOfLiveCell[1][i] / koofForVert));
                    }
                    for (int i = 50; i < pictureBox1.Width; i += 50)
                    {
                        e.Graphics.DrawString((i/k_x).ToString(), new Font("Microsoft Sans Serif", 8),
                            Brushes.DarkGreen, i, pictureBox1.Height - 12);
                    }
                }
                e.Graphics.DrawLines(Pens.Blue, list0.ToArray());
                e.Graphics.DrawLines(Pens.Red, list1.ToArray());
                for (int i = 50; i < pictureBox1.Height; i += 50)
                {
                    e.Graphics.DrawString((i*koofForVert).ToString(), new Font("Microsoft Sans Serif", 8),
                        Brushes.DarkGreen, 0, pictureBox1.Height - i);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
            currAmount = trackBar1.Value;
            List<long> l = new List<long>();
            foreach (List<long> ll in listOfLiveCell)
                if (currAmount < ll.Count)
                l.Add((ll[currAmount]>0)?ll[currAmount]:100);
            pie.Resize(l.ToArray());
            numericUpDown1.Value = currAmount;
            pictureBox1.Invalidate();
            pictureBox2.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                pie.FillAndDraw(e.Graphics);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            koofForVert = (float)numericUpDown2.Value;
            pictureBox1.Invalidate();
        }
    }
}
