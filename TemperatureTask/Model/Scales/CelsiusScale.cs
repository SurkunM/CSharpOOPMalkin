namespace TemperatureTask.Model.Scales;

public class CelsiusScale : IScale, IBaseScale
{
    private const string Name = "Цельсия";

    private const double CelsiusAbsoluteZero = 273.15;

    private const int FahrenheitZeroCelsius = 32;

    private const double FahrenheitUnitChangeRatio = 1.8;

    public double ConvertTo(double temperature, IScale outgoingScale)
    {
        if (outgoingScale is FahrenheitScale)
        {
            return temperature * FahrenheitUnitChangeRatio + FahrenheitZeroCelsius;
        }

        if (outgoingScale is KelvinScale)
        {
            return temperature + CelsiusAbsoluteZero;
        }

        return temperature;
    }

    public double GetBaseScaleTemperature(double temperature)
    {
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