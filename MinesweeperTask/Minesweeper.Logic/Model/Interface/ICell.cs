namespace Minesweeper.Logic.Model.Interface;

internal interface ICell
{
    void AddListener(IField field);
}