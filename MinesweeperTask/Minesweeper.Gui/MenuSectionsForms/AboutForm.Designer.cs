namespace Minesweeper.Gui.MenuSectionsForms
{
    partial class AboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            panelAboutSection = new Panel();
            labelAboutText = new Label();
            labelHeading = new Label();
            panelAboutSection.SuspendLayout();
            SuspendLayout();
            // 
            // panelAboutSection
            // 
            panelAboutSection.AutoSize = true;
            panelAboutSection.BackColor = SystemColors.ActiveCaption;
            panelAboutSection.Controls.Add(labelAboutText);
            panelAboutSection.Controls.Add(labelHeading);
            panelAboutSection.Dock = DockStyle.Fill;
            panelAboutSection.Location = new Point(0, 0);
            panelAboutSection.Name = "panelAboutSection";
            panelAboutSection.Size = new Size(439, 421);
            panelAboutSection.TabIndex = 0;
            // 
            // labelAboutText
            // 
            labelAboutText.Anchor = AnchorStyles.Top;
            labelAboutText.AutoEllipsis = true;
            labelAboutText.BackColor = SystemColors.ActiveBorder;
            labelAboutText.BorderStyle = BorderStyle.FixedSingle;
            labelAboutText.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelAboutText.Location = new Point(12, 91);
            labelAboutText.Margin = new Padding(3);
            labelAboutText.Name = "labelAboutText";
            labelAboutText.Padding = new Padding(3);
            labelAboutText.Size = new Size(415, 201);
            labelAboutText.TabIndex = 7;
            labelAboutText.Text = resources.GetString("labelAboutText.Text");
            // 
            // labelHeading
            // 
            labelHeading.Anchor = AnchorStyles.Top;
            labelHeading.AutoSize = true;
            labelHeading.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            labelHeading.Location = new Point(138, 39);
            labelHeading.MaximumSize = new Size(190, 190);
            labelHeading.Name = "labelHeading";
            labelHeading.Size = new Size(170, 40);
            labelHeading.TabIndex = 0;
            labelHeading.Text = "About the educational project \"Minesweeper\":";
            // 
            // AboutForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(439, 421);
            Controls.Add(panelAboutSection);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AboutForm";
            Text = "AboutForm";
            panelAboutSection.ResumeLayout(false);
            panelAboutSection.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelAboutSection;
        private Label labelHeading;
        private Label labelAboutText;
    }
}