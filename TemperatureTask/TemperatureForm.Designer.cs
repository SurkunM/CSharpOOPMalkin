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
            labelResultText = new Label();
            comboBoxOutgoingScale = new ComboBox();
            labelOutgoingScaleText = new Label();
            labelEnterTemperature = new Label();
            labelIncomingScaleText = new Label();
            textBoxSetTemperatureValue = new TextBox();
            comboBoxIncomingScale = new ComboBox();
            buttonConvert = new Button();
            labelResultValue = new Label();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // labelResultText
            // 
            labelResultText.Anchor = AnchorStyles.None;
            labelResultText.AutoSize = true;
            labelResultText.Location = new Point(134, 360);
            labelResultText.Name = "labelResultText";
            labelResultText.Size = new Size(63, 15);
            labelResultText.TabIndex = 18;
            labelResultText.Text = "Результат:";
            // 
            // comboBoxOutgoingScale
            // 
            comboBoxOutgoingScale.Anchor = AnchorStyles.None;
            comboBoxOutgoingScale.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxOutgoingScale.FormattingEnabled = true;
            comboBoxOutgoingScale.Location = new Point(134, 311);
            comboBoxOutgoingScale.Name = "comboBoxOutgoingScale";
            comboBoxOutgoingScale.Size = new Size(326, 23);
            comboBoxOutgoingScale.TabIndex = 17;
            comboBoxOutgoingScale.SelectedIndexChanged += ComboBoxOutgoingScaleSelectedIndexChanged;
            // 
            // labelOutgoingScaleText
            // 
            labelOutgoingScaleText.Anchor = AnchorStyles.None;
            labelOutgoingScaleText.AutoSize = true;
            labelOutgoingScaleText.Location = new Point(134, 278);
            labelOutgoingScaleText.Name = "labelOutgoingScaleText";
            labelOutgoingScaleText.Size = new Size(326, 15);
            labelOutgoingScaleText.TabIndex = 16;
            labelOutgoingScaleText.Text = "Выберите шкалу, в которую конвертируется температура";
            // 
            // labelEnterTemperature
            // 
            labelEnterTemperature.Anchor = AnchorStyles.None;
            labelEnterTemperature.AutoSize = true;
            labelEnterTemperature.Location = new Point(134, 241);
            labelEnterTemperature.Name = "labelEnterTemperature";
            labelEnterTemperature.Size = new Size(129, 15);
            labelEnterTemperature.TabIndex = 15;
            labelEnterTemperature.Text = "Введите температуру: ";
            // 
            // labelIncomingScaleText
            // 
            labelIncomingScaleText.Anchor = AnchorStyles.None;
            labelIncomingScaleText.AutoSize = true;
            labelIncomingScaleText.Location = new Point(134, 165);
            labelIncomingScaleText.Name = "labelIncomingScaleText";
            labelIncomingScaleText.Size = new Size(248, 15);
            labelIncomingScaleText.TabIndex = 14;
            labelIncomingScaleText.Text = "Выберите шкалу для текущей температуры";
            // 
            // textBoxSetTemperatureValue
            // 
            textBoxSetTemperatureValue.Anchor = AnchorStyles.None;
            textBoxSetTemperatureValue.Location = new Point(315, 238);
            textBoxSetTemperatureValue.Name = "textBoxSetTemperatureValue";
            textBoxSetTemperatureValue.Size = new Size(145, 23);
            textBoxSetTemperatureValue.TabIndex = 13;
            textBoxSetTemperatureValue.TextAlign = HorizontalAlignment.Right;
            textBoxSetTemperatureValue.TextChanged += TextBoxSetTemperatureValueTextChanged;
            // 
            // comboBoxIncomingScale
            // 
            comboBoxIncomingScale.Anchor = AnchorStyles.None;
            comboBoxIncomingScale.CausesValidation = false;
            comboBoxIncomingScale.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxIncomingScale.FormattingEnabled = true;
            comboBoxIncomingScale.Location = new Point(134, 194);
            comboBoxIncomingScale.Name = "comboBoxIncomingScale";
            comboBoxIncomingScale.Size = new Size(326, 23);
            comboBoxIncomingScale.TabIndex = 12;
            comboBoxIncomingScale.SelectedIndexChanged += ComboBoxIncomingScaleSelectedIndexChanged;
            // 
            // buttonConvert
            // 
            buttonConvert.Anchor = AnchorStyles.None;
            buttonConvert.Location = new Point(134, 412);
            buttonConvert.Name = "buttonConvert";
            buttonConvert.Size = new Size(117, 34);
            buttonConvert.TabIndex = 11;
            buttonConvert.Text = "Конвертировать";
            buttonConvert.UseVisualStyleBackColor = true;
            buttonConvert.Click += ButtonConvertClick;
            // 
            // labelResultValue
            // 
            labelResultValue.Anchor = AnchorStyles.None;
            labelResultValue.AutoSize = true;
            labelResultValue.Location = new Point(203, 360);
            labelResultValue.Name = "labelResultValue";
            labelResultValue.Size = new Size(13, 15);
            labelResultValue.TabIndex = 19;
            labelResultValue.Text = "0";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveBorder;
            panel1.Controls.Add(comboBoxIncomingScale);
            panel1.Controls.Add(labelResultValue);
            panel1.Controls.Add(buttonConvert);
            panel1.Controls.Add(labelResultText);
            panel1.Controls.Add(textBoxSetTemperatureValue);
            panel1.Controls.Add(comboBoxOutgoingScale);
            panel1.Controls.Add(labelIncomingScaleText);
            panel1.Controls.Add(labelOutgoingScaleText);
            panel1.Controls.Add(labelEnterTemperature);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(603, 610);
            panel1.TabIndex = 20;
            // 
            // TemperatureForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(603, 610);
            Controls.Add(panel1);
            MinimumSize = new Size(385, 365);
            Name = "TemperatureForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TemperatureForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button buttonConvert;
        private TextBox textBoxSetTemperatureValue;

        private ComboBox comboBoxIncomingScale;
        private ComboBox comboBoxOutgoingScale;

        private Label labelIncomingScaleText;
        private Label labelOutgoingScaleText;
        private Label labelEnterTemperature;

        private Label labelResultText;
        private Label labelResultValue;
        private Panel panel1;
    }
}