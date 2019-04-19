using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public partial class Form1 : Form
    {
        Bitmap btm;
        Pen pen = new Pen(Color.Red, 4);
        Graphics g;
        bool mouseclicked = false;
        Point prev;
        Point cur;
        

        public enum tool
        {
            pen,
            rectangle,
            ellipse
        }

        public tool pencil = tool.pen;

        public Form1()
        {
            InitializeComponent();
            this.BackColor = Color.White;
        }

        private void Form1_Load(object sender, EventArgs e)
        { 
            
            btm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(btm);
            pictureBox1.Image = btm;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseclicked = true;
            prev = e.Location;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseclicked = false;
            if (pencil == tool.rectangle) DrawRectangle(g);
            else if (pencil == tool.ellipse) DrawEllipse(g);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseclicked)
            {
                if(pencil == tool.pen)
                {
                    cur = e.Location;
                    g.DrawLine(pen, prev,cur);
                    prev = cur;
                }
                else if(pencil == tool.rectangle)
                {
                    cur = e.Location;
                }

                else
                {
                    cur = e.Location;
                }

                pictureBox1.Refresh();
            }  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pen.Color = Color.Red;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pen.Color = Color.Blue;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pencil = tool.rectangle;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pencil = tool.ellipse;
        }

        public void DrawEllipse(Graphics g)
        {
            int minx = Math.Min(prev.X, cur.X);
            int maxx = Math.Max(prev.X, cur.X);
            int miny = Math.Min(prev.Y, cur.Y);
            int maxy = Math.Max(prev.Y, cur.Y);
            g.DrawEllipse(pen, minx, miny, maxx - minx, maxy - miny);
        }

        public void DrawRectangle(Graphics g)
        {
            int minx = Math.Min(prev.X, cur.X);
            int maxx = Math.Max(prev.X, cur.X);
            int miny = Math.Min(prev.Y, cur.Y);
            int maxy = Math.Max(prev.Y, cur.Y);
            g.DrawRectangle(pen, minx, miny, maxx - minx, maxy - miny);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pencil = tool.pen;
            pen.Color = Color.Black;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (pencil == tool.rectangle)
                DrawRectangle(e.Graphics);
            else if (pencil == tool.ellipse)
                DrawEllipse(e.Graphics);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            pen.Color = Color.Black;
        }
    }
}
