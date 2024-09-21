using TemperatureTask.Controller;

namespace TemperatureTask.View;

internal class TemperatureView : IView
{
    private ComboBox? _currentScale;
    private ComboBox? _newScale;
    private TextBox? TemperatureValue;

    public Label? LabelResult { get; set; }

    public TemperatureController? Controller { get; set; }

    public void currentScaleComboBox_ScaledIndexChanged(object? sender, EventArgs? e)
    {
        _currentScale = (ComboBox)sender!;
    }

    public void newScaleComboBox_SelectedIndexChanged(object? sender, EventArgs? e)
    {
        _newScale = (ComboBox)sender!;
    }

    public void temperatureValueTextBox_TextChanged(object? sender, EventArgs? e)
    {
        TemperatureValue = (TextBox)sender!;
    }

    public void convertButton_Click(object? sender, EventArgs? e)
    {
        try
        {
            if (TemperatureValue is null)
            {
                throw new ArgumentNullException(nameof(TemperatureValue));
            }

            Controller!.ConversionTemperature(Convert.ToDouble(TemperatureValue.Text), _currentScale, _newScale);
        }
        catch (FormatException)
        {
            MessageBox.Show("Введен не корректный формат температуры", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (ArgumentNullException exception)
        {
            if (exception.ParamName == "currentScale")
            {
                MessageBox.Show("Необходимо выбрать шкалу текущей температуры", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (exception.ParamName == "newScale")
            {
                MessageBox.Show("Необходимо выбрать шкалу в которую конвертируется температура", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (exception.ParamName == "TemperatureValue")
            {
                MessageBox.Show("Заполните поле значения температуры", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }

    public void SetConversionResult(double temperature)
    {
        LabelResult!.Text = $"{temperature} {_newScale!.Text}";
    }
}