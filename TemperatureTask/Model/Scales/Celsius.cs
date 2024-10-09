namespace TemperatureTask.Model.Scales;

public class Celsius : IScale
{
    private const string Name = "Цельсия";

    private const double CelsiusAbsoluteZero = 273.15;

    private const int FahrenheitZeroCelsius = 32;

    private const double FahrenheitUnitChangeRatio = 1.8;

    public double Convert(double temperature, IScale outgoingScale)
    {
        if (outgoingScale is Fahrenheit)
        {
            return temperature * FahrenheitUnitChangeRatio + FahrenheitZeroCelsius;
        }

        if (outgoingScale is Kelvin)
        {
            return temperature + CelsiusAbsoluteZero;
        }

        return temperature;
    }

    public override string ToString()
    {
        return Name;
    }
}