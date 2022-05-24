using System.Runtime.InteropServices;

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool mouseDown;
        private bool placing;
        private Point lastLocation;
        private bool clear = false;
        private int size = 50;


        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }


        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                button1.Location = new Point(
                    (int)RoundF((button1.Location.X - lastLocation.X) + e.X, Width / size), (int)RoundF((button1.Location.Y - lastLocation.Y) + e.Y,Width / size));

                button1.Update();
            }
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.LightGray, 4);

            if (clear)
            {
                e.Graphics.Clear(Color.White);
            }

            int mult = this.Width / size;
            for (int i = 0; i < this.Width; i++)
            {
                e.Graphics.DrawLine(pen, mult * i, 0, mult * i, Height);
            }

            mult = this.Width / size;
            for (int i = 0; i < this.Height; i++)
            {
                e.Graphics.DrawLine(pen, 0, mult * i,Width, mult * i);
            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            clear = true;
            Form1_Paint(sender, new PaintEventArgs(this.CreateGraphics(), this.ClientRectangle));
            clear = false;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DrawBlock(Color.Black, e);
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
            return MathF.Round(input / roundTo) * (roundTo);
        }
    }
}