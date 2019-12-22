using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
namespace System.Drawing.Pie3D
{
    class Slice3D:IComparable<Slice3D>
    {
        public Brush brush;
        public Pen pen;
        public float height;
        public int ID;
        float delta;
        public float Delta
        {
            get { return delta; }
            set 
            { 
                delta = value;
                if (isPartial) otherPart.delta = value;
            }
        }
        public Slice3D(float startAngle, float sweepAngle, RectangleF rect,
            Brush br, Pen pn, int id, float delta)
        {
            Constructor(rect, br, pn, id, delta, 50, false, false);
            Resize(startAngle, sweepAngle);
        }
        public Slice3D(float startAngle, float sweepAngle, RectangleF rect,
            Brush br, Pen pn, int id, float delta, bool isFst)
        {
            Constructor(rect, br, pn, id, delta, 50, true, isFst);
            Resize(startAngle, sweepAngle);
        }
        public Slice3D(float startAngle, float sweepAngle, RectangleF rect,
            Brush br, Pen pn, int id, float delta, Slice3D otherPrt, bool isFst)
        {
            Constructor(rect, br, pn, id, delta, 50, true,isFst);
            otherPart = otherPrt;
            Resize(startAngle, sweepAngle);
        }
        void Constructor(RectangleF rect, Brush br, Pen pn, int id, 
            float delt, float height, bool isPrt, bool isFst)
        {
            BaseRect = rect;
            delta = delt;
            brush = br;
            pen = pn;
            this.height=height;
            isPartial = isPrt;
            isFirst = isFst;
            ID = id; 
        }
        public void Resize(float startA, float sweepA)
        {
            float x, y;
            float dx, dy;
            startAngle = TransformAngle(startA, BaseRect, out x, out y);
            startPoint.X = x; startPoint.Y = y;
            sweepAngle = TransformAngle(sweepA + startA, BaseRect, out x, out y) - startAngle;
            if (this.sweepAngle < 0 ) this.sweepAngle += 360;
            sweepPoint.X = x; sweepPoint.Y = y;
            RealRect = BaseRect; 
            if (isPartial)
            {
                if (isFirst)
                {
                    dx = (float)(delta * Math.Cos((startAngle+sweepAngle) * TO_RAD));
                    dy = (float)(delta / (BaseRect.Width / BaseRect.Height)
                        * Math.Sin((startAngle+sweepAngle) * TO_RAD));
                }
                else
                {
                    dx = (float)(delta * Math.Cos((startAngle) * TO_RAD));
                    dy = (float)(delta / (BaseRect.Width / BaseRect.Height)
                        * Math.Sin((startAngle) * TO_RAD));
                }
            }
            else 
            {
                dx = (float)(delta * Math.Cos((startAngle + sweepAngle / 2) * TO_RAD));
                dy = (float)(delta / (BaseRect.Width / BaseRect.Height)
                    * Math.Sin((startAngle + sweepAngle / 2) * TO_RAD));
            }
            RealRect.X   += dx;   RealRect.Y   += dy;
            sweepPoint.X += dx;   sweepPoint.Y += dy;
            startPoint.X += dx;   startPoint.Y += dy;
            centerPoint.X = RealRect.Left + RealRect.Width / 2;
            centerPoint.Y = RealRect.Top + RealRect.Height / 2;
        }
        public bool Contein(PointF coord)
        {
            if(reg!=null)return reg.IsVisible(coord);
            return false;
        }
        public void Draw(Graphics g)
        {
            g.DrawArc(pen, RealRect, startAngle, sweepAngle);
            g.DrawArc(pen, RealRect.Left, RealRect.Top - height,
                RealRect.Width, RealRect.Height, startAngle, sweepAngle);
            if(!isPartial || isFirst)
                g.DrawPolygon(pen, new PointF[]{
                    new PointF(centerPoint.X, centerPoint.Y),
                    new PointF(centerPoint.X, centerPoint.Y-height),
                    new PointF(startPoint.X,startPoint.Y-height),
                    startPoint}); 
            if (!isPartial || !isFirst)
            {
                g.DrawLine(pen, new PointF(centerPoint.X, centerPoint.Y), sweepPoint);
                g.DrawLine(pen, new PointF(centerPoint.X, centerPoint.Y - height),
                    new PointF(sweepPoint.X, sweepPoint.Y - height));
                g.DrawLine(pen, sweepPoint, new PointF(sweepPoint.X, sweepPoint.Y - height));
            }
        }
        public void Fill(Graphics g)
        {
            GraphicsPath path = new GraphicsPath();
            float cwSweep = sweepAngle/2, ccwSweep = sweepAngle/2, start = startAngle + sweepAngle/2;
            if (startAngle + sweepAngle > 360 ) 
            {                         
                cwSweep = startAngle + sweepAngle - 360; ccwSweep = sweepAngle - cwSweep;                 
                start = 0;
            }
            else if (startAngle + sweepAngle > 180 && startAngle < 180)
            {
                cwSweep = startAngle + sweepAngle - 180; ccwSweep = sweepAngle - cwSweep;
                start = 180;
            }

            path.AddArc(RealRect.Left, RealRect.Top, RealRect.Width, RealRect.Height, start, cwSweep);
            path.AddArc(RealRect.Left, RealRect.Top - height, RealRect.Width, RealRect.Height, 
                start+cwSweep, -cwSweep);
            path.CloseFigure(); g.FillPath(brush, path); path = new GraphicsPath();

            path.AddArc(RealRect.Left, RealRect.Top, RealRect.Width, RealRect.Height, start, -ccwSweep);
            path.AddArc(RealRect.Left, RealRect.Top - height, RealRect.Width, RealRect.Height,
                start - ccwSweep, ccwSweep);
            path.CloseFigure(); 
            g.FillPath(brush, path);
            reg = new Region(path);

            g.FillPie(brush, RealRect.Left, RealRect.Top, RealRect.Width, RealRect.Height, startAngle, sweepAngle);
            g.FillPie(brush, RealRect.Left, RealRect.Top - height,
                RealRect.Width, RealRect.Height, startAngle, sweepAngle);
            if(!isPartial || !isFirst)
               g.FillPolygon(brush, new PointF[]{
                    new PointF(centerPoint.X, centerPoint.Y),
                    new PointF(centerPoint.X, centerPoint.Y-height),
                    new PointF(sweepPoint.X,sweepPoint.Y-height),
                    sweepPoint});
            if(!isPartial || isFirst)
                g.FillPolygon(brush, new PointF[]{
                    new PointF(centerPoint.X, centerPoint.Y),
                    new PointF(centerPoint.X, centerPoint.Y-height),
                    new PointF(startPoint.X, startPoint.Y-height),
                    startPoint});     
        }
        public int CompareTo(Slice3D other)
        {
            return (int)(TransformAngleForSort((this.startAngle) + (this.sweepAngle) / 2) -
                TransformAngleForSort((other.startAngle) + (other.sweepAngle) / 2)); 
        }
        public Slice3D OtherPart
        {
            set { otherPart = value; }
        }
        static float TransformAngleForSort(float angle)
        {
            if (angle > 270) return angle - 270;
            else if (angle < 90) return angle + 90;
            else return 270 - angle;
        }
        static float TransformAngle(float angle, RectangleF rect,
            out float x, out float y)
        {
            x = (float)(Math.Cos(angle * TO_RAD) * rect.Width / 2);
            y = (float)(Math.Sin(angle * TO_RAD) * rect.Height / 2);
            float result = (float)(Math.Atan2(y, x) * FROM_RAD);
            x = rect.Left + rect.Width / 2 + x;
            y = rect.Top + rect.Height / 2 + y;
            if (result < 0)
                return result + 360;
            return result;
        }
        
