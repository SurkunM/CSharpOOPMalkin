namespace TemperatureTask
{
    partial class TemperatureForm
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
            panelTemperatureConverter = new Panel();
            labelResultValue = new Label();
            labelResultText = new Label();
            comboBoxNewScale = new ComboBox();
            labelNewScaleText = new Label();
            labelEnterTemperature = new Label();
            labelCurrentScaleText = new Label();
            textBoxTemperatureValue = new TextBox();
            comboBoxCurrentScale = new ComboBox();
            buttonConvert = new Button();
            panelTemperatureConverter.SuspendLayout();
            SuspendLayout();
            // 
            // panelTemperatureConverter
            // 
            panelTemperatureConverter.Anchor = AnchorStyles.None;
            panelTemperatureConverter.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelTemperatureConverter.BackColor = SystemColors.ActiveBorder;
            panelTemperatureConverter.BorderStyle = BorderStyle.FixedSingle;
            panelTemperatureConverter.Controls.Add(labelResultValue);
            panelTemperatureConverter.Controls.Add(labelResultText);
            panelTemperatureConverter.Controls.Add(comboBoxNewScale);
            panelTemperatureConverter.Controls.Add(labelNewScaleText);
            panelTemperatureConverter.Controls.Add(labelEnterTemperature);
            panelTemperatureConverter.Controls.Add(labelCurrentScaleText);
            panelTemperatureConverter.Controls.Add(textBoxTemperatureValue);
            panelTemperatureConverter.Controls.Add(comboBoxCurrentScale);
            panelTemperatureConverter.Controls.Add(buttonConvert);
            panelTemperatureConverter.ForeColor = SystemColors.ControlText;
            panelTemperatureConverter.Location = new Point(35, 35);
            panelTemperatureConverter.Name = "panelTemperatureConverter";
            panelTemperatureConverter.Size = new Size(633, 369);
            panelTemperatureConverter.TabIndex = 0;
            // 
            // labelResultValue
            // 
            labelResultValue.AutoSize = true;
            labelResultValue.Location = new Point(202, 236);
            labelResultValue.Name = "labelResultValue";
            labelResultValue.Size = new Size(0, 15);
            labelResultValue.TabIndex = 11;
            labelResultValue.TextAlign = ContentAlignment.TopRight;
            // 
            // labelResultText
            // 
            labelResultText.AutoSize = true;
            labelResultText.Location = new Point(136, 236);
            labelResultText.Name = "labelResultText";
            labelResultText.Size = new Size(63, 15);
            labelResultText.TabIndex = 10;
            labelResultText.Text = "Результат:";
            // 
            // comboBoxNewScale
            // 
            comboBoxNewScale.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxNewScale.FormattingEnabled = true;
            comboBoxNewScale.Items.AddRange(new object[] { "Цельсия", "Фаренгейт", "Кельвин" });
            comboBoxNewScale.Location = new Point(136, 187);
            comboBoxNewScale.Name = "comboBoxNewScale";
            comboBoxNewScale.Size = new Size(258, 23);
            comboBoxNewScale.TabIndex = 8;
            // 
            // labelNewScaleText
            // 
            labelNewScaleText.AutoSize = true;
            labelNewScaleText.Location = new Point(136, 154);
            labelNewScaleText.Name = "labelNewScaleText";
            labelNewScaleText.Size = new Size(323, 15);
            labelNewScaleText.TabIndex = 7;
            labelNewScaleText.Text = "Выберите шкалу в которую конвертируется температура";
            // 
            // labelEnterTemperature
            // 
            labelEnterTemperature.AutoSize = true;
            labelEnterTemperature.Location = new Point(208, 114);
            labelEnterTemperature.Name = "labelEnterTemperature";
            labelEnterTemperature.Size = new Size(123, 15);
            labelEnterTemperature.TabIndex = 5;
            labelEnterTemperature.Text = "Введите температуру";
            // 
            // labelCurrentScaleText
            // 
            labelCurrentScaleText.AutoSize = true;
            labelCurrentScaleText.Location = new Point(136, 41);
            labelCurrentScaleText.Name = "labelCurrentScaleText";
            labelCurrentScaleText.Size = new Size(248, 15);
            labelCurrentScaleText.TabIndex = 4;
            labelCurrentScaleText.Text = "Выберите шкалу для текущей температуры";
            // 
            // textBoxTemperatureValue
            // 
            textBoxTemperatureValue.Location = new Point(136, 114);
            textBoxTemperatureValue.Name = "textBoxTemperatureValue";
            textBoxTemperatureValue.Size = new Size(66, 23);
            textBoxTemperatureValue.TabIndex = 3;
            // 
            // comboBoxCurrentScale
            // 
            comboBoxCurrentScale.CausesValidation = false;
            comboBoxCurrentScale.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCurrentScale.FormattingEnabled = true;
            comboBoxCurrentScale.Items.AddRange(new object[] { "Цельсия", "Фаренгейт", "Кельвин" });
            comboBoxCurrentScale.Location = new Point(136, 70);
            comboBoxCurrentScale.Name = "comboBoxCurrentScale";
            comboBoxCurrentScale.Size = new Size(258, 23);
            comboBoxCurrentScale.TabIndex = 2;
            // 
            // buttonConvert
            // 
            buttonConvert.Location = new Point(136, 288);
            buttonConvert.Name = "buttonConvert";
            buttonConvert.Size = new Size(117, 34);
            buttonConvert.TabIndex = 0;
            buttonConvert.Text = "Конвертировать";
            buttonConvert.UseVisualStyleBackColor = true;
            // 
            // TemperatureForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelTemperatureConverter);
            Name = "TemperatureForm";
            StartPosition = FormStartPosition.WindowsDefaultBounds;
            Text = "TemperatureForm";
            Load += FormMain_Load;
            panelTemperatureConverter.ResumeLayout(false);
            panelTemperatureConverter.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panelTemperatureConverter;
        private Button buttonConvert;

        private Label labelCurrentScaleText;
        private Label labelEnterTemperature;
        private Label labelNewScaleText;
        private Label labelResultText;
        private Label labelResultValue;

        private ComboBox comboBoxCurrentScale;
        private ComboBox comboBoxNewScale;

        private TextBox textBoxTemperatureValue;
    }
}