using TemperatureTask.Model.Interfaces;
using TemperatureTask.Model.Scales;

namespace TemperatureTask.Model;

public class TemperatureModel : IModel
{
    public event Action<double>? ResultSet;

    private readonly TemperatureForm _view;

    public TemperatureModel(TemperatureForm view)
    {
        _view = view;
    }

    public void ConvertTemperature(double temperature, IScale incomingScale, IScale outgoingScale)
    {
        var result = incomingScale.Convert(temperature, outgoingScale);

        ResultSet += _view.SetConversionResult;
        ResultSet.Invoke(result);
    }
}