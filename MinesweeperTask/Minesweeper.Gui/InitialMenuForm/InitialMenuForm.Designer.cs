namespace Minesweeper.Gui.InitialMenuForms
{
    partial class InitialMenuForm
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
            panelStartMenu = new Panel();
            labelMinesweeper = new Label();
            buttonExit = new Button();
            buttonAbout = new Button();
            buttonHighScores = new Button();
            buttonGameMenu = new Button();
            buttonStart = new Button();
            panelStartMenu.SuspendLayout();
            SuspendLayout();
            // 
            // panelStartMenu
            // 
            panelStartMenu.AutoSize = true;
            panelStartMenu.BackColor = SystemColors.ActiveCaption;
            panelStartMenu.Controls.Add(labelMinesweeper);
            panelStartMenu.Controls.Add(buttonExit);
            panelStartMenu.Controls.Add(buttonAbout);
            panelStartMenu.Controls.Add(buttonHighScores);
            panelStartMenu.Controls.Add(buttonGameMenu);
            panelStartMenu.Controls.Add(buttonStart);
            panelStartMenu.Dock = DockStyle.Fill;
            panelStartMenu.Location = new Point(0, 0);
            panelStartMenu.Name = "panelStartMenu";
            panelStartMenu.Size = new Size(439, 421);
            panelStartMenu.TabIndex = 0;
            // 
            // labelMinesweeper
            // 
            labelMinesweeper.Anchor = AnchorStyles.None;
            labelMinesweeper.AutoSize = true;
            labelMinesweeper.Font = new Font("Stencil", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelMinesweeper.Location = new Point(137, 85);
            labelMinesweeper.Name = "labelMinesweeper";
            labelMinesweeper.Size = new Size(166, 25);
            labelMinesweeper.TabIndex = 5;
            labelMinesweeper.Text = "Minesweeper";
            // 
            // buttonExit
            // 
            buttonExit.Anchor = AnchorStyles.None;
            buttonExit.Location = new Point(137, 286);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(165, 32);
            buttonExit.TabIndex = 4;
            buttonExit.Text = "Exit";
            buttonExit.UseVisualStyleBackColor = true;
            buttonExit.Click += ButtonExitClick;
            // 
            // buttonAbout
            // 
            buttonAbout.Anchor = AnchorStyles.None;
            buttonAbout.Location = new Point(137, 249);
            buttonAbout.Name = "buttonAbout";
            buttonAbout.Size = new Size(165, 32);
            buttonAbout.TabIndex = 3;
            buttonAbout.Text = "About";
            buttonAbout.UseVisualStyleBackColor = true;
            buttonAbout.Click += ButtonAboutClick;
            // 
            // buttonHighScores
            // 
            buttonHighScores.Anchor = AnchorStyles.None;
            buttonHighScores.Location = new Point(137, 167);
            buttonHighScores.Name = "buttonHighScores";
            buttonHighScores.Size = new Size(165, 32);
            buttonHighScores.TabIndex = 2;
            buttonHighScores.Text = "High Scores";
            buttonHighScores.UseVisualStyleBackColor = true;
            buttonHighScores.Click += ButtonHighScoresClick;
            // 
            // buttonGameMenu
            // 
            buttonGameMenu.Anchor = AnchorStyles.None;
            buttonGameMenu.Location = new Point(137, 208);
            buttonGameMenu.Name = "buttonGameMenu";
            buttonGameMenu.Size = new Size(165, 32);
            buttonGameMenu.TabIndex = 1;
            buttonGameMenu.Text = "Game Menu";
            buttonGameMenu.UseVisualStyleBackColor = true;
            buttonGameMenu.Click += ButtonMenuClick;
            // 
            // buttonStart
            // 
            buttonStart.Anchor = AnchorStyles.None;
            buttonStart.Location = new Point(137, 126);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(165, 32);
            buttonStart.TabIndex = 0;
            buttonStart.Text = "Start";
            buttonStart.UseVisualStyleBackColor = true;
            buttonStart.Click += ButtonStartClick;
            // 
            // StartMenuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(439, 421);
            Controls.Add(panelStartMenu);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "StartMenuForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Minesweeper";
            panelStartMenu.ResumeLayout(false);
            panelStartMenu.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelStartMenu;

        private Button buttonStart;
        private Button buttonHighScores;
        private Button buttonGameMenu;
        private Button buttonAbout;
        private Button buttonExit;

        private Label labelMinesweeper;
    }
}
