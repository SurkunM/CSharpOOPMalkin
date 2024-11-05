namespace Minesweeper.Gui.SectionPanels.MenuSectionsForms;

internal class SectionTopPanel
{
    private readonly Label _minesweeperLabel;

    public Panel Panel { get; private set; }

    public Button Button { get; private set; }

    public SectionTopPanel()
    {
        Button = new Button();
        InitializeButton();

        _minesweeperLabel = new Label();
        InitializeLabel();

        Panel = new Panel();
        InitializePanel();
    }

    private void InitializePanel()
    {
        Panel.SuspendLayout();

        Panel.AutoSize = true;
        Panel.BackColor = SystemColors.Control;
        Panel.Controls.Add(Button);
        Panel.Controls.Add(_minesweeperLabel);
        Panel.Dock = DockStyle.Top;
        Panel.Location = new Point(0, 0);
        Panel.Margin = new Padding(0);
        Panel.Name = "panelTop";
        Panel.Size = new Size(439, 30);
        Panel.TabIndex = 8;

        Panel.ResumeLayout(false);
        Panel.PerformLayout();
    }

    private void InitializeButton()
    {
        Button.BackColor = SystemColors.Control;
        Button.ForeColor = SystemColors.ActiveCaptionText;
        Button.Location = new Point(0, 0);
        Button.Margin = new Padding(0);
        Button.Name = "buttonBackMenu";
        Button.Size = new Size(75, 30);
        Button.TabIndex = 0;
        Button.Text = "Back";
        Button.TabStop = true;
        Button.UseVisualStyleBackColor = false;

    }

    private void InitializeLabel()
    {
        _minesweeperLabel.Anchor = AnchorStyles.Top;
        _minesweeperLabel.AutoSize = true;
        _minesweeperLabel.Font = new Font("Stencil", 15.75F, FontStyle.Bold);
        _minesweeperLabel.Location = new Point(138, 2);
        _minesweeperLabel.Margin = new Padding(0);
        _minesweeperLabel.Name = "minesweeperLabel";
        _minesweeperLabel.Size = new Size(166, 25);
        _minesweeperLabel.TabIndex = 6;
        _minesweeperLabel.Text = "Minesweeper";
    }
}