using Minesweeper.Logic.Model.FieldKeys;
using Minesweeper.Logic.Model.Interface;

namespace Minesweeper.Logic.Model;

public class MenuLogic : IFieldConfiguration
{
    public string[] FieldSizes;

    public string[] MineCounts;

    public int MineCount { get; set; } = 10;

    public int RowCount { get; set; } = 9;

    public int ColumnCount { get; set; } = 9;

    public Dictionary<FieldConfigurationsKeys, int> FieldConfigurations { get; set; }

    public FieldConfigurationsKeys FieldConfigurationsKeys { private get; set; }

    public MenuLogic()
    {
        FieldConfigurationsKeys = new FieldConfigurationsKeys();

        FieldConfigurations = new Dictionary<FieldConfigurationsKeys, int>()
        {
            {FieldConfigurationsKeys.Row, RowCount},
            {FieldConfigurationsKeys.Column, ColumnCount},
            {FieldConfigurationsKeys.Mine, MineCount}
        };

        FieldSizes = ["9", "12", "18", "24"];
        MineCounts = ["10", "20", "30", "45"];
    }

    public string GetAboutText()
    {
        return "";
    }
}