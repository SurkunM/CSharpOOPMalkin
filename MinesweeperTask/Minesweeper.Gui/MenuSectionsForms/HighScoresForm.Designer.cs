namespace Minesweeper.Gui.MenuSectionsForms
{
    partial class HighScoresForm
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
            panelHighScores = new Panel();
            linkLabel5 = new LinkLabel();
            linkLabel4 = new LinkLabel();
            linkLabel3 = new LinkLabel();
            linkLabel2 = new LinkLabel();
            linkLabel1 = new LinkLabel();
            label1 = new Label();
            panelHighScores.SuspendLayout();
            SuspendLayout();
            // 
            // panelHighScores
            // 
            panelHighScores.BackColor = SystemColors.ActiveCaption;
            panelHighScores.Controls.Add(linkLabel5);
            panelHighScores.Controls.Add(linkLabel4);
            panelHighScores.Controls.Add(linkLabel3);
            panelHighScores.Controls.Add(linkLabel2);
            panelHighScores.Controls.Add(linkLabel1);
            panelHighScores.Controls.Add(label1);
            panelHighScores.Dock = DockStyle.Fill;
            panelHighScores.Location = new Point(0, 0);
            panelHighScores.MinimumSize = new Size(270, 300);
            panelHighScores.Name = "panelHighScores";
            panelHighScores.Size = new Size(439, 421);
            panelHighScores.TabIndex = 0;
            // 
            // linkLabel5
            // 
            linkLabel5.Anchor = AnchorStyles.None;
            linkLabel5.AutoSize = true;
            linkLabel5.Location = new Point(137, 247);
            linkLabel5.Name = "linkLabel5";
            linkLabel5.Size = new Size(154, 15);
            linkLabel5.TabIndex = 6;
            linkLabel5.TabStop = true;
            linkLabel5.Text = "5 . . . . . . . . . . . . . . . . . . . . . . . ";
            // 
            // linkLabel4
            // 
            linkLabel4.Anchor = AnchorStyles.None;
            linkLabel4.AutoSize = true;
            linkLabel4.Location = new Point(137, 217);
            linkLabel4.Name = "linkLabel4";
            linkLabel4.Size = new Size(154, 15);
            linkLabel4.TabIndex = 5;
            linkLabel4.TabStop = true;
            linkLabel4.Text = "4 . . . . . . . . . . . . . . . . . . . . . . . ";
            // 
            // linkLabel3
            // 
            linkLabel3.Anchor = AnchorStyles.None;
            linkLabel3.AutoSize = true;
            linkLabel3.Location = new Point(137, 188);
            linkLabel3.Name = "linkLabel3";
            linkLabel3.Size = new Size(154, 15);
            linkLabel3.TabIndex = 4;
            linkLabel3.TabStop = true;
            linkLabel3.Text = "3 . . . . . . . . . . . . . . . . . . . . . . . ";
            // 
            // linkLabel2
            // 
            linkLabel2.Anchor = AnchorStyles.None;
            linkLabel2.AutoSize = true;
            linkLabel2.Location = new Point(137, 157);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(154, 15);
            linkLabel2.TabIndex = 3;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "2 . . . . . . . . . . . . . . . . . . . . . . . ";
            // 
            // linkLabel1
            // 
            linkLabel1.Anchor = AnchorStyles.None;
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(137, 126);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(154, 15);
            linkLabel1.TabIndex = 2;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "1 . . . . . . . . . . . . . . . . . . . . . . . ";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(137, 85);
            label1.Name = "label1";
            label1.Size = new Size(130, 30);
            label1.TabIndex = 1;
            label1.Text = "High Scores";
            // 
            // HighScoresForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(439, 421);
            Controls.Add(panelHighScores);
            FormBorderStyle = FormBorderStyle.None;
            Name = "HighScoresForm";
            StartPosition = FormStartPosition.Manual;
            Text = "HighScoresForm";
            panelHighScores.ResumeLayout(false);
            panelHighScores.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHighScores;
        private Label label1;
        private LinkLabel linkLabel1;
        private LinkLabel linkLabel5;
        private LinkLabel linkLabel4;
        private LinkLabel linkLabel3;
        private LinkLabel linkLabel2;
    }
}