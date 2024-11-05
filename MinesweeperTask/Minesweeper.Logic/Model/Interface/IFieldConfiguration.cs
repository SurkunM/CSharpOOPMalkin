using Minesweeper.Logic.Model.FieldKeys;

namespace Minesweeper.Logic.Model.Interface;

public interface IFieldConfiguration
{
    Dictionary<FieldConfigurationsKeys, int> FieldConfigurations { get; set; }

    FieldConfigurationsKeys FieldConfigurationsKeys { set; }
}