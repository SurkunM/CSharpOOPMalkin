namespace Minesweeper.Gui.MenuSectionsForms
{
    partial class GameForm
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
            panelGameElements = new Panel();
            labelMinesCount = new Label();
            pictureBoxMinesCount = new PictureBox();
            buttonBackMenu = new Button();
            panelGame = new TableLayoutPanel();
            panelGameElements.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxMinesCount).BeginInit();
            SuspendLayout();
            // 
            // panelGameElements
            // 
            panelGameElements.AutoSize = true;
            panelGameElements.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelGameElements.BackColor = SystemColors.Control;
            panelGameElements.Controls.Add(labelMinesCount);
            panelGameElements.Controls.Add(pictureBoxMinesCount);
            panelGameElements.Controls.Add(buttonBackMenu);
            panelGameElements.Dock = DockStyle.Top;
            panelGameElements.Location = new Point(0, 0);
            panelGameElements.Margin = new Padding(0);
            panelGameElements.Name = "panelGameElements";
            panelGameElements.Size = new Size(235, 35);
            panelGameElements.TabIndex = 2;
            // 
            // labelMinesCount
            // 
            labelMinesCount.AutoSize = true;
            labelMinesCount.Dock = DockStyle.Right;
            labelMinesCount.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelMinesCount.Location = new Point(235, 0);
            labelMinesCount.Margin = new Padding(0);
            labelMinesCount.Name = "labelMinesCount";
            labelMinesCount.Size = new Size(0, 32);
            labelMinesCount.TabIndex = 3;
            labelMinesCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBoxMinesCount
            // 
            pictureBoxMinesCount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBoxMinesCount.ImageLocation = "";
            pictureBoxMinesCount.InitialImage = null;
            pictureBoxMinesCount.Location = new Point(148, 0);
            pictureBoxMinesCount.Margin = new Padding(0);
            pictureBoxMinesCount.Name = "pictureBoxMinesCount";
            pictureBoxMinesCount.Size = new Size(35, 35);
            pictureBoxMinesCount.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBoxMinesCount.TabIndex = 2;
            pictureBoxMinesCount.TabStop = false;
            // 
            // buttonBackMenu
            // 
            buttonBackMenu.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonBackMenu.Dock = DockStyle.Left;
            buttonBackMenu.FlatStyle = FlatStyle.System;
            buttonBackMenu.Location = new Point(0, 0);
            buttonBackMenu.Margin = new Padding(0);
            buttonBackMenu.Name = "buttonBackMenu";
            buttonBackMenu.Size = new Size(75, 35);
            buttonBackMenu.TabIndex = 0;
            buttonBackMenu.Text = "Exit Menu";
            buttonBackMenu.UseVisualStyleBackColor = true;
            buttonBackMenu.Click += ButtonBackMenuClick;
            // 
            // panelGame
            // 
            panelGame.BackColor = SystemColors.ActiveBorder;
            panelGame.BackgroundImageLayout = ImageLayout.None;
            panelGame.CausesValidation = false;
            panelGame.ColumnCount = 1;
            panelGame.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 35F));
            panelGame.Dock = DockStyle.Fill;
            panelGame.ImeMode = ImeMode.On;
            panelGame.Location = new Point(0, 35);
            panelGame.Margin = new Padding(0);
            panelGame.Name = "panelGame";
            panelGame.RowCount = 1;
            panelGame.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            panelGame.Size = new Size(235, 235);
            panelGame.TabIndex = 3;
            // 
            // GameForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(235, 270);
            Controls.Add(panelGame);
            Controls.Add(panelGameElements);
            FormBorderStyle = FormBorderStyle.None;
            Name = "GameForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "NewGame";
            WindowState = FormWindowState.Maximized;
            panelGameElements.ResumeLayout(false);
            panelGameElements.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxMinesCount).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelGameElements;
        private Label labelMinesCount;
        private PictureBox pictureBoxMinesCount;
        private Button buttonBackMenu;
        private TableLayoutPanel panelGame;
    }
}