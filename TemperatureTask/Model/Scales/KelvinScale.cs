namespace TemperatureTask.Model.Scales;

public class KelvinScale : IScale
{
    private const string Name = "Кельвина";

    private const double CelsiusAbsoluteZero = 273.15;

    private const int FahrenheitZeroCelsius = 32;

    private const double FahrenheitUnitChangeRatio = 1.8;

    public double ConvertTo(double temperature, IScale outgoingScale)
    {
        if (outgoingScale is CelsiusScale)
        {
            return temperature - CelsiusAbsoluteZero;
        }

        if (outgoingScale is FahrenheitScale)
        {
            return (temperature - CelsiusAbsoluteZero) * FahrenheitUnitChangeRatio + FahrenheitZeroCelsius;
        }

        return temperature;
    }

    public string GetResultScaleText()
    {
        return Name;
    }

    public override string ToString()
    {
        return Name;
    }
}