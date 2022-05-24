using System.Runtime.InteropServices;

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
        private int size = 50; // Size of the squares


        private void button1_MouseDown(object sender, MouseEventArgs e) // When the mouse is pressed down on button1
        {
            mouseDown = true;
            lastLocation = e.Location; // Saves last location
        }


        private void button1_MouseMove(object sender, MouseEventArgs e)  // When the mouse moves
        {
            if (mouseDown)
            {
                button1.Location = new Point( // Repositions the button to the nearst square
                    (int)RoundF((button1.Location.X - lastLocation.X) + e.X, Width / size), (int)RoundF((button1.Location.Y - lastLocation.Y) + e.Y,Width / size));
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

            int mult = this.Width / size; // ka vergessen was genau ich mir gedacht hab
            for (int i = 0; i < this.Width; i++)
            {
                CreateGraphics().DrawLine(pen, mult * i, 0, mult * i, Height);
             // new Graphi  what to do ^  ^ wich pen      ^ corrdinates
            }

            mult = this.Width / size;
            for (int i = 0; i < this.Height; i++)
            {
                CreateGraphics().DrawLine(pen, 0, mult * i,Width, mult * i);
            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            clear = true;
            Form1_Paint(sender, new PaintEventArgs(this.CreateGraphics(), this.ClientRectangle)); // call the Form1_Paint event, basicly like a method
            clear = false;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DrawBlock(Color.Black, e);
                // Draw block at e(=mouse pos)
            }
            else if (true)
            {
                DrawBlock(Color.LightGray, e);
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
                DrawBlock(Color.Black,e);
            }
            else if (placing && e.Button == MouseButtons.Right)
            {
                DrawBlock(Color.LightGray,e);
            }
        }

        private void DrawBlock(Color color, MouseEventArgs e)
        {
            Pen pen = new Pen(color, 3);
            float x = RoundF(e.X, Width / size);
            float y = RoundF(e.Y, Width / size);
            CreateGraphics().DrawRectangle(pen, x, y, size, size);
        }

        private float RoundF(int input, int roundTo)
        {
            return MathF.Round(input / roundTo) * (roundTo); // Callculates next value dividable by rountTo
        }
    }
}