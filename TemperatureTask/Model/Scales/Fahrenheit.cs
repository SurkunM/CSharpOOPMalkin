namespace TemperatureTask.Model.Scales;

public class Fahrenheit : IScale
{
    private const string Name = "Фаренгейт";

    private const double CelsiusAbsoluteZero = 273.15;

    private const int FahrenheitZeroCelsius = 32;

    private const double FahrenheitUnitChangeRatio = 1.8;

    public double Convert(double temperature, IScale outgoingScale)
    {
        if (outgoingScale is Celsius)
        {
            return (temperature - FahrenheitZeroCelsius) / FahrenheitUnitChangeRatio;
        }

        if (outgoingScale is Kelvin)
        {
            return (temperature - FahrenheitZeroCelsius) / FahrenheitUnitChangeRatio + CelsiusAbsoluteZero;
        }

        return temperature;
    }

    public override string ToString()
    {
        return Name;
    }
}