using TemperatureTask.Model;
using TemperatureTask.Model.Scales;

namespace TemperatureTask.Controller;

public class TemperatureController
{
    private readonly TemperatureModel _model;

    public TemperatureController(TemperatureModel model)
    {
        if (model is null)
        {
            throw new ArgumentNullException(nameof(model));
        }

        _model = model;
    }

    public void ConvertTemperature(double temperature, IScale incomingScale, IScale outgoingScale)
    {
        _model.ConvertTemperature(temperature, incomingScale, outgoingScale);
    }
}