        float startAngle, sweepAngle;
        RectangleF RealRect;
        PointF startPoint, sweepPoint, centerPoint;
        bool isPartial, isFirst;
        Region reg;
        Slice3D otherPart;

        static RectangleF BaseRect;
        static double TO_RAD = Math.PI / 180;
        static double FROM_RAD = 180 / Math.PI;
    }
    public class Pie3D
    {
        public Pie3D(long[] n, Brush[] brushes, Pen[] pens, RectangleF rect)
        {
            N = n.Length;
            if (pens == null) 
            {
                pens = new Pen[N];
                for (int i = 0; i < N; i++)
                {
                    pens[i] = new Pen(brushes[i]);
                    pens[i].Color = Color.FromArgb(200, pens[i].Color);
                }
            }
            if (brushes.Length != N || pens.Length != N)
                throw new ArgumentOutOfRangeException(" colors or pens ");
            this.rectangle = rect;
            this.brushes = brushes;
            this.pens = pens;
            Resize(n);  
        }
        public void Resize(long[] n)
        {
            if(n.Length!=N) throw new ArgumentOutOfRangeException(" n ");
            float sum = 0;
            float start = alfa;
            float delt=10;
            slices.Clear();
            foreach (int i in n)
                sum += i;
            float sweep;
            int id = 0;
            Slice3D temp;
            for (int i = 0; i < n.Length; i++)
            {
                if (i == selected) delt = delta;
                else delt = 3;
                sweep = 360 * (n[i] / sum);
                if (sweep > 180)
                {
                    slices.Add(new Slice3D(start, sweep / 2, rectangle, brushes[i],
                        pens[i], id, delt,true));
                    temp = slices[i];
                    slices.Add(new Slice3D(start + sweep / 2, sweep / 2, rectangle,
                        brushes[i], pens[i], id++, delt, temp, false));
                    temp.OtherPart = slices[i + 1];
                }
                else
                {
                    temp = new Slice3D(start, sweep, rectangle, brushes[i], pens[i], id++, delt);
                    slices.Add(temp);
                }
                start += sweep;
            }
            slices.Sort();
            numbs = n;
        }
        public void Draw(Graphics g)
        {
            foreach(Slice3D s in slices)s.Draw(g);
        }
        public void Fill(Graphics g) 
        {
            foreach (Slice3D s in slices)s.Fill(g);
        }
        public void FillAndDraw(Graphics g)
        {
            foreach (Slice3D s in slices) { s.Fill(g); s.Draw(g); }
        }
        public bool mouseHower(PointF cursor)
        {
            foreach (Slice3D s in slices)
                if (s.Contein(cursor))
                {
                    if (selected != s.ID)
                    {
                        selected = s.ID;
                        Resize(numbs);
                        return true;
                    }
                }
            return false;
        }
        public void Spin(float a)
        {
            this.alfa += a;
            this.Resize(numbs);
        }
        public float Height
        {
            get { return slices[0].height; }
            set
            {
                foreach (Slice3D s in slices)
                   s.height = value; 
            }
        }
        readonly int N;
        long[] numbs;
        List<Slice3D> slices = new List<Slice3D>();
        long selected;
        Brush[] brushes;
        Pen[] pens;
        float delta=50;
        float alfa=0;
        RectangleF rectangle;
    }
}
