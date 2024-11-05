using Minesweeper.Logic.Model;
using Minesweeper.Logic.Model.FieldKeys;
using Minesweeper.Logic.Model.Interface;

namespace Minesweeper.Logic.Presenter;

public class MenuPresenter
{
    private readonly MenuLogic _menuLogic;

    private readonly IInitialMenu _view;

    public MenuPresenter(MenuLogic model, IInitialMenu logicGame)
    {
        _menuLogic = model;
        _view = logicGame;
    }

    public void OpenSelectedSectionForm()
    {
        _view.OpenSelectedSectionForm();
    }

    public void CloseSelectedSectionForm()
    {
        _view.CloseSelectedSectionForm();
    }

    public string[] GetFieldSizesArray()
    {
        return _menuLogic.FieldSizes;
    }

    public string[] GetMinesCountsArray()
    {
        return _menuLogic.MineCounts;
    }

    public void SetFieldConfigurations(Dictionary<FieldConfigurationsKeys, int> fieldConfigurations)
    {
        _menuLogic.FieldConfigurations = fieldConfigurations;
    }

    public Dictionary<FieldConfigurationsKeys, int> GetFieldConfigurations()
    {
        return _menuLogic.FieldConfigurations;
    }
}