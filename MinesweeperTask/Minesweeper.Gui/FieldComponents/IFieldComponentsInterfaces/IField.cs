namespace Minesweeper.Gui.FieldComponents.IFieldCell;

internal interface IField
{
    void ButtonClick(object? sender, MouseEventArgs e);

    void InitializePanel();
}