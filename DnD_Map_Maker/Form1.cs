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
        private bool drawn = false; // Boolean to check if the user has drawn something
        private List<Entity> entities = new List<Entity>();


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

        private void button1_Click(object sender, EventArgs e)
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
                                    this));
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
    }
}
