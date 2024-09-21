namespace TemperatureTask.Model;

internal class TemperatureModel
{
    public double ConversionTemperature(double temperature, ComboBox currentScale, ComboBox newScale)
    {
        if (currentScale.SelectedItem is null)
        {
            throw new ArgumentNullException(nameof(currentScale));
        }

        if (newScale.SelectedItem is null)
        {
            throw new ArgumentNullException(nameof(newScale));
        }

        if (currentScale.SelectedItem.Equals(newScale.SelectedItem))
        {
            return temperature;
        }

        if (newScale.SelectedItem.Equals(newScale.Items[0]))
        {
            return GetCelsius(temperature, currentScale);
        }

        if (newScale.SelectedItem.Equals(newScale.Items[1]))
        {
            return GetFahrenheit(temperature, currentScale);
        }

        return GetKelvin(temperature, currentScale);
    }

    private static double GetCelsius(double temperature, ComboBox currentScale)
    {
        if (currentScale.SelectedItem!.Equals(currentScale.Items[1]))
        {
            return (temperature - 32) / 1.8;
        }

        return temperature - 273.15;
    }

    private static double GetFahrenheit(double temperature, ComboBox currentScale)
    {
        if (currentScale.SelectedItem!.Equals(currentScale.Items[0]))
        {
            return temperature * 1.8 + 32;
        }

        return (temperature - 273.15) * 1.8 + 32;
    }

    private static double GetKelvin(double temperature, ComboBox currentScale)
    {
        if (currentScale.SelectedItem!.Equals(currentScale.Items[0]))
        {
            return temperature + 273.15;
        }

        return (temperature - 32) / 1.8 + 273.15;
    }
}