using Minesweeper.Gui.MenuSectionsForms;
using Minesweeper.Logic.Model;
using Minesweeper.Logic.Model.Interface;
using Minesweeper.Logic.Presenter;

namespace Minesweeper.Gui.InitialMenuForms;

public partial class InitialMenuForm : Form, IInitialMenu
{
    private Form _activeForm = default!;

    public MenuPresenter MenuPresenter { private get; set; } = default!;

    public InitialMenuForm()
    {
        InitializeComponent();
    }

    private void ButtonStartClick(object sender, EventArgs e)
    {
        if (_activeForm is not null)
        {
            (_activeForm).Close();
        }

        var gameLogic = new GameLogic(MenuPresenter.GetFieldConfigurations());
        var gameForm = new GameForm(MenuPresenter.GetFieldConfigurations());
        var gamePresenter = new GamePresenter(gameLogic, gameForm);

        gameForm.GamePresenter = gamePresenter;
        gameForm.MenuPresenter = MenuPresenter;

        _activeForm = gameForm;
        MenuPresenter.OpenSelectedSectionForm();
    }

    private void ButtonHighScoresClick(object sender, EventArgs e)
    {
        var highScoresForm = new HighScoresForm();
        highScoresForm.LogicController = MenuPresenter;

        _activeForm = highScoresForm;
        MenuPresenter.OpenSelectedSectionForm();
    }

    private void ButtonMenuClick(object sender, EventArgs e)
    {
        var gameMenuForm = new MenuForm(MenuPresenter);

        _activeForm = gameMenuForm;
        MenuPresenter.OpenSelectedSectionForm();
    }

    private void ButtonAboutClick(object sender, EventArgs e)
    {
        var aboutForm = new AboutForm();
        aboutForm.LogicController = MenuPresenter;

        _activeForm = aboutForm;
        MenuPresenter.OpenSelectedSectionForm();
    }

    private void ButtonExitClick(object sender, EventArgs e)
    {
        Application.Exit();
    }

    public void OpenSelectedSectionForm()
    {
        _activeForm.TopLevel = false;
        panelStartMenu.Controls.Add(_activeForm);
        panelStartMenu.Tag = _activeForm;
        ClientSize = _activeForm.ClientSize;

        _activeForm.BringToFront();
        _activeForm.Show();
    }

    public void CloseSelectedSectionForm()
    {
        _activeForm.Close();
        ClientSize = new Size(439, 421);
    }
}