using System.Diagnostics;
using System.Runtime.InteropServices;
using System.IO.Compression;

namespace DnD_Map_Maker
{
    public partial class MainForm : Form
    {
        public MainForm() // Gets executed when the form is created 
        {
            InitializeComponent();
            grid = new int[Width / size, Height / size];
            drawings = new int[Width, Height];
        }

        private bool placing;
        public int size = 50; // Size of the squares
        public int[,] grid; // Grid of the map
        public int[,] drawings;
        public readonly int penSize = 2; // Size of the pen
        public bool wallBlockingPlayer = true; // Boolean to check if the player can walk through walls
        private bool isUsingPencil = false; // Boolean to check if the user is using the pencil
        private bool isUsingEraser = false; // Boolean to check if the user is using the eraser
        private bool turnOrderActive = false; // Boolean to check if the user is using the turn order
        private bool drawn = false; // Boolean to check if the user has drawn something
        private Color penColor = Color.Black;
        private int drawSize = 4;
        public List<Entity> entities = new List<Entity>();
        private bool AscendingSort = true;

        private void Form1_Paint(object sender, PaintEventArgs e) // When Form1 gets drawn
        {
            Pen pen = new Pen(Color.LightGray, penSize); // Same as 

            for (int i = 0; i < this.Width / size; i++)
            {
                CreateGraphics().DrawLine(pen, i * size, 0, i * size, Height);
                // new Graphi  what to do ^  ^ wich pen      ^ corrdinates
            }

            for (int i = 0; i < this.Height / size; i++)
            {
                CreateGraphics().DrawLine(pen, 0, i * size, Width, i * size);
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (isUsingPencil)
                {
                    CreateGraphics().FillRectangle(new SolidBrush(penColor), e.X, e.Y, drawSize, drawSize);
                    drawings[e.X, e.Y] = 1;
                    drawn = true;
                }
                else if (isUsingEraser)
                {
                    CreateGraphics().FillRectangle(new SolidBrush(Color.White), e.X - 16, e.Y - 16, 32, 32);
                    Form1_Paint(this, new PaintEventArgs(CreateGraphics(), new Rectangle(e.X, e.Y, 20, 20)));
                    for (int y = 0; y < 16; y++)
                    {
                        for (int x = 0; x < 16; x++)
                        {
                            drawings[e.X + x, e.Y + y] = 0;
                            drawings[e.X - x, e.Y + y] = 0;
                            drawings[e.X + x, e.Y - y] = 0;
                            drawings[e.X - x, e.Y - y] = 0;
                        }
                    }
                }
                else
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        DrawBlock(Color.Black, e);
                        // Draw block at e(=mouse pos)
                    }
                    else
                    {
                        DrawBlock(Color.White, e);
                    }
                    placing = true;
                }
            }
            catch { }
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
            if ((isUsingPencil || isUsingEraser) && e.Button == MouseButtons.Left)
            {
                Form1_MouseDown(this, e);
            }
            else if (placing && e.Button == MouseButtons.Left)
            {
                DrawBlock(Color.Black, e);
            }
            else if (placing && e.Button == MouseButtons.Right)
            {
                DrawBlock(Color.White, e);
            }
        }

        private void DrawBlock(Color color, MouseEventArgs e)
        {
            Pen pen = new Pen(color, penSize);
            float x = RoundF(e.X, size);
            float y = RoundF(e.Y, size);
            DrawBlock(pen, (int)x + 2, (int)y + 2);
        }

        private void DrawBlock(Pen pen, int x, int y)
        {
            CreateGraphics().DrawRectangle(pen, x, y, size - 4, size - 4);
            try
            {
                if (pen.Color == Color.Black)
                {
                    grid[x / size, y / size] = 1;
                }
                else if (pen.Color == Color.White)
                {
                    grid[x / size, y / size] = 0;
                }
            }
            catch
            {
                //MessageBox.Show("Bitte nicht auserhalb des Fensters zeichnen, danke", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public float RoundF(int input, int roundTo)
        {
            return MathF.Round(input / roundTo) * (roundTo); // Callculates next value dividable by rountTo
        }

        public int RoundI(int input, int roundTo)
        {
            return (int)MathF.Round(input / roundTo) * (roundTo); // Callculates next value dividable by rountTo
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                int[,] newArray = new int[Width / size, Height / size];
                int[,] newDrawings = new int[Width, Height];
                if (!(newArray.Length <= grid.Length))
                {
                    for (int y = 0; y < grid.GetLength(1); y++)
                    {
                        for (int x = 0; x < grid.GetLength(0); x++)
                        {
                            newArray[x, y] = grid[x, y];
                        }
                    }
                    if (drawn)
                    {
                        for (int y = 0; y < drawings.GetLength(1); y++)
                        {
                            for (int x = 0; x < drawings.GetLength(0); x++)
                            {
                                newDrawings[x, y] = drawings[x, y];
                                if (drawings[x, y] == 1)
                                {
                                    CreateGraphics().FillRectangle(new SolidBrush(penColor), x, y, drawSize, drawSize);
                                }
                            }
                        }
                    }
                    drawings = newDrawings;
                    grid = newArray;
                }
                Pen pen = new Pen(Color.Black, penSize);
                for (int y = 0; y < grid.GetLength(1); y++)
                {
                    for (int x = 0; x < grid.GetLength(0); x++)
                    {
                        if (grid[x, y] == 1)
                        {
                            DrawBlock(pen, x * size + penSize, y * size + penSize);
                        }
                    }
                }
                if (drawn)
                {
                    for (int y = 0; y < drawings.GetLength(1); y++)
                    {
                        for (int x = 0; x < drawings.GetLength(0); x++)
                        {
                            if (drawings[x, y] == 1)
                            {
                                CreateGraphics().FillRectangle(new SolidBrush(penColor), x, y, drawSize, drawSize);
                            }
                        }
                    }
                }

                SortButton.Location = new Point(Width - 80, Height - 121);
            }
            catch
            {

            }
        }
        private void AddEntity_MouseDown(object sender, MouseEventArgs e)
        {
            AddEntity.ContextMenuStrip = AddEntityContextMenu;
            AddEntityContextMenu.Show(AddEntity, new Point(e.X, e.Y));
        }

        private void newToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //if (File.Exists(@"Resources\none.png"))
            //{
            //    Entity en = new Entity(153, 53, size, size, "test1", @"Resources\none.png", this);
            CreateEntity("test1", "none");
            //}
            //else
            //{
            //    Entity en = new Entity(153, 53, size, size, "test1", @"..\..\..\Resources\none.png", this);
            //    CreateEntity("test1","");
            //}
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show(
                "Do you really want to create a new File?\r\nAny unsaved data will be lost.",
                "New File",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);
            if (res == DialogResult.OK)
            {
                Application.Restart();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile.InitialDirectory = @"%USERPROFILE%\Documents\";
            SaveFile.Filter = "DnD Map Files|*.dndmap";

            if (SaveFile.ShowDialog() == DialogResult.OK)
            {
                string[] blocks = new string[grid.GetLength(1)];
                for (int y = 0; y < grid.GetLength(1); y++)
                {
                    for (int x = 0; x < grid.GetLength(0); x++)
                    {
                        blocks[y] += grid[x, y].ToString();
                    }
                    File.WriteAllLines(Environment.GetEnvironmentVariable("TEMP") + @"\dndmapblocks", blocks);
                }
                string[] entitiyArray = new string[entities.Count];
                foreach (var en in entities)
                {
                    entitiyArray[entities.IndexOf(en)] = en.ToString();
                }
                File.WriteAllLines(Environment.GetEnvironmentVariable("TEMP") + @"\dndmapentities", entitiyArray);

                blocks = new string[drawings.GetLength(1)];
                for (int y = 0; y < drawings.GetLength(1); y++)
                {
                    for (int x = 0; x < drawings.GetLength(0); x++)
                    {
                        blocks[y] += drawings[x, y].ToString();
                    }
                    File.WriteAllLines(Environment.GetEnvironmentVariable("TEMP") + @"\dndmapdrawings", blocks);
                }
                using (var archive = ZipFile.Open(SaveFile.FileName, ZipArchiveMode.Update))
                {
                    archive.CreateEntryFromFile(Environment.GetEnvironmentVariable("TEMP") + @"\dndmapblocks", "blocks.txt");
                    archive.CreateEntryFromFile(Environment.GetEnvironmentVariable("TEMP") + @"\dndmapentities", "entities.txt");
                    archive.CreateEntryFromFile(Environment.GetEnvironmentVariable("TEMP") + @"\dndmapdrawings", "drawings.txt");
                }
            }
        }

        private void gitHubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("explorer", "https://github.com/Megageil4/DnD_Map_Maker");
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile.Filter = "DnD Map Files|*.dndmap";

            if (OpenFile.ShowDialog() == DialogResult.OK)
            {
                using (var archive = ZipFile.OpenRead(OpenFile.FileName))
                {
                    foreach (var entry in archive.Entries)
                    {
                        if (entry.Name == "blocks.txt")
                        {
                            entry.ExtractToFile(Environment.GetEnvironmentVariable("TEMP") + @"\dndmapblocks", true);

                            string[] blocks = File.ReadAllLines(Environment.GetEnvironmentVariable("TEMP") + @"\dndmapblocks");

                            grid = new int[blocks[0].Length, blocks.Length];
                            for (int y = 0; y < blocks.Length; y++)
                            {
                                for (int x = 0; x < blocks[y].Length; x++)
                                {
                                    grid[x, y] = int.Parse(blocks[y][x].ToString());
                                }
                            }
                        }
                        else if (entry.Name == "entities.txt")
                        {
                            foreach (var en in entities)
                            {
                                Controls.Remove(en);
                            }
                            entities.Clear();
                            entry.ExtractToFile(Environment.GetEnvironmentVariable("TEMP") + @"\dndmapentities", true);
                            string[] entitiyArray = File.ReadAllLines(Environment.GetEnvironmentVariable("TEMP") + @"\dndmapentities");
                            TurnOrder.Items.Clear();
                            foreach (var en in entitiyArray)
                            {
                                string[] entity = en.Split(';');
                                entities.Add(new Entity(
                                    int.Parse(entity[0]),
                                    int.Parse(entity[1]),
                                    int.Parse(entity[2]),
                                    int.Parse(entity[3]),
                                    entity[4],
                                    entity[5],
                                    this,
                                    int.Parse(entity[6])));
                                Controls.Add(entities[entities.Count - 1]);
                            }
                        }
                        else if (entry.Name == "drawings.txt")
                        {
                            entry.ExtractToFile(Environment.GetEnvironmentVariable("TEMP") + @"\dndmapdrawings", true);
                            string[] blocks = File.ReadAllLines(Environment.GetEnvironmentVariable("TEMP") + @"\dndmapdrawings");
                            drawings = new int[blocks[0].Length, blocks.Length];
                            for (int y = 0; y < blocks.Length; y++)
                            {
                                for (int x = 0; x < blocks[y].Length; x++)
                                {
                                    drawings[x, y] = int.Parse(blocks[y][x].ToString());
                                    if (!drawn && drawings[x, y] == 1)
                                    {
                                        drawn = true;
                                    }
                                }
                            }
                        }
                    }
                }
                CreateGraphics().Clear(Color.White);
                this.MainForm_SizeChanged(this, new EventArgs());
            }
        }

        private void PenButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (isUsingPencil)
                {
                    isUsingPencil = false;
                    PenButton.BackColor = MenuPanel.BackColor;
                }
                else
                {
                    isUsingPencil = true;
                    PenButton.BackColor = Color.LightGray;
                    isUsingEraser = false;
                    EraserButton.BackColor = MenuPanel.BackColor;
                }
            }
            else
            {
                PenButton.ContextMenuStrip = DrawContextMenu;
                DrawContextMenu.Show(PenButton, new Point(e.X, e.Y));
            }
        }

        //private void changeColorToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    ColorDialog cd = new ColorDialog();
        //    if (cd.ShowDialog() == DialogResult.OK)
        //    {
        //        penColor = cd.Color;
        //    }
        //}

        //private void changeSizeToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    string newSize = Microsoft.VisualBasic.Interaction.InputBox("Set new size for the pen", "Change size");
        //    try
        //    {
        //        drawSize = int.Parse(newSize);
        //    }
        //    catch
        //    {

        //        MessageBox.Show("Please enter a valid Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void EraserButton_Click(object sender, EventArgs e)
        {
            if (isUsingEraser)
            {
                isUsingEraser = false;
                EraserButton.BackColor = MenuPanel.BackColor;
            }
            else
            {
                isUsingEraser = true;
                EraserButton.BackColor = Color.LightGray;
                isUsingPencil = false;
                PenButton.BackColor = MenuPanel.BackColor;
            }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "This is a simple map editor for D&D 5e.\n\n" +
                "The map is made up of blocks.\n" +
                "Blocks are placed by left clicking on the map.\n" +
                "Blocks can be removed by right clicking on the map.\n" +
                "Entity can be placed by clicken the \"+\" button.\n" +
                "Entities can be removed by right clicking on it and pressing delete.\n" +
                "The map can be saved by pressing the \"Save\" button.\n" +
                "The map can be loaded by pressing the \"Load\" button.\n" +
                "The map can be reset by pressing the \"New\" button.\n", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Write a Info Dialog with disclaimer
            MessageBox.Show("This is a simple editor for D&D 5e made by Megageil4 with the help of Norrox123\r\n\r\n" +
                "This program is free software: you can redistribute it and/or modify it.\n" +
                "This program is distributed in the hope that it will be useful,\n" +
                "but WITHOUT ANY WARRANTY; without even the implied warranty of\n" +
                "MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // !!DO NOT OPEN THIS!! It's for your sake
        #region Please never open and ignore the next ~200 lines
        private void paladinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateEntity("Paladin", "Paladin");
        }

        private void figtherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateEntity("Fighter", "Fighter");
        }

        private void clericToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateEntity("Cleric", "Cleric");
        }

        private void babaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateEntity("Barbarian", "Barbarian");
        }

        private void rogueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateEntity("Rogue", "Rogue");
        }

        private void monkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateEntity("Monk", "Monk");
        }

        private void rangerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateEntity("Ranger", "Ranger");
        }

        private void bardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateEntity("Bard", "Bard");
        }

        private void druidToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateEntity("Druid", "Druid");
        }

        private void sorcererToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateEntity("Sorcerer", "Sorcerer");
        }

        private void warlockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateEntity("Warlock", "Warlock");
        }

        private void wizardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateEntity("Wizard", "Wizard");
        }

        private void enemy1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateEntity("Enemy1", "Enemy1");
        }

        private void enemy2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateEntity("Enemy2", "Enemy2");
        }

        private void enemy3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateEntity("Enemy3", "Enemy3");
        }

        private void enemy4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateEntity("Enemy4", "Enemy4");
        }

        private void enemy5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateEntity("Enemy5", "Basic Bad Bitch");
        }

        private void boss1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateEntity("Boss1", "Boss1");
        }

        private void boss2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateEntity("Boss2", "Boss2");
        }

        private void dragonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateEntity("Dragon", "Rawwwww");
        }

        private void door1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateEntity("Door1", "Door");
        }

        private void dorr2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateEntity("Door2", "You expectet a Joke, but it was me Dio");
        }

        private void stairsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateEntity("Stairs", "Stairs");
        }

        private void bonfireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateEntity("Bonfire", "Take a rest");
        }

        private void wellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateEntity("Well", "Get Wel soon");
        }

        private void johanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateEntity("Balanced", "b in Hans steht für balanced");
        }

        private void customToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CreateEntity("Basic Bitch", "Basic Bitch");
        }

        private void vogelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateEntity("Vogel", "Daniel and Dragons");
        }

        private void gayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateEntity("Gay", "Its ya boy");
        }
        private void balanced2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateEntity("BalancedTheSequel", "b_in_Hans_steht_fur_balanced");
        }

        #endregion

        private void iconButton1_Click(object sender, EventArgs e)
        {
            if (turnOrderActive)
            {
                turnOrderActive = false;
                ShowTurnOrder.BackColor = MenuPanel.BackColor;
                TurnOrder.Visible = false;
                TurnOrder.Enabled = false;
                SortButton.Visible = false;
            }
            else
            {
                turnOrderActive = true;
                ShowTurnOrder.BackColor = Color.LightGray;
                TurnOrder.Visible = true;
                TurnOrder.Enabled = true;
                SortButton.Visible = true;
                SortButton.BringToFront();
                SortButton.Location = new Point(Width - 80, Height - 121);
            }
        }

        public void SortTurnOrder()
        {
            entities = entities.OrderBy(o => o.PositionInTurnOrder).ToList();

            TurnOrder.Items.Clear();

            if (!AscendingSort)
            {
                for (int i = 0; i < entities.Count; i++)
                {
                    if (entities[i].InTurnOrder)
                    {
                        TurnOrder.Items.Add($"{entities[i].PositionInTurnOrder} {entities[i].label.Text}");
                    }
                }
            }
            else
            {
                for (int i = entities.Count; i > 0; i--)
                {
                    if (entities[i - 1].InTurnOrder)
                    {
                        TurnOrder.Items.Add($"{entities[i - 1].PositionInTurnOrder} {entities[i - 1].label.Text}");
                    }
                }
            }

        }

        public void CreateEntity(string name, string filename)
        {
            Entity en = new Entity(153, 53, size, size, name, @$"Resources\Presets\{filename}.png", this);
            Controls.Add(en);
            entities.Add(en);
            SortTurnOrder();
        }

        public void CreateEntity(Entity en)
        {
            Controls.Add(en);
            entities.Add(en);
            SortTurnOrder();
        }

        private void iconButton1_Click_1(object sender, EventArgs e)
        {
            if (AscendingSort)
            {
                SortButton.IconChar = FontAwesome.Sharp.IconChar.SortDown;
                AscendingSort = false;
            }
            else
            {
                SortButton.IconChar = FontAwesome.Sharp.IconChar.SortUp;
                AscendingSort = true;
            }
            SortTurnOrder();
        }
    }
}