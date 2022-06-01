using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1() // Gets executed when the form is created 
        {
            InitializeComponent();
        }

        private bool mouseDown; // Boolean to check if the mouse is down
        private bool placing;
        private Point lastLocation; // Last location of the mouse
        private bool clear = false;
        private int size = 60; // Size of the squares


        private void button1_MouseDown(object sender, MouseEventArgs e) // When the mouse is pressed down on button1
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseDown = true;
                lastLocation = e.Location; // Saves last location
            }
            else if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(button1,e.Location);
            }
        }


        private void button1_MouseMove(object sender, MouseEventArgs e)  // When the mouse moves
        {
            if (mouseDown)
            {
                button1.Location = new Point( // Repositions the button to the nearst square
                    (int)RoundF((button1.Location.X - lastLocation.X) + e.X, Width / size), (int)RoundF((button1.Location.Y - lastLocation.Y) + e.Y, Width / size));
                //                              ^ Rounds X location to nearest value dividable by width / size
                //                                Example: RoundF(73.5, 5) -> 75 
                button1.Update();
            }
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void Form1_Paint(object sender, PaintEventArgs e) // When Form1 gets drawn
        {
            Pen pen = new Pen(Color.LightGray, 4); // Same as turtle

            if (clear) // when it has to be cleared
            {
                e.Graphics.Clear(Color.White);
            }

            // draw a grid full of hexagons
            for (int y = 0; y < Height / (size / 2); y++)
            {
                for (int x = 0; x < Width / (size / 2); x++)
                {
                    int xpos = x * size;
                    int ypos = y * size;

                    xpos += (size / 2) * (y % 2);
                    ypos -= (size / 4 + 1) * y;

                    e.Graphics.DrawPolygon(pen, new Point[] {
                        new Point(xpos + size / 2, ypos),
                        new Point(xpos + size, ypos + size / 4),
                        new Point(xpos + size, ypos + size / 4 * 3),
                        new Point(xpos + size / 2, ypos + size),
                        new Point(xpos,ypos + size / 4 * 3),
                        new Point(xpos, ypos + size / 4)
                    });
                }
            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e) //braucht man egentlich nicht
        {
            clear = true;
            //Form1_Paint(sender, new PaintEventArgs(this.CreateGraphics(), this.ClientRectangle)); // call the Form1_Paint event, basicly like a method
            clear = false;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e) // diche hex werdnen gezeichnet
        {
            if (e.Button == MouseButtons.Left)
            {
                DrawHexagon(Color.Black, e);
                // Draw block at e(=mouse pos)
            }
            else
            {
                DrawHexagon(Color.LightGray, e);
            }
            placing = true;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (placing && e.Button == MouseButtons.Left)
            {
                placing = false;
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (placing && e.Button == MouseButtons.Left)
            {
                DrawHexagon(Color.Black, e);
            }
            else if (placing && e.Button == MouseButtons.Right)
            {
                DrawHexagon(Color.LightGray, e);
            }
        }

        private void DrawLine(Color color, MouseEventArgs e) //debugtool
        {
            Pen pen = new Pen(color, 3);
            Point x = new Point(40, 40);
            Point y = new Point(100, 40);
            CreateGraphics().DrawLine(pen, x, y);
        }
        private void DrawHexagon(Color color, MouseEventArgs e) // zeichner
        {
            //DrawLine(Color.Red, e);
            Pen pen = new Pen(color, 3);

            int x = (int)RoundF(e.X, size);
            //int y = (int)RoundF(e.Y, (size / 4) * 3);
            //int offset = 
            

            //float yF = e.Y * 1.0F / size * (size / 4.0F) * 3.0F;

            int y = (int)(e.Y);

            y = (int)RoundF(y, (size / 4) * (float)2.935);

            int yr = y; //r steht f�r rechnen
            int xr = (int)RoundF(e.X, 30);
            yr = yr % 45;
            yr = y - yr;
            yr /= 45;
            if (yr % 2 == 0 && y > 30)
            {
                xr /= 30;
                if (xr % 2 == 0)
                {
                    x -= 30;
                }
                else
                {
                    x += 30;
                }
            }

            //if ((y + 0.0F) / size % 2 != 0)
            //{
            //    if (e.X * 1.0 / size - (int)(e.X / size) > 0.5)
            //    {
            //        x += size / 2;
            //    }
            //    else
            //    {
            //        x -= size / 2;
            //    }
            //}


            CreateGraphics().DrawPolygon(pen, new Point[] {
                    new Point(x + size / 2, y),
                    new Point(x + size, y + size / 4),
                    new Point(x + size, y + size / 4 * 3),
                    new Point(x + size / 2, y + size),
                    new Point(x,y + size / 4 * 3),
                    new Point(x,y + size / 4)
            });
        }

        private float RoundF(int input, float roundTo)
        {
            return MathF.Round(input / roundTo, MidpointRounding.ToZero) * (roundTo); // Callculates next value dividable by rountTo
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
