namespace Minesweeper.Gui.MenuSectionsForms;

using Minesweeper.Gui.FieldComponents;
using Minesweeper.Gui.FieldComponents.IFieldCell;
using Minesweeper.Gui.MenuSectionsForms.MenuInterface;
using Minesweeper.Logic.Model.FieldKeys;
using Minesweeper.Logic.Model.Interface;
using Minesweeper.Logic.Presenter;
using System.Collections.Generic;
using System.Windows.Forms;

public partial class GameForm : Form, IMenuSectionForm, IFieldConfiguration, IField, IGame
{
    private Button _currentCellButton = default!;

    private readonly Image _mineImage;

    private readonly Image _flag;

    private bool _hasCellFlag;

    private readonly int _rowCount;

    private readonly int _columnCount;

    private readonly float _cellSize = 35;

    public Dictionary<FieldConfigurationsKeys, int> FieldConfigurations { get; set; }

    public FieldConfigurationsKeys FieldConfigurationsKeys { private get; set; }

    public GamePresenter GamePresenter { private get; set; } = default!;

    public MenuPresenter MenuPresenter { private get; set; } = default!;

    public GameForm(Dictionary<FieldConfigurationsKeys, int> fieldConfigurations)
    {
        FieldConfigurations = fieldConfigurations;
        FieldConfigurationsKeys = new FieldConfigurationsKeys();

        _mineImage = Image.FromFile("..\\..\\..\\GameImages\\RedMine.png");
        _flag = Image.FromFile("..\\..\\..\\GameImages\\Flag.png");

        _rowCount = FieldConfigurations[FieldConfigurationsKeys.Row];
        _columnCount = FieldConfigurations[FieldConfigurationsKeys.Column];

        InitializeComponent();

        labelMinesCount.Text = FieldConfigurations[FieldConfigurationsKeys.Mine].ToString();

        InitializePanel();

        ClientSize = new Size(panelGame.Width, panelGame.Height + panelGameElements.Height);
        // test test
    }

    public void ButtonBackMenuClick(object sender, EventArgs e)
    {
        MenuPresenter.CloseSelectedSectionForm();
    }

    public void ButtonClick(object? sender, MouseEventArgs e)
    {
        if (sender is null)
        {
            throw new ArgumentNullException(nameof(sender));
        }

        _currentCellButton = (Button)sender;

        var row = panelGame.GetRow(_currentCellButton);
        var column = panelGame.GetColumn(_currentCellButton);

        if (e.Button == MouseButtons.Right)
        {
            _hasCellFlag = _currentCellButton.Image is not null;

            GamePresenter.ChangeCellFlag(_hasCellFlag, row, column);

            return;
        }

        if (!GamePresenter.HasCellFlag(row, column))
        {
            GamePresenter.OpenCell(row, column);
        }
    }

    public void SetUnVisibleCell()
    {
        if (_currentCellButton is null)
        {
            throw new ArgumentNullException(nameof(_currentCellButton));
        }

        _currentCellButton.Visible = false;
    }

    public void SetCellFlag()
    {
        if (_currentCellButton is null)
        {
            throw new ArgumentNullException(nameof(_currentCellButton));
        }

        _currentCellButton.Image = _flag;
    }

    public void OpenMines(int row, int column)
    {
        var button = panelGame.GetControlFromPosition(column, row) as Button;

        if (button is not null)
        {
            var box = new PictureBox();
            box.Image = _mineImage;

            panelGame.SetCellPosition(box, new TableLayoutPanelCellPosition(column, row));
            // button.Image = _mineImage;
        }
    }

    public void RemoveCellFlag()
    {
        if (_currentCellButton is null)
        {
            throw new ArgumentNullException(nameof(_currentCellButton));
        }

        _currentCellButton.Image = null;
    }

    public void SetMinesCount(int count)
    {
        labelMinesCount.Text = count.ToString();
    }

    public void ShowEndGameDialog()
    {
        MessageBox.Show("Game over! Start new game?", "Game over", MessageBoxButtons.OK, MessageBoxIcon.Error);

        panelGame.Enabled = false;
    }

    public void InitializePanel()
    {
        SuspendLayout();
        panelGame.SuspendLayout();

        panelGame.RowCount = _rowCount;

        for (int i = 1; i < _rowCount; i++)
        {
            panelGame.RowStyles.Add(new RowStyle(SizeType.Absolute, _cellSize));
        }

        panelGame.ColumnCount = _columnCount;

        for (int i = 1; i < _columnCount; i++)
        {
            panelGame.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, _cellSize));
        }

        for (int i = 0; i < _rowCount; i++)
        {
            for (int j = 0; j < _columnCount; j++)
            {
                panelGame.Controls.Add(new Cell(this).ButtonCell, j, i);
            }
        }

        panelGame.ClientSize = new Size((int)_cellSize * _columnCount, (int)_cellSize * _rowCount);

        panelGame.ResumeLayout(false);
        ResumeLayout(false);
    }
}