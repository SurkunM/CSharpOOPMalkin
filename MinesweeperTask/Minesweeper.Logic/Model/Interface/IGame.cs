namespace Minesweeper.Logic.Model.Interface;

public interface IGame
{
    void SetMinesCount(int count);

    void OpenMines(int row, int column);

    void SetCellFlag();

    void RemoveCellFlag();

    void SetUnVisibleCell();

    void ShowEndGameDialog();
}