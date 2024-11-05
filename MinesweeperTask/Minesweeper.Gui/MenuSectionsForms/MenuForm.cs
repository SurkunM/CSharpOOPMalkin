namespace Minesweeper.Gui.MenuSectionsForms;

using Minesweeper.Gui.MenuSectionsForms.MenuInterface;
using Minesweeper.Gui.SectionPanels.MenuSectionsForms;
using Minesweeper.Logic.Model.FieldKeys;
using Minesweeper.Logic.Model.Interface;
using Minesweeper.Logic.Presenter;
using System.Collections.Generic;

public partial class MenuForm : Form, IMenuSectionForm, IFieldConfiguration
{
    private readonly MenuPresenter _menuPresenter;

    public Dictionary<FieldConfigurationsKeys, int> FieldConfigurations { get; set; }

    public FieldConfigurationsKeys FieldConfigurationsKeys { private get; set; }

    public MenuForm(MenuPresenter menuPresenter)
    {
        InitializeComponent();

        var sectionTopPanel = new SectionTopPanel();
        sectionTopPanel.Button.Click += ButtonBackMenuClick!;
        Controls.Add(sectionTopPanel.Panel);

        _menuPresenter = menuPresenter;

        FieldConfigurationsKeys = new FieldConfigurationsKeys();
        FieldConfigurations = _menuPresenter.GetFieldConfigurations();

        var sizesArray = _menuPresenter.GetFieldSizesArray();        

        comboBoxRowsCount.Items.AddRange(sizesArray);
        comboBoxRowsCount.SelectedItem = FieldConfigurations[FieldConfigurationsKeys.Row].ToString();

        comboBoxColumnsCount.Items.AddRange(sizesArray);
        comboBoxColumnsCount.SelectedItem = FieldConfigurations[FieldConfigurationsKeys.Column].ToString();

        comboBoxMinesCount.Items.AddRange(_menuPresenter.GetMinesCountsArray());
        comboBoxMinesCount.SelectedItem = FieldConfigurations[FieldConfigurationsKeys.Mine].ToString();
    }

    private void AddFieldItems()
    {
        FieldConfigurations[FieldConfigurationsKeys.Row] = Convert.ToInt32(comboBoxRowsCount.SelectedItem);
        FieldConfigurations[FieldConfigurationsKeys.Column] = Convert.ToInt32(comboBoxColumnsCount.SelectedItem);
        FieldConfigurations[FieldConfigurationsKeys.Mine] = Convert.ToInt32(comboBoxMinesCount.SelectedItem);

        _menuPresenter.SetFieldConfigurations(FieldConfigurations);
        labelChangesSaved.Text = "Changes saved!";
    }

    public void ButtonBackMenuClick(object sender, EventArgs e)
    {
        _menuPresenter.CloseSelectedSectionForm();
    }

    private void ComboBoxRowColumnCountSelectedItemChanged(object sender, EventArgs e)
    {
        labelChangesSaved.Text = "";
    }

    private void ComboBoxMineCountSelectedItemChanged(object sender, EventArgs e)
    {
        labelChangesSaved.Text = "";
    }

    private void ComboBoxColumnsCountSelectedItemChanged(object sender, EventArgs e)
    {
        labelChangesSaved.Text = "";
    }

    private void ButtonSetConfigurationsClick(object sender, EventArgs e)
    {
        AddFieldItems();
    }
}