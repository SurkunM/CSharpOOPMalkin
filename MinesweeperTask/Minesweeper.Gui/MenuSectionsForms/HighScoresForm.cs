namespace Minesweeper.Gui.MenuSectionsForms;

using Minesweeper.Gui.MenuSectionsForms.MenuInterface;
using Minesweeper.Gui.SectionPanels.MenuSectionsForms;
using Minesweeper.Logic.Presenter;

public partial class HighScoresForm : Form, IMenuSectionForm
{
    public MenuPresenter LogicController { private get; set; } = default!;

    public HighScoresForm()
    {
        SectionTopPanel sectionTopPanel = new SectionTopPanel();

        InitializeComponent();

        Controls.Add(sectionTopPanel.Panel);
        sectionTopPanel.Button.Click += ButtonBackMenuClick!;
    }

    public void ButtonBackMenuClick(object sender, EventArgs e)
    {
        LogicController.CloseSelectedSectionForm();
    }
}