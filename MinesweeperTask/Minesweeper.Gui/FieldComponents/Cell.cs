using Minesweeper.Gui.FieldComponents.IFieldCell;
using Minesweeper.Gui.FieldComponents.IFieldComponentsInterfaces;

namespace Minesweeper.Gui.FieldComponents;

internal class Cell : ICell
{
    private IField _field;

    public Button ButtonCell { get; }

    public Cell(IField field)
    {
        _field = field;

        ButtonCell = new Button();
        ButtonCell.Dock = DockStyle.Fill;       
        ButtonCell.Location = new Point(0, 0);
        ButtonCell.Margin = new Padding(0);
        ButtonCell.Padding = new Padding(0);        
        ButtonCell.UseVisualStyleBackColor = true;
        

        AddListener();
    }

    public void AddListener()
    {
        ButtonCell.MouseDown += _field.ButtonClick;
        //TODO: Реализовать через логику. 
    }
}