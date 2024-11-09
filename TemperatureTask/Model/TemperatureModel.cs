using TemperatureTask.Model.Interfaces;
using TemperatureTask.Model.Scales;

namespace TemperatureTask.Model;

public class TemperatureModel : IModel
{
    public event Action<double>? ConversionResultSet;

    public List<IScale> Scales { get; } = [];//TODO: 1) Выбрать одну шкалу в качестве базовой, например, шкалу Цельсия
                                             //       2) Сделать интерфейс для шкалы и конкретные классы для шкал, которые будут реализовывать этот интерфейс.
                                             //          В интерфейсе должны быть методы для перевода температуры из текущей шкалы в базовую шкалу и обратно
                                             //       3) В программе сделать список шкал и сделать, чтобы UI строился через него

    public TemperatureModel()
    {
        Scales.Add(new CelsiusScale());
        Scales.Add(new FahrenheitScale());
        Scales.Add(new KelvinScale());
    }

    public void ConvertTemperature(double temperature, IScale incomingScale, IScale outgoingScale)
    {
        var temperatureConversionResult = incomingScale.ConvertTo(temperature, outgoingScale);

        ConversionResultSet?.Invoke(temperatureConversionResult);
    }
}