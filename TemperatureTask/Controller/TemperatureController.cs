using TemperatureTask.Model;
using TemperatureTask.Model.Interfaces;
using TemperatureTask.Model.Scales;

namespace TemperatureTask.Controller;

public class TemperatureController
{
    private readonly TemperatureModel _model;

    public IModel ModelListener { get; }

    public TemperatureController(TemperatureModel model)
    {
        if (model is null)
        {
            throw new ArgumentNullException(nameof(model));
        }

        _model = model;
        ModelListener = model;
    }

    public List<IScale> GetScales()
    {
        return _model.Scales;
    }

    public void ConvertTemperature(double temperature, IScale incomingScale, IScale outgoingScale)
    {
        _model.ConvertTemperature(temperature, incomingScale, outgoingScale);
    }
}