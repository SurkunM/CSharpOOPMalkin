namespace TemperatureTask.Model.Scales;

public class Kelvin : IScale
{
    private const string Name = "Кельвин";

    private const double CelsiusAbsoluteZero = 273.15;

    private const int FahrenheitZeroCelsius = 32;

    private const double FahrenheitUnitChangeRatio = 1.8;

    public double Convert(double temperature, IScale outgoingScale)
    {
        if (outgoingScale is Celsius)
        {
            return temperature - CelsiusAbsoluteZero;
        }

        if (outgoingScale is Fahrenheit)
        {
            return (temperature - CelsiusAbsoluteZero) * FahrenheitUnitChangeRatio + FahrenheitZeroCelsius;
        }

        return temperature;
    }

    public override string ToString()
    {
        return Name;
    }
}