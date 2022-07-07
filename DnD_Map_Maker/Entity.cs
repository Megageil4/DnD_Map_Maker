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
        public Label label = new Label();
        private string imagePath = "";
        public bool InTurnOrder { get; set; } = true;
        public int PositionInTurnOrder { get; set; }
        public Entity(int x, int y, int width, int height, string name, string imgPath, MainForm mainForm, int posInTurnOrder = 0)
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
            imagePath = Path.GetFullPath(imgPath);
            SizeMode = PictureBoxSizeMode.StretchImage;
            BackColor = Color.Transparent;

            ContextMenuStrip c = new ContextMenuStrip();
            this.ContextMenuStrip = new ContextMenuStrip();
            this.ContextMenuStrip.Items.Add("Show Name", null, ContextMenu_ShowName);
            this.ContextMenuStrip.Items.Add("Set Name", null, ContextMenu_SetName);
            this.ContextMenuStrip.Items.Add("Set Turn Order", null, ContextMenu_SetTurnPos);
            this.ContextMenuStrip.Items.Add("Hide in Turn Order", null, ContextMenu_TurnOrderVisibility);
            this.ContextMenuStrip.Items.Add("Set Icon", null, ContextMenu_File);
            this.ContextMenuStrip.Items.Add("Set size", null, ContextMenu_SetSize);
            this.ContextMenuStrip.Items.Add("Dublicate", null, ContextMenu_Dublicate);
            this.ContextMenuStrip.Items.Add("Delete", null, ContextMenu_Delete);

            label.TextAlign = ContentAlignment.MiddleCenter;
            label.BackColor = Color.Transparent;
            label.Text = name;
            label.Width = m.size * 2;
            label.Location = new Point(Location.X - m.size / 2, Location.Y - m.size / 2);

            PositionInTurnOrder = posInTurnOrder;

            mainForm.TurnOrder.Items.Add($"{PositionInTurnOrder} {name}");
            mainForm.SortTurnOrder();
        }

        private void ContextMenu_ShowName(object? sender, EventArgs e)
        {
            if (m.Controls.Contains(label))
            {
                m.Controls.Remove(label);
                ContextMenuStrip.Items.RemoveAt(0);
                ContextMenuStrip.Items.Insert(0, new ToolStripMenuItem("Show Name", null, ContextMenu_ShowName));
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
            m.SortTurnOrder();
        }
        private void ContextMenu_SetTurnPos(object? sender, EventArgs e)
        {
            string newEntityPos = Microsoft.VisualBasic.Interaction.InputBox("Set new position in turn order for entity", "Position");
            try
            {
                int oldPos = PositionInTurnOrder;
                PositionInTurnOrder = int.Parse(newEntityPos);
                m.TurnOrder.Items.Remove($"{oldPos} {label.Text}");
            }
            catch
            {

                MessageBox.Show("Please enter a valid Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //m.TurnOrder.Items.Add($"{PositionInTurnOrder} {label.Text}");

            m.SortTurnOrder();
        }

        private void ContextMenu_File(object? sender, EventArgs e)
        {
            m.OpenFile.InitialDirectory = @"Resources";
            m.OpenFile.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";

            if (m.OpenFile.ShowDialog() == DialogResult.OK)
            {
                ImageLocation = m.OpenFile.FileName;
                imagePath = m.OpenFile.FileName;
            }

        }
        private void ContextMenu_SetSize(object? sender, EventArgs e)
        {
            string newSize = Microsoft.VisualBasic.Interaction.InputBox("Set new size for entity", "Size");
            try
            {
                Width = m.size * int.Parse(newSize) - m.penSize * 3;
                Height = m.size * int.Parse(newSize) - m.penSize * 3;
            }
            catch
            {

                MessageBox.Show("Please enter a valid Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ContextMenu_Dublicate(object? sender, EventArgs e)
        {
            Entity newEntity = new Entity(Location.X, Location.Y, m.size, m.size, label.Text, imagePath, m, PositionInTurnOrder);
            //m.Controls.Add(newEntity);
            //m.entities.Add(this);
            m.CreateEntity(newEntity);
        }
        private void ContextMenu_Delete(object? sender, EventArgs e)
        {
            m.Controls.Remove(label);
            m.Controls.Remove(this);
            m.entities.Remove(this);
            m.TurnOrder.Items.Remove($"{PositionInTurnOrder} {label.Text}");
            m.SortTurnOrder();
        }

        private void ContextMenu_TurnOrderVisibility(object? sender, EventArgs e)
        {
            if (ContextMenuStrip.Items[3].Text == "Hide in Turn Order")
            {
                InTurnOrder = false;
                ContextMenuStrip.Items[3].Text = "Show in Turn Order";
            }
            else
            {
                InTurnOrder = true;
                ContextMenuStrip.Items[3].Text = "Hide in Turn Order";
            }
            m.SortTurnOrder();
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
            return $"{Location.X};{Location.Y};{m.size};{m.size};{label.Text};{imagePath};{PositionInTurnOrder}";
        }
    }
}
