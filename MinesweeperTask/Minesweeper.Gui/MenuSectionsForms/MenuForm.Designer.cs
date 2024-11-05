namespace Minesweeper.Gui.MenuSectionsForms
{
    partial class MenuForm
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
            panelGameMenu = new Panel();
            comboBoxColumnsCount = new ComboBox();
            labelColumnCount = new Label();
            buttonSetConfigurations = new Button();
            comboBoxMinesCount = new ComboBox();
            label3 = new Label();
            labelRowCount = new Label();
            comboBoxRowsCount = new ComboBox();
            label1 = new Label();
            labelChangesSaved = new Label();
            panelGameMenu.SuspendLayout();
            SuspendLayout();
            // 
            // panelGameMenu
            // 
            panelGameMenu.BackColor = SystemColors.ActiveCaption;
            panelGameMenu.Controls.Add(labelChangesSaved);
            panelGameMenu.Controls.Add(comboBoxColumnsCount);
            panelGameMenu.Controls.Add(labelColumnCount);
            panelGameMenu.Controls.Add(buttonSetConfigurations);
            panelGameMenu.Controls.Add(comboBoxMinesCount);
            panelGameMenu.Controls.Add(label3);
            panelGameMenu.Controls.Add(labelRowCount);
            panelGameMenu.Controls.Add(comboBoxRowsCount);
            panelGameMenu.Controls.Add(label1);
            panelGameMenu.Dock = DockStyle.Fill;
            panelGameMenu.Location = new Point(0, 0);
            panelGameMenu.MinimumSize = new Size(415, 300);
            panelGameMenu.Name = "panelGameMenu";
            panelGameMenu.Size = new Size(439, 421);
            panelGameMenu.TabIndex = 0;
            // 
            // comboBoxColumnsCount
            // 
            comboBoxColumnsCount.Anchor = AnchorStyles.None;
            comboBoxColumnsCount.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxColumnsCount.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 204);
            comboBoxColumnsCount.FormattingEnabled = true;
            comboBoxColumnsCount.Location = new Point(285, 175);
            comboBoxColumnsCount.Name = "comboBoxColumnsCount";
            comboBoxColumnsCount.Size = new Size(65, 25);
            comboBoxColumnsCount.TabIndex = 8;
            comboBoxColumnsCount.SelectedIndexChanged += ComboBoxColumnsCountSelectedItemChanged;
            // 
            // labelColumnCount
            // 
            labelColumnCount.Anchor = AnchorStyles.None;
            labelColumnCount.AutoSize = true;
            labelColumnCount.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelColumnCount.Location = new Point(85, 176);
            labelColumnCount.Name = "labelColumnCount";
            labelColumnCount.Size = new Size(197, 20);
            labelColumnCount.TabIndex = 7;
            labelColumnCount.Text = "Select the count of columns";
            // 
            // buttonSetConfigurations
            // 
            buttonSetConfigurations.Anchor = AnchorStyles.None;
            buttonSetConfigurations.Location = new Point(85, 269);
            buttonSetConfigurations.Name = "buttonSetConfigurations";
            buttonSetConfigurations.Size = new Size(86, 30);
            buttonSetConfigurations.TabIndex = 6;
            buttonSetConfigurations.Text = "OK";
            buttonSetConfigurations.UseVisualStyleBackColor = true;
            buttonSetConfigurations.Click += ButtonSetConfigurationsClick;
            // 
            // comboBoxMinesCount
            // 
            comboBoxMinesCount.Anchor = AnchorStyles.None;
            comboBoxMinesCount.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMinesCount.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 204);
            comboBoxMinesCount.FormattingEnabled = true;
            comboBoxMinesCount.Location = new Point(285, 214);
            comboBoxMinesCount.Name = "comboBoxMinesCount";
            comboBoxMinesCount.Size = new Size(65, 25);
            comboBoxMinesCount.TabIndex = 5;
            comboBoxMinesCount.SelectedIndexChanged += ComboBoxMineCountSelectedItemChanged;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            label3.Location = new Point(85, 215);
            label3.Name = "label3";
            label3.Size = new Size(180, 20);
            label3.TabIndex = 4;
            label3.Text = "Select the count of mines";
            // 
            // labelRowCount
            // 
            labelRowCount.Anchor = AnchorStyles.None;
            labelRowCount.AutoSize = true;
            labelRowCount.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelRowCount.Location = new Point(85, 134);
            labelRowCount.Name = "labelRowCount";
            labelRowCount.Size = new Size(172, 20);
            labelRowCount.TabIndex = 3;
            labelRowCount.Text = "Select the count of rows";
            // 
            // comboBoxRowsCount
            // 
            comboBoxRowsCount.Anchor = AnchorStyles.None;
            comboBoxRowsCount.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxRowsCount.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 204);
            comboBoxRowsCount.FormattingEnabled = true;
            comboBoxRowsCount.Location = new Point(285, 133);
            comboBoxRowsCount.Name = "comboBoxRowsCount";
            comboBoxRowsCount.Size = new Size(65, 25);
            comboBoxRowsCount.TabIndex = 2;
            comboBoxRowsCount.SelectedIndexChanged += ComboBoxRowColumnCountSelectedItemChanged;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(137, 85);
            label1.Name = "label1";
            label1.Size = new Size(132, 30);
            label1.TabIndex = 1;
            label1.Text = "Game Menu";
            // 
            // labelChangesSaved
            // 
            labelChangesSaved.Anchor = AnchorStyles.None;
            labelChangesSaved.AutoSize = true;
            labelChangesSaved.ForeColor = Color.ForestGreen;
            labelChangesSaved.Location = new Point(195, 277);
            labelChangesSaved.Name = "labelChangesSaved";
            labelChangesSaved.Size = new Size(0, 15);
            labelChangesSaved.TabIndex = 9;
            // 
            // MenuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(439, 421);
            Controls.Add(panelGameMenu);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MenuForm";
            Text = "MenuForm";
            panelGameMenu.ResumeLayout(false);
            panelGameMenu.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelGameMenu;
        private Label label1;
        private ComboBox comboBoxRowsCount;
        private Label labelRowCount;
        private Label label3;
        private ComboBox comboBoxMinesCount;
        private Label labelColumnCount;
        private Button buttonSetConfigurations;
        private ComboBox comboBoxColumnsCount;
        private Label labelChangesSaved;
    }
}