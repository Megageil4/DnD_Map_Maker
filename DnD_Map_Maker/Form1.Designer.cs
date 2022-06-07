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
            this.MenuPanel = new System.Windows.Forms.Panel();
            this.AddEntity = new FontAwesome.Sharp.IconButton();
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
            this.AddEntityContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.playerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paladinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.figtherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clericToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.babaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rogueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rangerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.druidToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sorcererToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.warlockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wizardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enemyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enemy1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enemy2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enemy3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enemy4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enemy5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.boss1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.boss2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dragonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.door1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dorr2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stairsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bonfireToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wellToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.johanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.vogelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuPanel.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.EntityContextMenu.SuspendLayout();
            this.AddEntityContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuPanel
            // 
            this.MenuPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.MenuPanel.Controls.Add(this.AddEntity);
            this.MenuPanel.Controls.Add(this.EraserButton);
            this.MenuPanel.Controls.Add(this.PenButton);
            this.MenuPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.MenuPanel.Location = new System.Drawing.Point(0, 24);
            this.MenuPanel.Name = "MenuPanel";
            this.MenuPanel.Size = new System.Drawing.Size(100, 613);
            this.MenuPanel.TabIndex = 2;
            // 
            // AddEntity
            // 
            this.AddEntity.FlatAppearance.BorderSize = 0;
            this.AddEntity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddEntity.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.AddEntity.IconColor = System.Drawing.Color.Black;
            this.AddEntity.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.AddEntity.Location = new System.Drawing.Point(24, 16);
            this.AddEntity.Name = "AddEntity";
            this.AddEntity.Size = new System.Drawing.Size(54, 49);
            this.AddEntity.TabIndex = 4;
            this.AddEntity.UseVisualStyleBackColor = true;
            this.AddEntity.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AddEntity_MouseDown);
            // 
            // EraserButton
            // 
            this.EraserButton.FlatAppearance.BorderSize = 0;
            this.EraserButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EraserButton.IconChar = FontAwesome.Sharp.IconChar.Eraser;
            this.EraserButton.IconColor = System.Drawing.Color.Black;
            this.EraserButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.EraserButton.Location = new System.Drawing.Point(24, 181);
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
            this.PenButton.Location = new System.Drawing.Point(24, 98);
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
            // AddEntityContextMenu
            // 
            this.AddEntityContextMenu.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.AddEntityContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem1,
            this.playerToolStripMenuItem,
            this.enemyToolStripMenuItem,
            this.otherToolStripMenuItem,
            this.customToolStripMenuItem});
            this.AddEntityContextMenu.Name = "contextMenuStrip1";
            this.AddEntityContextMenu.Size = new System.Drawing.Size(181, 136);
            // 
            // playerToolStripMenuItem
            // 
            this.playerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.paladinToolStripMenuItem,
            this.figtherToolStripMenuItem,
            this.clericToolStripMenuItem,
            this.babaToolStripMenuItem,
            this.rogueToolStripMenuItem,
            this.monkToolStripMenuItem,
            this.rangerToolStripMenuItem,
            this.bardToolStripMenuItem,
            this.druidToolStripMenuItem,
            this.sorcererToolStripMenuItem,
            this.warlockToolStripMenuItem,
            this.wizardToolStripMenuItem});
            this.playerToolStripMenuItem.Name = "playerToolStripMenuItem";
            this.playerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.playerToolStripMenuItem.Text = "Player";
            // 
            // paladinToolStripMenuItem
            // 
            this.paladinToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.paladinToolStripMenuItem.Image = global::DnD_Map_Maker.Properties.Resources.Paladin;
            this.paladinToolStripMenuItem.Name = "paladinToolStripMenuItem";
            this.paladinToolStripMenuItem.Size = new System.Drawing.Size(204, 46);
            this.paladinToolStripMenuItem.Text = "Paladin";
            this.paladinToolStripMenuItem.Click += new System.EventHandler(this.paladinToolStripMenuItem_Click);
            // 
            // figtherToolStripMenuItem
            // 
            this.figtherToolStripMenuItem.Image = global::DnD_Map_Maker.Properties.Resources.Fighter;
            this.figtherToolStripMenuItem.Name = "figtherToolStripMenuItem";
            this.figtherToolStripMenuItem.Size = new System.Drawing.Size(204, 46);
            this.figtherToolStripMenuItem.Text = "Figther";
            this.figtherToolStripMenuItem.Click += new System.EventHandler(this.figtherToolStripMenuItem_Click);
            // 
            // clericToolStripMenuItem
            // 
            this.clericToolStripMenuItem.Image = global::DnD_Map_Maker.Properties.Resources.Cleric;
            this.clericToolStripMenuItem.Name = "clericToolStripMenuItem";
            this.clericToolStripMenuItem.Size = new System.Drawing.Size(204, 46);
            this.clericToolStripMenuItem.Text = "Cleric";
            this.clericToolStripMenuItem.Click += new System.EventHandler(this.clericToolStripMenuItem_Click);
            // 
            // babaToolStripMenuItem
            // 
            this.babaToolStripMenuItem.Image = global::DnD_Map_Maker.Properties.Resources.Barbarian;
            this.babaToolStripMenuItem.Name = "babaToolStripMenuItem";
            this.babaToolStripMenuItem.Size = new System.Drawing.Size(204, 46);
            this.babaToolStripMenuItem.Text = "Babarian";
            this.babaToolStripMenuItem.Click += new System.EventHandler(this.babaToolStripMenuItem_Click);
            // 
            // rogueToolStripMenuItem
            // 
            this.rogueToolStripMenuItem.Image = global::DnD_Map_Maker.Properties.Resources.Rogue;
            this.rogueToolStripMenuItem.Name = "rogueToolStripMenuItem";
            this.rogueToolStripMenuItem.Size = new System.Drawing.Size(204, 46);
            this.rogueToolStripMenuItem.Text = "Rogue";
            this.rogueToolStripMenuItem.Click += new System.EventHandler(this.rogueToolStripMenuItem_Click);
            // 
            // monkToolStripMenuItem
            // 
            this.monkToolStripMenuItem.Image = global::DnD_Map_Maker.Properties.Resources.Monk;
            this.monkToolStripMenuItem.Name = "monkToolStripMenuItem";
            this.monkToolStripMenuItem.Size = new System.Drawing.Size(204, 46);
            this.monkToolStripMenuItem.Text = "Monk";
            this.monkToolStripMenuItem.Click += new System.EventHandler(this.monkToolStripMenuItem_Click);
            // 
            // rangerToolStripMenuItem
            // 
            this.rangerToolStripMenuItem.Image = global::DnD_Map_Maker.Properties.Resources.Ranger;
            this.rangerToolStripMenuItem.Name = "rangerToolStripMenuItem";
            this.rangerToolStripMenuItem.Size = new System.Drawing.Size(204, 46);
            this.rangerToolStripMenuItem.Text = "Ranger";
            this.rangerToolStripMenuItem.Click += new System.EventHandler(this.rangerToolStripMenuItem_Click);
            // 
            // bardToolStripMenuItem
            // 
            this.bardToolStripMenuItem.Image = global::DnD_Map_Maker.Properties.Resources.Bard;
            this.bardToolStripMenuItem.Name = "bardToolStripMenuItem";
            this.bardToolStripMenuItem.Size = new System.Drawing.Size(204, 46);
            this.bardToolStripMenuItem.Text = "Bard";
            this.bardToolStripMenuItem.Click += new System.EventHandler(this.bardToolStripMenuItem_Click);
            // 
            // druidToolStripMenuItem
            // 
            this.druidToolStripMenuItem.Image = global::DnD_Map_Maker.Properties.Resources.Druid;
            this.druidToolStripMenuItem.Name = "druidToolStripMenuItem";
            this.druidToolStripMenuItem.Size = new System.Drawing.Size(204, 46);
            this.druidToolStripMenuItem.Text = "Druid";
            this.druidToolStripMenuItem.Click += new System.EventHandler(this.druidToolStripMenuItem_Click);
            // 
            // sorcererToolStripMenuItem
            // 
            this.sorcererToolStripMenuItem.Image = global::DnD_Map_Maker.Properties.Resources.Sorcerer;
            this.sorcererToolStripMenuItem.Name = "sorcererToolStripMenuItem";
            this.sorcererToolStripMenuItem.Size = new System.Drawing.Size(204, 46);
            this.sorcererToolStripMenuItem.Text = "Sorcerer";
            this.sorcererToolStripMenuItem.Click += new System.EventHandler(this.sorcererToolStripMenuItem_Click);
            // 
            // warlockToolStripMenuItem
            // 
            this.warlockToolStripMenuItem.Image = global::DnD_Map_Maker.Properties.Resources.Warlock;
            this.warlockToolStripMenuItem.Name = "warlockToolStripMenuItem";
            this.warlockToolStripMenuItem.Size = new System.Drawing.Size(204, 46);
            this.warlockToolStripMenuItem.Text = "Warlock";
            this.warlockToolStripMenuItem.Click += new System.EventHandler(this.warlockToolStripMenuItem_Click);
            // 
            // wizardToolStripMenuItem
            // 
            this.wizardToolStripMenuItem.Image = global::DnD_Map_Maker.Properties.Resources.Wizard;
            this.wizardToolStripMenuItem.Name = "wizardToolStripMenuItem";
            this.wizardToolStripMenuItem.Size = new System.Drawing.Size(204, 46);
            this.wizardToolStripMenuItem.Text = "Wizard";
            this.wizardToolStripMenuItem.Click += new System.EventHandler(this.wizardToolStripMenuItem_Click);
            // 
            // enemyToolStripMenuItem
            // 
            this.enemyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enemy1ToolStripMenuItem,
            this.enemy2ToolStripMenuItem,
            this.enemy3ToolStripMenuItem,
            this.enemy4ToolStripMenuItem,
            this.enemy5ToolStripMenuItem,
            this.boss1ToolStripMenuItem,
            this.boss2ToolStripMenuItem,
            this.dragonToolStripMenuItem});
            this.enemyToolStripMenuItem.Name = "enemyToolStripMenuItem";
            this.enemyToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.enemyToolStripMenuItem.Text = "Enemy";
            // 
            // enemy1ToolStripMenuItem
            // 
            this.enemy1ToolStripMenuItem.Image = global::DnD_Map_Maker.Properties.Resources.Enemy1;
            this.enemy1ToolStripMenuItem.Name = "enemy1ToolStripMenuItem";
            this.enemy1ToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.enemy1ToolStripMenuItem.Text = "Enemy1";
            this.enemy1ToolStripMenuItem.Click += new System.EventHandler(this.enemy1ToolStripMenuItem_Click);
            // 
            // enemy2ToolStripMenuItem
            // 
            this.enemy2ToolStripMenuItem.Image = global::DnD_Map_Maker.Properties.Resources.Enemy2;
            this.enemy2ToolStripMenuItem.Name = "enemy2ToolStripMenuItem";
            this.enemy2ToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.enemy2ToolStripMenuItem.Text = "Enemy2";
            this.enemy2ToolStripMenuItem.Click += new System.EventHandler(this.enemy2ToolStripMenuItem_Click);
            // 
            // enemy3ToolStripMenuItem
            // 
            this.enemy3ToolStripMenuItem.Image = global::DnD_Map_Maker.Properties.Resources.Enemy3;
            this.enemy3ToolStripMenuItem.Name = "enemy3ToolStripMenuItem";
            this.enemy3ToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.enemy3ToolStripMenuItem.Text = "Enemy3";
            this.enemy3ToolStripMenuItem.Click += new System.EventHandler(this.enemy3ToolStripMenuItem_Click);
            // 
            // enemy4ToolStripMenuItem
            // 
            this.enemy4ToolStripMenuItem.Image = global::DnD_Map_Maker.Properties.Resources.Enemy4;
            this.enemy4ToolStripMenuItem.Name = "enemy4ToolStripMenuItem";
            this.enemy4ToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.enemy4ToolStripMenuItem.Text = "Enemy4";
            this.enemy4ToolStripMenuItem.Click += new System.EventHandler(this.enemy4ToolStripMenuItem_Click);
            // 
            // enemy5ToolStripMenuItem
            // 
            this.enemy5ToolStripMenuItem.Image = global::DnD_Map_Maker.Properties.Resources.Basic_Bad_Bitch;
            this.enemy5ToolStripMenuItem.Name = "enemy5ToolStripMenuItem";
            this.enemy5ToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.enemy5ToolStripMenuItem.Text = "Enemy5";
            this.enemy5ToolStripMenuItem.Click += new System.EventHandler(this.enemy5ToolStripMenuItem_Click);
            // 
            // boss1ToolStripMenuItem
            // 
            this.boss1ToolStripMenuItem.Image = global::DnD_Map_Maker.Properties.Resources.Boss1;
            this.boss1ToolStripMenuItem.Name = "boss1ToolStripMenuItem";
            this.boss1ToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.boss1ToolStripMenuItem.Text = "Boss1";
            this.boss1ToolStripMenuItem.Click += new System.EventHandler(this.boss1ToolStripMenuItem_Click);
            // 
            // boss2ToolStripMenuItem
            // 
            this.boss2ToolStripMenuItem.Image = global::DnD_Map_Maker.Properties.Resources.Boss2;
            this.boss2ToolStripMenuItem.Name = "boss2ToolStripMenuItem";
            this.boss2ToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.boss2ToolStripMenuItem.Text = "Boss2";
            this.boss2ToolStripMenuItem.Click += new System.EventHandler(this.boss2ToolStripMenuItem_Click);
            // 
            // dragonToolStripMenuItem
            // 
            this.dragonToolStripMenuItem.Image = global::DnD_Map_Maker.Properties.Resources.Rawwwww;
            this.dragonToolStripMenuItem.Name = "dragonToolStripMenuItem";
            this.dragonToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.dragonToolStripMenuItem.Text = "Dragon";
            this.dragonToolStripMenuItem.Click += new System.EventHandler(this.dragonToolStripMenuItem_Click);
            // 
            // otherToolStripMenuItem
            // 
            this.otherToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.door1ToolStripMenuItem,
            this.dorr2ToolStripMenuItem,
            this.stairsToolStripMenuItem,
            this.bonfireToolStripMenuItem,
            this.wellToolStripMenuItem});
            this.otherToolStripMenuItem.Name = "otherToolStripMenuItem";
            this.otherToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.otherToolStripMenuItem.Text = "Other";
            // 
            // door1ToolStripMenuItem
            // 
            this.door1ToolStripMenuItem.Image = global::DnD_Map_Maker.Properties.Resources.Door;
            this.door1ToolStripMenuItem.Name = "door1ToolStripMenuItem";
            this.door1ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.door1ToolStripMenuItem.Text = "Door1";
            this.door1ToolStripMenuItem.Click += new System.EventHandler(this.door1ToolStripMenuItem_Click);
            // 
            // dorr2ToolStripMenuItem
            // 
            this.dorr2ToolStripMenuItem.Image = global::DnD_Map_Maker.Properties.Resources.You_expectet_a_Joke__but_it_was_me_Dio1;
            this.dorr2ToolStripMenuItem.Name = "dorr2ToolStripMenuItem";
            this.dorr2ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.dorr2ToolStripMenuItem.Text = "Door2";
            this.dorr2ToolStripMenuItem.Click += new System.EventHandler(this.dorr2ToolStripMenuItem_Click);
            // 
            // stairsToolStripMenuItem
            // 
            this.stairsToolStripMenuItem.Image = global::DnD_Map_Maker.Properties.Resources.Stairs;
            this.stairsToolStripMenuItem.Name = "stairsToolStripMenuItem";
            this.stairsToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.stairsToolStripMenuItem.Text = "Stairs";
            this.stairsToolStripMenuItem.Click += new System.EventHandler(this.stairsToolStripMenuItem_Click);
            // 
            // bonfireToolStripMenuItem
            // 
            this.bonfireToolStripMenuItem.Image = global::DnD_Map_Maker.Properties.Resources.Take_a_rest1;
            this.bonfireToolStripMenuItem.Name = "bonfireToolStripMenuItem";
            this.bonfireToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.bonfireToolStripMenuItem.Text = "Bonfire";
            this.bonfireToolStripMenuItem.Click += new System.EventHandler(this.bonfireToolStripMenuItem_Click);
            // 
            // wellToolStripMenuItem
            // 
            this.wellToolStripMenuItem.Image = global::DnD_Map_Maker.Properties.Resources.Get_Wel_soon1;
            this.wellToolStripMenuItem.Name = "wellToolStripMenuItem";
            this.wellToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.wellToolStripMenuItem.Text = "Well";
            this.wellToolStripMenuItem.Click += new System.EventHandler(this.wellToolStripMenuItem_Click);
            // 
            // customToolStripMenuItem
            // 
            this.customToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.johanToolStripMenuItem,
            this.customToolStripMenuItem1,
            this.vogelToolStripMenuItem,
            this.gayToolStripMenuItem});
            this.customToolStripMenuItem.Name = "customToolStripMenuItem";
            this.customToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.customToolStripMenuItem.Text = "Custom";
            // 
            // johanToolStripMenuItem
            // 
            this.johanToolStripMenuItem.Image = global::DnD_Map_Maker.Properties.Resources.b_in_Hans_steht_für_balanced;
            this.johanToolStripMenuItem.Name = "johanToolStripMenuItem";
            this.johanToolStripMenuItem.Size = new System.Drawing.Size(204, 46);
            this.johanToolStripMenuItem.Text = "Balanced";
            this.johanToolStripMenuItem.Click += new System.EventHandler(this.johanToolStripMenuItem_Click);
            // 
            // customToolStripMenuItem1
            // 
            this.customToolStripMenuItem1.Image = global::DnD_Map_Maker.Properties.Resources.Basic_Bitch;
            this.customToolStripMenuItem1.Name = "customToolStripMenuItem1";
            this.customToolStripMenuItem1.Size = new System.Drawing.Size(204, 46);
            this.customToolStripMenuItem1.Text = "Basic Bitch";
            this.customToolStripMenuItem1.Click += new System.EventHandler(this.customToolStripMenuItem1_Click);
            // 
            // vogelToolStripMenuItem
            // 
            this.vogelToolStripMenuItem.Image = global::DnD_Map_Maker.Properties.Resources.Daniel_and_Dragons;
            this.vogelToolStripMenuItem.Name = "vogelToolStripMenuItem";
            this.vogelToolStripMenuItem.Size = new System.Drawing.Size(204, 46);
            this.vogelToolStripMenuItem.Text = "Vogel";
            this.vogelToolStripMenuItem.Click += new System.EventHandler(this.vogelToolStripMenuItem_Click);
            // 
            // gayToolStripMenuItem
            // 
            this.gayToolStripMenuItem.Image = global::DnD_Map_Maker.Properties.Resources.Its_ya_boy;
            this.gayToolStripMenuItem.Name = "gayToolStripMenuItem";
            this.gayToolStripMenuItem.Size = new System.Drawing.Size(204, 46);
            this.gayToolStripMenuItem.Text = "Gay";
            this.gayToolStripMenuItem.Click += new System.EventHandler(this.gayToolStripMenuItem_Click);
            // 
            // newToolStripMenuItem1
            // 
            this.newToolStripMenuItem1.Name = "newToolStripMenuItem1";
            this.newToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.newToolStripMenuItem1.Text = "New";
            this.newToolStripMenuItem1.Click += new System.EventHandler(this.newToolStripMenuItem1_Click);
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
            this.AddEntityContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
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
        private FontAwesome.Sharp.IconButton AddEntity;
        private ContextMenuStrip AddEntityContextMenu;
        private ToolStripMenuItem playerToolStripMenuItem;
        private ToolStripMenuItem paladinToolStripMenuItem;
        private ToolStripMenuItem figtherToolStripMenuItem;
        private ToolStripMenuItem clericToolStripMenuItem;
        private ToolStripMenuItem babaToolStripMenuItem;
        private ToolStripMenuItem rogueToolStripMenuItem;
        private ToolStripMenuItem monkToolStripMenuItem;
        private ToolStripMenuItem rangerToolStripMenuItem;
        private ToolStripMenuItem bardToolStripMenuItem;
        private ToolStripMenuItem druidToolStripMenuItem;
        private ToolStripMenuItem sorcererToolStripMenuItem;
        private ToolStripMenuItem warlockToolStripMenuItem;
        private ToolStripMenuItem wizardToolStripMenuItem;
        private ToolStripMenuItem enemyToolStripMenuItem;
        private ToolStripMenuItem otherToolStripMenuItem;
        private ToolStripMenuItem enemy1ToolStripMenuItem;
        private ToolStripMenuItem enemy2ToolStripMenuItem;
        private ToolStripMenuItem enemy3ToolStripMenuItem;
        private ToolStripMenuItem enemy4ToolStripMenuItem;
        private ToolStripMenuItem enemy5ToolStripMenuItem;
        private ToolStripMenuItem boss1ToolStripMenuItem;
        private ToolStripMenuItem boss2ToolStripMenuItem;
        private ToolStripMenuItem dragonToolStripMenuItem;
        private ToolStripMenuItem door1ToolStripMenuItem;
        private ToolStripMenuItem dorr2ToolStripMenuItem;
        private ToolStripMenuItem stairsToolStripMenuItem;
        private ToolStripMenuItem bonfireToolStripMenuItem;
        private ToolStripMenuItem wellToolStripMenuItem;
        private ToolStripMenuItem customToolStripMenuItem;
        private ToolStripMenuItem johanToolStripMenuItem;
        private ToolStripMenuItem customToolStripMenuItem1;
        private ToolStripMenuItem vogelToolStripMenuItem;
        private ToolStripMenuItem gayToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem1;
    }
}