namespace TemperatureTask.Model.Scales;

public interface IScale
{
    double ConvertTo(double temperature, IScale scale);

    string GetResultScaleText();
}