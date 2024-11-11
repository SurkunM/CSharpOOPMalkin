using TemperatureTask.Controller;

namespace TemperatureTask.View;

internal class TemperatureView : IView
{
    private ComboBox? _incomingScale;
    private ComboBox? _outgoingScale;
    private TextBox? TemperatureValue;

    public Label? LabelResult { get; set; }

    public TemperatureController? Controller { get; set; }

    public void IncomingScaleComboBoxSelectedIndexChanged(object? sender, EventArgs? e)
    {
        _incomingScale = (ComboBox)sender!;
    }

    public void OutgoingScaleComboBoxSelectedIndexChanged(object? sender, EventArgs? e)
    {
        _outgoingScale = (ComboBox)sender!;
    }

    public void TemperatureValueTextBoxTextChanged(object? sender, EventArgs? e)
    {
        TemperatureValue = (TextBox)sender!;
    }

    public void ConvertButtonClick(object? sender, EventArgs? e)
    {
        try
        {
            if (TemperatureValue is null)
            {
                throw new ArgumentNullException(nameof(TemperatureValue));
            }

            Controller!.ConvertTemperature(Convert.ToDouble(TemperatureValue.Text), _incomingScale, _outgoingScale);
        }
        catch (FormatException)
        {
            MessageBox.Show("Температура должна быть числом", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (ArgumentNullException exception)
        {
            if (exception.ParamName == "currentScale")
            {
                MessageBox.Show("Необходимо выбрать шкалу текущей температуры", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (exception.ParamName == "newScale")
            {
                MessageBox.Show("Необходимо выбрать шкалу в которую конвертируется температура", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (exception.ParamName == "TemperatureValue")
            {
                MessageBox.Show("Заполните поле значения температуры", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public void SetConversionResult(double temperature)
    {
        LabelResult!.Text = $"{temperature} градусов {_outgoingScale!.Text}";
    }
}