namespace Minesweeper.Gui.MenuSectionsForms;

using Minesweeper.Gui.MenuSectionsForms.MenuInterface;
using Minesweeper.Gui.SectionPanels.MenuSectionsForms;
using Minesweeper.Logic.Presenter;

public partial class AboutForm : Form, IMenuSectionForm
{
    //TODO: Сделать поле текста в Logic
    public MenuPresenter LogicController { private get; set; } = default!;

    public AboutForm()
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