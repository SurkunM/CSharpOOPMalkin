using TemperatureTask.Model.Scales;

namespace TemperatureTask.Model.Interfaces;

internal interface IModel
{
    void ConvertTemperature(double temperature, IScale incomingScale, IScale outgoingScale);
}