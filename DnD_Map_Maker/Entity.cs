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
        private Label label = new Label();
        private string imagePath = "";
        public Entity(int x, int y, int width, int height, string name, string imgPath,MainForm mainForm)
        {
            this.m = mainForm;
            this.Location = new Point(x, y);
            this.Width = width - mainForm.penSize * 3;
            this.Height = height - mainForm.penSize * 3;
            //this.BackColor = Color.Black;
            this.MouseDown += MouseDownHandler;
            this.MouseMove += MouseMoveHandler;
            this.MouseUp += MouseUpHandler;
            Image = Image.FromFile(imgPath);
            imagePath = imgPath;
            SizeMode = PictureBoxSizeMode.StretchImage;
            BackColor = Color.Transparent;
            
            ContextMenuStrip c = new ContextMenuStrip();
            this.ContextMenuStrip = new ContextMenuStrip();
            this.ContextMenuStrip.Items.Add("Show Name", null, ContextMenu_ShowName);
            this.ContextMenuStrip.Items.Add("Set Name",null,ContextMenu_SetName);
            ToolStripItem[] setIcons = new ToolStripItem[]
            {
                new ToolStripMenuItem("From preset", null, ContextMenu_Preset),
                new ToolStripMenuItem("From file", null, ContextMenu_File)
            };
            this.ContextMenuStrip.Items.Add(new ToolStripMenuItem("Set Icon", null, setIcons));
            this.ContextMenuStrip.Items.Add("Delete", null, ContextMenu_Delete);
            
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.BackColor = Color.Transparent;
            label.Text = name;
            label.Width = m.size * 2;
            label.Location = new Point(Location.X - m.size / 2, Location.Y - m.size / 2);
        }
        
        private void ContextMenu_ShowName(object? sender, EventArgs e)
        {
            if (m.Controls.Contains(label))
            {
                m.Controls.Remove(label);
                ContextMenuStrip.Items.RemoveAt(0);
                ContextMenuStrip.Items.Insert(0,new ToolStripMenuItem("Show Name",null,ContextMenu_ShowName));
            }
            else
            {
                m.Controls.Add(label);
                ContextMenuStrip.Items.RemoveAt(0);
                ContextMenuStrip.Items.Insert(0, new ToolStripMenuItem("Hide Name", null, ContextMenu_ShowName));
            }
        }
        
        private void ContextMenu_SetName(object? sender, EventArgs e)
        {
            string newEntityName = Microsoft.VisualBasic.Interaction.InputBox("Set new name for entity", "New name");
            label.Text = newEntityName;
        }
        
        private void ContextMenu_Preset(object? sender, EventArgs e)
        {
            
        }
        
        private void ContextMenu_File(object? sender, EventArgs e)
        {
            m.OpenFile.InitialDirectory = @"..\..\..\";
            m.OpenFile.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";

            if (m.OpenFile.ShowDialog() == DialogResult.OK)
            {
                ImageLocation = m.OpenFile.FileName;
                imagePath = m.OpenFile.FileName;
                SizeMode = PictureBoxSizeMode.StretchImage;
                BackColor = Color.Transparent;
            }

        }

        private void ContextMenu_Delete(object? sender, EventArgs e)
        {
            m.Controls.Remove(label);
            m.Controls.Remove(this);
        }

        private void MouseDownHandler(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseDown = true;
                lastLocation = e.Location;
            }
            else if (e.Button == MouseButtons.Right)
            {
                m.EntityContextMenu.Visible = false;
                ContextMenuStrip.Show(e.Location);
                Thread.Sleep(120);
                m.EntityContextMenu.Visible = true;
            }
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
                    label.Location = new Point(Location.X - m.size / 2, Location.Y - m.size / 2);
                }

                Update();
            }
        }
        private void MouseUpHandler(object? sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
        public override string ToString()
        {
            return $"{Location.X};{Location.Y};{Width};{Height};{label.Text};{imagePath}";
        }
    }
}
