namespace su_code_u_4
{
    partial class UserGame
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
            this.helpOrNoHelp = new System.Windows.Forms.GroupBox();
            this.noHelpRadioButton = new System.Windows.Forms.RadioButton();
            this.helpRadioButton = new System.Windows.Forms.RadioButton();
            this.GetValueButton = new System.Windows.Forms.Button();
            this.completedSudoku = new System.Windows.Forms.Label();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.randomSudokuFromFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GenerateNewSudokuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.easyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mediumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openLastSavedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inputSudokuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gameMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.solveGameMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetGameMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpOrNoHelp.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // helpOrNoHelp
            // 
            this.helpOrNoHelp.Controls.Add(this.noHelpRadioButton);
            this.helpOrNoHelp.Controls.Add(this.helpRadioButton);
            this.helpOrNoHelp.Location = new System.Drawing.Point(687, 37);
            this.helpOrNoHelp.Name = "helpOrNoHelp";
            this.helpOrNoHelp.Size = new System.Drawing.Size(77, 67);
            this.helpOrNoHelp.TabIndex = 0;
            this.helpOrNoHelp.TabStop = false;
            // 
            // noHelpRadioButton
            // 
            this.noHelpRadioButton.AutoSize = true;
            this.noHelpRadioButton.Location = new System.Drawing.Point(6, 38);
            this.noHelpRadioButton.Name = "noHelpRadioButton";
            this.noHelpRadioButton.Size = new System.Drawing.Size(65, 19);
            this.noHelpRadioButton.TabIndex = 1;
            this.noHelpRadioButton.TabStop = true;
            this.noHelpRadioButton.Text = "no help";
            this.noHelpRadioButton.UseVisualStyleBackColor = true;
            this.noHelpRadioButton.CheckedChanged += new System.EventHandler(this.NoHelpRadioButton_CheckedChanged);
            // 
            // helpRadioButton
            // 
            this.helpRadioButton.AutoSize = true;
            this.helpRadioButton.Location = new System.Drawing.Point(6, 13);
            this.helpRadioButton.Name = "helpRadioButton";
            this.helpRadioButton.Size = new System.Drawing.Size(48, 19);
            this.helpRadioButton.TabIndex = 0;
            this.helpRadioButton.TabStop = true;
            this.helpRadioButton.Text = "help";
            this.helpRadioButton.UseVisualStyleBackColor = true;
            this.helpRadioButton.CheckedChanged += new System.EventHandler(this.HelpRadioButton_CheckedChanged);
            // 
            // GetValueButton
            // 
            this.GetValueButton.Location = new System.Drawing.Point(687, 110);
            this.GetValueButton.Name = "GetValueButton";
            this.GetValueButton.Size = new System.Drawing.Size(77, 23);
            this.GetValueButton.TabIndex = 1;
            this.GetValueButton.Text = "Get value";
            this.GetValueButton.UseVisualStyleBackColor = true;
            this.GetValueButton.Click += new System.EventHandler(this.GetValueButton_Click);
            // 
            // completedSudoku
            // 
            this.completedSudoku.AutoSize = true;
            this.completedSudoku.Location = new System.Drawing.Point(653, 470);
            this.completedSudoku.Name = "completedSudoku";
            this.completedSudoku.Size = new System.Drawing.Size(135, 15);
            this.completedSudoku.TabIndex = 5;
            this.completedSudoku.Text = "The sudoku is complete!";
            this.completedSudoku.Visible = false;
            // 
            // menuStrip
            // 
            this.menuStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.gameMenu});
            this.menuStrip.Location = new System.Drawing.Point(470, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(228, 24);
            this.menuStrip.TabIndex = 6;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.openLastSavedToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.inputSudokuToolStripMenuItem});
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(50, 20);
            this.fileMenu.Text = "Menu";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.randomSudokuFromFileMenuItem,
            this.GenerateNewSudokuToolStripMenuItem});
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newGameToolStripMenuItem.Text = "New Game";
            // 
            // randomSudokuFromFileMenuItem
            // 
            this.randomSudokuFromFileMenuItem.Name = "randomSudokuFromFileMenuItem";
            this.randomSudokuFromFileMenuItem.Size = new System.Drawing.Size(188, 22);
            this.randomSudokuFromFileMenuItem.Text = "Random";
            this.randomSudokuFromFileMenuItem.Click += new System.EventHandler(this.RandomSudokuFromFileMenuItem_Click);
            // 
            // GenerateNewSudokuToolStripMenuItem
            // 
            this.GenerateNewSudokuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.easyToolStripMenuItem,
            this.mediumToolStripMenuItem,
            this.hardToolStripMenuItem});
            this.GenerateNewSudokuToolStripMenuItem.Name = "GenerateNewSudokuToolStripMenuItem";
            this.GenerateNewSudokuToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.GenerateNewSudokuToolStripMenuItem.Text = "Generate new sudoku";
            // 
            // easyToolStripMenuItem
            // 
            this.easyToolStripMenuItem.Name = "easyToolStripMenuItem";
            this.easyToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.easyToolStripMenuItem.Text = "Easy";
            this.easyToolStripMenuItem.Click += new System.EventHandler(this.EasyToolStripMenuItem_Click);
            // 
            // mediumToolStripMenuItem
            // 
            this.mediumToolStripMenuItem.Name = "mediumToolStripMenuItem";
            this.mediumToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.mediumToolStripMenuItem.Text = "Medium";
            this.mediumToolStripMenuItem.Click += new System.EventHandler(this.MediumToolStripMenuItem_Click);
            // 
            // hardToolStripMenuItem
            // 
            this.hardToolStripMenuItem.Name = "hardToolStripMenuItem";
            this.hardToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.hardToolStripMenuItem.Text = "Hard";
            this.hardToolStripMenuItem.Click += new System.EventHandler(this.HardToolStripMenuItem_Click);
            // 
            // openLastSavedToolStripMenuItem
            // 
            this.openLastSavedToolStripMenuItem.Name = "openLastSavedToolStripMenuItem";
            this.openLastSavedToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openLastSavedToolStripMenuItem.Text = "Open Last Saved";
            this.openLastSavedToolStripMenuItem.Click += new System.EventHandler(this.OpenLastSavedToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // inputSudokuToolStripMenuItem
            // 
            this.inputSudokuToolStripMenuItem.Name = "inputSudokuToolStripMenuItem";
            this.inputSudokuToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.inputSudokuToolStripMenuItem.Text = "Input Sudoku";
            this.inputSudokuToolStripMenuItem.Click += new System.EventHandler(this.InputSudokuToolStripMenuItem_Click);
            // 
            // gameMenu
            // 
            this.gameMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.solveGameMenuItem,
            this.resetGameMenuItem});
            this.gameMenu.Name = "gameMenu";
            this.gameMenu.Size = new System.Drawing.Size(50, 20);
            this.gameMenu.Text = "Game";
            // 
            // solveGameMenuItem
            // 
            this.solveGameMenuItem.Name = "solveGameMenuItem";
            this.solveGameMenuItem.Size = new System.Drawing.Size(149, 22);
            this.solveGameMenuItem.Text = "Show solution";
            this.solveGameMenuItem.Click += new System.EventHandler(this.SolveGameMenuItem_Click);
            // 
            // resetGameMenuItem
            // 
            this.resetGameMenuItem.Name = "resetGameMenuItem";
            this.resetGameMenuItem.Size = new System.Drawing.Size(149, 22);
            this.resetGameMenuItem.Text = "Reset";
            this.resetGameMenuItem.Click += new System.EventHandler(this.ResetGameMenuItem_Click);
            // 
            // UserGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 494);
            this.Controls.Add(this.completedSudoku);
            this.Controls.Add(this.GetValueButton);
            this.Controls.Add(this.helpOrNoHelp);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "UserGame";
            this.Text = "UserGame";
            this.Load += new System.EventHandler(this.UserGame_Load);
            this.helpOrNoHelp.ResumeLayout(false);
            this.helpOrNoHelp.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox helpOrNoHelp;
        private RadioButton noHelpRadioButton;
        private RadioButton helpRadioButton;
        private Button GetValueButton;
        private Label completedSudoku;
        private MenuStrip menuStrip;
        private ToolStripMenuItem fileMenu;
        private ToolStripMenuItem gameMenu;
        private ToolStripMenuItem solveGameMenuItem;
        private ToolStripMenuItem resetGameMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem newGameToolStripMenuItem;
        private ToolStripMenuItem randomSudokuFromFileMenuItem;
        private ToolStripMenuItem inputSudokuToolStripMenuItem;
        private ToolStripMenuItem openLastSavedToolStripMenuItem;
        private ToolStripMenuItem GenerateNewSudokuToolStripMenuItem;
        private ToolStripMenuItem easyToolStripMenuItem;
        private ToolStripMenuItem mediumToolStripMenuItem;
        private ToolStripMenuItem hardToolStripMenuItem;
    }
}