using TemperatureTask.Model.Scales;

namespace TemperatureTask.Model.Interfaces;

public interface IModel
{
    public event Action<double> ConversionResultSet;

    void ConvertTemperature(double temperature, IScale incomingScale, IScale outgoingScale);
}