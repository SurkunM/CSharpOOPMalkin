namespace TemperatureTask.Model.Scales;

public class FahrenheitScale : IScale
{
    private const string Name = "Фаренгейта";

    private const double CelsiusAbsoluteZero = 273.15;

    private const int FahrenheitZeroCelsius = 32;

    private const double FahrenheitUnitChangeRatio = 1.8;

    public double ConvertTo(double temperature, IScale outgoingScale)
    {
        if (outgoingScale is CelsiusScale)
        {
            return (temperature - FahrenheitZeroCelsius) / FahrenheitUnitChangeRatio;
        }

        if (outgoingScale is KelvinScale)
        {
            return (temperature - FahrenheitZeroCelsius) / FahrenheitUnitChangeRatio + CelsiusAbsoluteZero;
        }

        return temperature;
    }

    public string GetResultScaleText()
    {
        return $"градусов {Name}";
    }

    public override string ToString()
    {
        return Name;
    }
}