using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrtanjePravokutnika
{
    public partial class Form1 : Form
    {
        private Point p1 = new Point(-1, -1);
        private Point p2 = new Point(-1, -1);
        //private int surface = 0;
        private List<Rectangle> _rects = new List<Rectangle>();
        public Form1()
        {
            InitializeComponent();

            //this.surface += new System.Windows.Forms.
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
        }
        //mouse click button
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                p1 = e.Location;
        }
        //mouse move
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                p2 = e.Location;
                this.Invalidate();
            }
        }
        //mouse release button
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                p2 = e.Location;
                this.Invalidate();
                //Add rectangles to list
                if (p1.X < p2.X && p1.Y < p2.Y)
                    this._rects.Add(new Rectangle(p1.X, p1.Y, p2.X - p1.X, p2.Y - p1.Y));
                else if (p1.X > p2.X && p1.Y > p2.Y)
                    this._rects.Add(new Rectangle(p2.X, p2.Y, p1.X - p2.X, p1.Y - p2.Y));
                else if (p1.X > p2.X && p1.Y < p2.Y)
                    this._rects.Add(new Rectangle(p2.X, p1.Y, p1.X - p2.X, p2.Y - p1.Y));
                else if (p1.X < p2.X && p1.Y > p2.Y)
                    this._rects.Add(new Rectangle(p1.X, p2.Y, p2.X - p1.X, p1.Y - p2.Y));
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)//draw rectangles
        {
            if (p1.X > 0 && p1.Y > 0 && p2.X > 0 && p2.Y > 0)//all motions solved for drawing(improve with switch case)
            {
                if(p1.X < p2.X && p1.Y < p2.Y)
                    e.Graphics.DrawRectangle(Pens.Blue, new Rectangle(p1.X, p1.Y, p2.X - p1.X, p2.Y - p1.Y));
                else if(p1.X > p2.X && p1.Y > p2.Y)
                    e.Graphics.DrawRectangle(Pens.Blue, new Rectangle(p2.X, p2.Y, p1.X - p2.X, p1.Y - p2.Y));
                else if (p1.X > p2.X && p1.Y < p2.Y)
                    e.Graphics.DrawRectangle(Pens.Blue, new Rectangle(p2.X, p1.Y, p1.X - p2.X, p2.Y - p1.Y));
                else if (p1.X < p2.X && p1.Y > p2.Y)
                    e.Graphics.DrawRectangle(Pens.Blue, new Rectangle(p1.X, p2.Y, p2.X - p1.X, p1.Y - p2.Y));
                Console.WriteLine("p1-x" + p1.X);
                Console.WriteLine("p1-y" + p1.Y);
                Console.WriteLine("p2-x" + p2.X);
                Console.WriteLine("p2-y" + p2.Y);
            }
            
            //draw all Rectangles
            if (_rects.Count > 0)
                e.Graphics.DrawRectangles(Pens.Red, _rects.ToArray());
        }
    }
}