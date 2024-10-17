using TemperatureTask.Model.Interfaces;
using TemperatureTask.Model.Scales;

namespace TemperatureTask.Model;

public class TemperatureModel : IModel
{
    public event Action<double> ConversionResultSet;

    private readonly IModelListener _listener;

    public TemperatureModel(IModelListener listener)
    {
        if (listener is null)
        {
            throw new ArgumentNullException(nameof(listener));
        }

        _listener = listener;
        ConversionResultSet += _listener.SetConversionResult;
    }

    public void ConvertTemperature(double temperature, IScale incomingScale, IScale outgoingScale)
    {
        var temperatureConversionResult = incomingScale.ConvertTo(temperature, outgoingScale);

        ConversionResultSet.Invoke(temperatureConversionResult);
    }
}