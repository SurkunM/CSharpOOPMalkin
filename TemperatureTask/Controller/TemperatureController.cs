using TemperatureTask.Model;
using TemperatureTask.Model.Scales;

namespace TemperatureTask.Controller;

public class TemperatureController
{
    private readonly TemperatureModel _model;   

    public TemperatureController( TemperatureModel model)
    {
        if (model is null)
        {
            throw new ArgumentNullException("model");
        }

        _model = model;      
    }

    public void ConvertTemperature(double temperature, IScale? incomingScale, IScale? outgoingScale)
    {
        if (incomingScale is null)
        {
            throw new ArgumentNullException(nameof(incomingScale));
        }

        if (outgoingScale is null)
        {
            throw new ArgumentNullException(nameof(outgoingScale));
        }

        _model.ConvertTemperature(temperature, incomingScale, outgoingScale);
    }
}