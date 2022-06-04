using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Map_Maker
{
    public class Entity : PictureBox
    {
        private bool mouseDown;
        private Point lastLocation;
        private MainForm m;
        public Entity(int x, int y, int width, int height, string name, MainForm mainForm)
        {
            this.m = mainForm;
            this.Location = new Point(x, y);
            this.Width = width - mainForm.penSize * 3;
            this.Height = height - mainForm.penSize * 3;
            this.Name = name;
            this.BackColor = Color.Black;
            this.MouseDown += MouseDownHandler;
            this.MouseMove += MouseMoveHandler;
            this.MouseUp += MouseUpHandler;
        }
        private void MouseDownHandler(object? sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void MouseMoveHandler(object? sender, MouseEventArgs e) 
        {
            if (mouseDown)
            {
                var mouse = m.PointToClient(Cursor.Position);
                Point newLocation = new Point(m.RoundI(mouse.X, m.size) + 3, m.RoundI(mouse.Y, m.size) + 3);
                if (m.grid[newLocation.X / m.size, newLocation.Y / m.size] == 0 || !m.wallBlockingPlayer)
                {
                    Location = newLocation;
                }

                Update();
            }
        }
        private void MouseUpHandler(object? sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
    }
}
