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
        }

        private bool placing;
        public int size = 50; // Size of the squares
        public int[,] grid; // Grid of the map
        public readonly int penSize = 2; // Size of the pen
        public bool wallBlockingPlayer = true; // Boolean to check if the player can walk through walls
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
            if (e.Button == MouseButtons.Left)
            {
                DrawBlock(Color.Black, e);
                // Draw block at e(=mouse pos)
            }
            else if (true)
            {
                DrawBlock(Color.White, e);
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
            int[,] newArray = new int[Width / size, Height / size];
            if (!(newArray.Length < grid.Length))
            {
                for (int y = 0; y < grid.GetLength(1); y++)
                {
                    for (int x = 0; x < grid.GetLength(0); x++)
                    {
                        newArray[x, y] = grid[x, y];
                    }
                }
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Entity en = new Entity(153, 53, size, size, "test1", @"..\..\..\Resources\none.png", this);
            Controls.Add(en);
            entities.Add(en);
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
                
                using (var archive = ZipFile.Open(SaveFile.FileName, ZipArchiveMode.Create))
                {
                    archive.CreateEntryFromFile(Environment.GetEnvironmentVariable("TEMP") + @"\dndmapblocks", "blocks.txt");
                    archive.CreateEntryFromFile(Environment.GetEnvironmentVariable("TEMP") + @"\dndmapentities", "entities.txt");
                }
            }
        }
    }
}