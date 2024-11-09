using Minesweeper.Logic.Model;
using Minesweeper.Logic.Model.Interface;

namespace Minesweeper.Logic.Presenter;

public class GamePresenter
{
    private readonly GameLogic _gameLogic;

    private IGame _viewGame;

    public GamePresenter(GameLogic gameLogic, IGame logicGame)
    {
        _gameLogic = gameLogic;
        _viewGame = logicGame;
    }

    public bool HasCellFlag(int row, int column)
    {
        return _gameLogic.HasCellFlag(row, column);
    }

    public void OpenCell(int row, int column)
    {
        if (_gameLogic.IsMinedCell(row, column))
        {
            _viewGame.OpenMines(row, column);
            _viewGame.ShowEndGameDialog();

        }

        _viewGame.SetUnVisibleCell();
    }

    public void ChangeCellFlag(bool hasCellFlag, int row, int column)
    {
        if (hasCellFlag)
        {
            _gameLogic.RemoveFlag(row, column);
            _viewGame.RemoveCellFlag();
            SetViewMinesCount();
        }
        else
        {
            if (_gameLogic.SetFlag(row, column))
            {
                _viewGame.SetCellFlag();
                SetViewMinesCount();
            }
        }
    }

    private void SetViewMinesCount()
    {
        _viewGame.SetMinesCount(_gameLogic.CurrentMineCount);
    }
}