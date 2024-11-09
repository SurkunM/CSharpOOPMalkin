namespace TemperatureTask.Model.Scales;

internal interface IBaseScale
{
    double GetBaseScaleTemperature(double temperature);
}
