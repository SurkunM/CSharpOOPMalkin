using TemperatureTask.Model;
using TemperatureTask.View;

namespace TemperatureTask.Controller;

internal class TemperatureController
{
    private readonly TemperatureModel _model;

    private readonly TemperatureView _view;

    public TemperatureController(TemperatureModel model, TemperatureView view)
    {
        _model = model;
        _view = view;
    }

    public void ConversionTemperature(double temperature, ComboBox? currentScale, ComboBox? newScale)
    {
        if (currentScale is null)
        {
            throw new ArgumentNullException(nameof(currentScale));
        }

        if (newScale is null)
        {
            throw new ArgumentNullException(nameof(newScale));
        }

        var newTemperature = _model.ConversionTemperature(temperature, currentScale, newScale);

        _view.SetConversionResult(newTemperature);
    }
}