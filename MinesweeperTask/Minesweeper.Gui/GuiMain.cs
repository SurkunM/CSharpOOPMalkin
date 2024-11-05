using Minesweeper.Gui.InitialMenuForms;
using Minesweeper.Logic.Model;
using Minesweeper.Logic.Presenter;

namespace Minesweeper.Gui;

internal static class GuiMain
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();

        var gui = new InitialMenuForm();
        var menuLogic = new MenuLogic();

        var menuPresenter = new MenuPresenter(menuLogic, gui);
        gui.MenuPresenter = menuPresenter;

        Application.Run(gui);
    }
}