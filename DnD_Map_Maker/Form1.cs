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
        public List<Entity> entities = new List<Entity>();


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
                    CreateGraphics().FillRectangle(new SolidBrush(Color.Black), e.X, e.Y, 4, 4);
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
                                    CreateGraphics().FillRectangle(new SolidBrush(Color.Black), x, y, 4, 4);
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
                                CreateGraphics().FillRectangle(new SolidBrush(Color.Black), x, y, 4, 4);
                            }
                        }
                    }
                }
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
            if (File.Exists(@"Resources\none.png"))
            {
                Entity en = new Entity(153, 53, size, size, "test1", @"Resources\none.png", this);
                Controls.Add(en);
                entities.Add(en);
            }
            else
            {
                Entity en = new Entity(153, 53, size, size, "test1", @"..\..\..\Resources\none.png", this);
                Controls.Add(en);
                entities.Add(en);
            }
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
                                    if (!drawn && drawings[x,y] == 1)
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
        
        private void PenButton_Click(object sender, EventArgs e)
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
            Entity en = new Entity(153, 53, size, size, "Paladin", @"Resources\Presets\Paladin.png", this);
            Controls.Add(en);
            entities.Add(en);
        }

        private void figtherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Entity en = new Entity(153, 53, size, size, "Figther", @"Resources\Presets\Fighter.png", this);
            Controls.Add(en);
            entities.Add(en);
        }

        private void clericToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Entity en = new Entity(153, 53, size, size, "Cleric", @"Resources\Presets\Cleric.png", this);
            Controls.Add(en);
            entities.Add(en);
        }

        private void babaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Entity en = new Entity(153, 53, size, size, "Babarian", @"Resources\Presets\Barbarian.png", this);
            Controls.Add(en);
            entities.Add(en);
        }

        private void rogueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Entity en = new Entity(153, 53, size, size, "Rogue", @"Resources\Presets\Rogue.png", this);
            Controls.Add(en);
            entities.Add(en);
        }

        private void monkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Entity en = new Entity(153, 53, size, size, "Monk", @"Resources\Presets\Monk.png", this);
            Controls.Add(en);
            entities.Add(en);
        }

        private void rangerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Entity en = new Entity(153, 53, size, size, "Ranger", @"Resources\Presets\Ranger.png", this);
            Controls.Add(en);
            entities.Add(en);
        }

        private void bardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Entity en = new Entity(153, 53, size, size, "Bard", @"Resources\Presets\Bard.png", this);
            Controls.Add(en);
            entities.Add(en);
        }

        private void druidToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Entity en = new Entity(153, 53, size, size, "Druid", @"Resources\Presets\Druid.png", this);
            Controls.Add(en);
            entities.Add(en);
        }

        private void sorcererToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Entity en = new Entity(153, 53, size, size, "Sorcerer", @"Resources\Presets\Sorcerer.png", this);
            Controls.Add(en);
            entities.Add(en);
        }

        private void warlockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Entity en = new Entity(153, 53, size, size, "Warlock", @"Resources\Presets\Warlock.png", this);
            Controls.Add(en);
            entities.Add(en);
        }

        private void wizardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Entity en = new Entity(153, 53, size, size, "Wizard", @"Resources\Presets\Wizard.png", this);
            Controls.Add(en);
            entities.Add(en);
        }

        private void enemy1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Entity en = new Entity(153, 53, size, size, "Enemy1", @"Resources\Presets\Enemy1.png", this);
            Controls.Add(en);
            entities.Add(en);
        }

        private void enemy2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Entity en = new Entity(153, 53, size, size, "Enemy2", @"Resources\Presets\Enemy2.png", this);
            Controls.Add(en);
            entities.Add(en);
        }

        private void enemy3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Entity en = new Entity(153, 53, size, size, "Enemy3", @"Resources\Presets\Enemy3.png", this);
            Controls.Add(en);
            entities.Add(en);
        }

        private void enemy4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Entity en = new Entity(153, 53, size, size, "Enemy4", @"Resources\Presets\Enemy4.png", this);
            Controls.Add(en);
            entities.Add(en);
        }

        private void enemy5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Entity en = new Entity(153, 53, size, size, "Enemy5", @"Resources\Presets\Basic Bad Bitch.png", this);
            Controls.Add(en);
            entities.Add(en);
        }

        private void boss1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Entity en = new Entity(153, 53, size, size, "Boss1", @"Resources\Presets\Boss1.png", this);
            Controls.Add(en);
            entities.Add(en);
        }

        private void boss2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Entity en = new Entity(153, 53, size, size, "Boss2", @"Resources\Presets\Boss2.png", this);
            Controls.Add(en);
            entities.Add(en);
        }

        private void dragonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Entity en = new Entity(153, 53, size, size, "Dragon", @"Resources\Presets\Rawwwww.png", this);
            Controls.Add(en);
            entities.Add(en);
        }

        private void door1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Entity en = new Entity(153, 53, size, size, "Door1", @"Resources\Presets\Door.png", this);
            Controls.Add(en);
            entities.Add(en);
        }

        private void dorr2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Entity en = new Entity(153, 53, size, size, "Door2", @"Resources\Presets\You expectet a Joke, but it was me Dio.png", this);
            Controls.Add(en);
            entities.Add(en);
        }

        private void stairsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Entity en = new Entity(153, 53, size, size, "Stairs", @"Resources\Presets\Stairs.png", this);
            Controls.Add(en);
            entities.Add(en);
        }

        private void bonfireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Entity en = new Entity(153, 53, size, size, "Bonfire", @"Resources\Presets\Take a rest.png", this);
            Controls.Add(en);
            entities.Add(en);
        }

        private void wellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Entity en = new Entity(153, 53, size, size, "Well", @"Resources\Presets\Get Wel soon.png", this);
            Controls.Add(en);
            entities.Add(en);
        }

        private void johanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Entity en = new Entity(153, 53, size, size, "Balanced", @"Resources\Presets\b in Hans steht für balanced.png", this);
            Controls.Add(en);
            entities.Add(en);
        }

        private void customToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Entity en = new (153, 53, size, size, "Basic Bitch", @"Resources\Presets\Basic Bitch.png", this);
            Controls.Add(en);
            entities.Add(en);
        }

        private void vogelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Entity en = new Entity(153, 53, size, size, "Vogel", @"Resources\Presets\Daniel and Dragons.png", this);
            Controls.Add(en);
            entities.Add(en);
        }

        private void gayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Entity en = new Entity(153, 53, size, size, "Gay", @"Resources\Presets\Its ya boy.png", this);
            Controls.Add(en);
            entities.Add(en);
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
            }
            else
            {
                turnOrderActive = true;
                ShowTurnOrder.BackColor = Color.LightGray;
                TurnOrder.Visible = true;
                TurnOrder.Enabled = true;
            }
        }
    }
}
