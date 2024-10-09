namespace TemperatureTask.Model.Scales;

public interface IScale
{
    double Convert(double temperature, IScale scale);
}