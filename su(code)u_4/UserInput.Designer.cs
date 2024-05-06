namespace su_code_u_4
{
    partial class UserInput
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserInput));
            this.label1 = new System.Windows.Forms.Label();
            this.CheckValidity = new System.Windows.Forms.Button();
            this.ShowSolution = new System.Windows.Forms.Button();
            this.PlayInputtedSudoku = new System.Windows.Forms.Button();
            this.SaveSudoku = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(568, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 165);
            this.label1.TabIndex = 0;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // CheckValidity
            // 
            this.CheckValidity.Location = new System.Drawing.Point(668, 237);
            this.CheckValidity.Name = "CheckValidity";
            this.CheckValidity.Size = new System.Drawing.Size(94, 23);
            this.CheckValidity.TabIndex = 1;
            this.CheckValidity.Text = "Check validity";
            this.CheckValidity.UseVisualStyleBackColor = true;
            this.CheckValidity.Click += new System.EventHandler(this.CheckValidity_Click);
            // 
            // ShowSolution
            // 
            this.ShowSolution.Location = new System.Drawing.Point(668, 316);
            this.ShowSolution.Name = "ShowSolution";
            this.ShowSolution.Size = new System.Drawing.Size(94, 23);
            this.ShowSolution.TabIndex = 2;
            this.ShowSolution.Text = "Show solution";
            this.ShowSolution.UseVisualStyleBackColor = true;
            this.ShowSolution.Click += new System.EventHandler(this.ShowSolution_Click);
            // 
            // PlayInputtedSudoku
            // 
            this.PlayInputtedSudoku.Location = new System.Drawing.Point(668, 345);
            this.PlayInputtedSudoku.Name = "PlayInputtedSudoku";
            this.PlayInputtedSudoku.Size = new System.Drawing.Size(94, 23);
            this.PlayInputtedSudoku.TabIndex = 3;
            this.PlayInputtedSudoku.Text = "Play sudoku";
            this.PlayInputtedSudoku.UseVisualStyleBackColor = true;
            this.PlayInputtedSudoku.Click += new System.EventHandler(this.PlayInputtedSudoku_Click);
            // 
            // SaveSudoku
            // 
            this.SaveSudoku.Location = new System.Drawing.Point(669, 374);
            this.SaveSudoku.Name = "SaveSudoku";
            this.SaveSudoku.Size = new System.Drawing.Size(93, 23);
            this.SaveSudoku.TabIndex = 4;
            this.SaveSudoku.Text = "Save";
            this.SaveSudoku.UseVisualStyleBackColor = true;
            this.SaveSudoku.Click += new System.EventHandler(this.SaveSudoku_Click);
            // 
            // UserInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 490);
            this.Controls.Add(this.SaveSudoku);
            this.Controls.Add(this.PlayInputtedSudoku);
            this.Controls.Add(this.ShowSolution);
            this.Controls.Add(this.CheckValidity);
            this.Controls.Add(this.label1);
            this.Name = "UserInput";
            this.Text = "UserInput";
            this.Load += new System.EventHandler(this.UserInput_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Button CheckValidity;
        private Button ShowSolution;
        private Button PlayInputtedSudoku;
        private Button SaveSudoku;
    }
}