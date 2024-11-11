using Minesweeper.Gui.FieldComponents.IFieldCell;
using System.Windows.Forms;

namespace Minesweeper.Gui.FieldComponents;

internal class Field : IField
{
    public TableLayoutPanel FieldPanel { get; } = new TableLayoutPanel();

    private readonly int _rowCount;

    private readonly int _columnCount;

    public Field(int rowCount, int columnCount)
    {
        _rowCount = rowCount;
        _columnCount = columnCount;

        InitializeField();
    }

    private void InitializeField()
    {
        FieldPanel.SuspendLayout();

        FieldPanel.AutoSize = true;
       
        FieldPanel.Location = new Point(0, 36);
        FieldPanel.Padding = new Padding(0);
        FieldPanel.Margin = new Padding(0);
        FieldPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset;
        FieldPanel.Anchor = AnchorStyles.Left | AnchorStyles.Top;
        FieldPanel.ColumnCount = _columnCount;
        AddColumn();

        FieldPanel.RowCount = _rowCount;
        AddRow();

        AddFieldCell();

        
        FieldPanel.Name = "tableLayoutPanelField";


        FieldPanel.ResumeLayout(false);

    }

    private void AddRow()
    {
        for (int i = 0; i < _rowCount; i++)
        {
            FieldPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        }
    }

    private void AddColumn()
    {
        for (int i = 0; i < _columnCount; i++)
        {
            FieldPanel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
        }
    }

    private void AddFieldCell()
    {
        int tableSize = _columnCount * _rowCount;

        for (int i = 0; i < tableSize; i++)
        {
            var fieldCell = new Cell();

            FieldPanel.Controls.Add(fieldCell.ButtonCell);
            fieldCell.AddListener(this);
        }
    }

    void IField.ButtonClick(object? sender, EventArgs e)
    {
        var button = (Button)sender;
        var count = 0;
        if (count % 2 == 0)
        {
            button.FlatStyle = FlatStyle.Popup;
        }
        else
        {
            button.FlatStyle = FlatStyle.Standard;
        }

        count++;
    }
}