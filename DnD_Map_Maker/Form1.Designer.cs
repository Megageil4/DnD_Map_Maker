namespace DnD_Map_Maker
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.button1 = new System.Windows.Forms.Button();
            this.MenuPanel = new System.Windows.Forms.Panel();
            this.EraserButton = new FontAwesome.Sharp.IconButton();
            this.PenButton = new FontAwesome.Sharp.IconButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chnageSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.squareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hexagonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gitHubToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EntityContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.chnageNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeIconToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.presetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dublicateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFile = new System.Windows.Forms.OpenFileDialog();
            this.SaveFile = new System.Windows.Forms.SaveFileDialog();
            this.MenuPanel.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.EntityContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(54, 51);
            this.button1.TabIndex = 1;
            this.button1.Text = "New Entity";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MenuPanel
            // 
            this.MenuPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.MenuPanel.Controls.Add(this.EraserButton);
            this.MenuPanel.Controls.Add(this.PenButton);
            this.MenuPanel.Controls.Add(this.button1);
            this.MenuPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.MenuPanel.Location = new System.Drawing.Point(0, 24);
            this.MenuPanel.Name = "MenuPanel";
            this.MenuPanel.Size = new System.Drawing.Size(100, 613);
            this.MenuPanel.TabIndex = 2;
            // 
            // EraserButton
            // 
            this.EraserButton.FlatAppearance.BorderSize = 0;
            this.EraserButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EraserButton.IconChar = FontAwesome.Sharp.IconChar.Eraser;
            this.EraserButton.IconColor = System.Drawing.Color.Black;
            this.EraserButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.EraserButton.Location = new System.Drawing.Point(12, 181);
            this.EraserButton.Name = "EraserButton";
            this.EraserButton.Size = new System.Drawing.Size(54, 51);
            this.EraserButton.TabIndex = 3;
            this.EraserButton.UseVisualStyleBackColor = true;
            this.EraserButton.Click += new System.EventHandler(this.EraserButton_Click);
            // 
            // PenButton
            // 
            this.PenButton.FlatAppearance.BorderSize = 0;
            this.PenButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PenButton.IconChar = FontAwesome.Sharp.IconChar.Pen;
            this.PenButton.IconColor = System.Drawing.Color.Black;
            this.PenButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.PenButton.Location = new System.Drawing.Point(12, 97);
            this.PenButton.Name = "PenButton";
            this.PenButton.Size = new System.Drawing.Size(54, 49);
            this.PenButton.TabIndex = 2;
            this.PenButton.UseVisualStyleBackColor = true;
            this.PenButton.Click += new System.EventHandler(this.PenButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem,
            this.gridToolStripMenuItem,
            this.extraToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.menuStrip1.Size = new System.Drawing.Size(1091, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dateiToolStripMenuItem
            // 
            this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem});
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.dateiToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.dateiToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // gridToolStripMenuItem
            // 
            this.gridToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chnageSizeToolStripMenuItem,
            this.modeToolStripMenuItem});
            this.gridToolStripMenuItem.Name = "gridToolStripMenuItem";
            this.gridToolStripMenuItem.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.gridToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.gridToolStripMenuItem.Text = "Grid";
            // 
            // chnageSizeToolStripMenuItem
            // 
            this.chnageSizeToolStripMenuItem.Name = "chnageSizeToolStripMenuItem";
            this.chnageSizeToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.chnageSizeToolStripMenuItem.Text = "Change Size";
            // 
            // modeToolStripMenuItem
            // 
            this.modeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.squareToolStripMenuItem,
            this.hexagonToolStripMenuItem});
            this.modeToolStripMenuItem.Name = "modeToolStripMenuItem";
            this.modeToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.modeToolStripMenuItem.Text = "Mode";
            // 
            // squareToolStripMenuItem
            // 
            this.squareToolStripMenuItem.Name = "squareToolStripMenuItem";
            this.squareToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.squareToolStripMenuItem.Text = "Square";
            // 
            // hexagonToolStripMenuItem
            // 
            this.hexagonToolStripMenuItem.Name = "hexagonToolStripMenuItem";
            this.hexagonToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.hexagonToolStripMenuItem.Text = "Hexagon";
            // 
            // extraToolStripMenuItem
            // 
            this.extraToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gitHubToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.infoToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.extraToolStripMenuItem.Name = "extraToolStripMenuItem";
            this.extraToolStripMenuItem.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.extraToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.extraToolStripMenuItem.Text = "Extra";
            // 
            // gitHubToolStripMenuItem
            // 
            this.gitHubToolStripMenuItem.Name = "gitHubToolStripMenuItem";
            this.gitHubToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.gitHubToolStripMenuItem.Text = "GitHub";
            this.gitHubToolStripMenuItem.Click += new System.EventHandler(this.gitHubToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.infoToolStripMenuItem.Text = "Info";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // EntityContextMenu
            // 
            this.EntityContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chnageNameToolStripMenuItem,
            this.changeIconToolStripMenuItem,
            this.dublicateToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.EntityContextMenu.Name = "contextMenuStrip1";
            this.EntityContextMenu.Size = new System.Drawing.Size(151, 92);
            // 
            // chnageNameToolStripMenuItem
            // 
            this.chnageNameToolStripMenuItem.Name = "chnageNameToolStripMenuItem";
            this.chnageNameToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.chnageNameToolStripMenuItem.Text = "Chnage Name";
            // 
            // changeIconToolStripMenuItem
            // 
            this.changeIconToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.presetToolStripMenuItem,
            this.fileToolStripMenuItem});
            this.changeIconToolStripMenuItem.Name = "changeIconToolStripMenuItem";
            this.changeIconToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.changeIconToolStripMenuItem.Text = "Change Icon";
            // 
            // presetToolStripMenuItem
            // 
            this.presetToolStripMenuItem.Name = "presetToolStripMenuItem";
            this.presetToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.presetToolStripMenuItem.Text = "Preset";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // dublicateToolStripMenuItem
            // 
            this.dublicateToolStripMenuItem.Name = "dublicateToolStripMenuItem";
            this.dublicateToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.dublicateToolStripMenuItem.Text = "Dublicate";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // OpenFile
            // 
            this.OpenFile.FileName = "openFileDialog1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1091, 637);
            this.Controls.Add(this.MenuPanel);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Dungens & Dragons Map Maker";
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.MenuPanel.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.EntityContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button button1;
        private Panel MenuPanel;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem dateiToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem loadToolStripMenuItem;
        private ToolStripMenuItem gridToolStripMenuItem;
        private ToolStripMenuItem chnageSizeToolStripMenuItem;
        private ToolStripMenuItem extraToolStripMenuItem;
        private ToolStripMenuItem gitHubToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem infoToolStripMenuItem;
        private ToolStripMenuItem optionsToolStripMenuItem;
        private ToolStripMenuItem chnageNameToolStripMenuItem;
        private ToolStripMenuItem changeIconToolStripMenuItem;
        private ToolStripMenuItem presetToolStripMenuItem;
        private ToolStripMenuItem fileToolStripMenuItem;
        public ContextMenuStrip EntityContextMenu;
        private ToolStripMenuItem dublicateToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
        public OpenFileDialog OpenFile;
        private SaveFileDialog SaveFile;
        private ToolStripMenuItem modeToolStripMenuItem;
        private ToolStripMenuItem squareToolStripMenuItem;
        private ToolStripMenuItem hexagonToolStripMenuItem;
        private FontAwesome.Sharp.IconButton PenButton;
        private FontAwesome.Sharp.IconButton EraserButton;
    }
}