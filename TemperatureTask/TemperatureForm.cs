using TemperatureTask.Controller;
using TemperatureTask.Model.Interfaces;
using TemperatureTask.Model.Scales;

namespace TemperatureTask;

public partial class TemperatureForm : Form, IModelListener
{
    public TemperatureController Controller { private get; set; } = default!;

    private readonly IScale[] _scales;

    public TemperatureForm()
    {
        InitializeComponent();

        _scales = [new Celsius(), new Fahrenheit(), new Kelvin()];

        comboBoxIncomingScale.Items.AddRange(_scales);
        comboBoxOutgoingScale.Items.AddRange(_scales);

        comboBoxIncomingScale.SelectedItem = _scales.First();
        comboBoxOutgoingScale.SelectedItem = _scales.Last();
    }

    private void ComboBoxIncomingScaleSelectedIndexChanged(object sender, EventArgs e)
    {
        comboBoxIncomingScale = (ComboBox)sender;
    }

    private void ComboBoxOutgoingScaleSelectedIndexChanged(object sender, EventArgs e)
    {
        comboBoxOutgoingScale = (ComboBox)sender;
    }

    private void TextBoxSetTemperatureValueTextChanged(object sender, EventArgs e)
    {
        textBoxSetTemperatureValue = (TextBox)sender;
    }

    private void ButtonConvertClick(object sender, EventArgs e)
    {
        try
        {
            if (textBoxSetTemperatureValue is null)
            {
                throw new ArgumentNullException(nameof(textBoxSetTemperatureValue));
            }

            Controller!.ConvertTemperature(Convert.ToDouble(textBoxSetTemperatureValue.Text), comboBoxIncomingScale.SelectedItem as IScale, comboBoxOutgoingScale.SelectedItem as IScale);
        }
        catch (FormatException)
        {
            MessageBox.Show("Температура должна быть числом", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    public void SetConversionResult(double temperature)
    {
        if (comboBoxOutgoingScale.SelectedItem is Kelvin)
        {
            labelResultValue.Text = $"{temperature} {comboBoxOutgoingScale.Text}";
        }
        else
        {
            labelResultValue.Text = $"{temperature} градусов {comboBoxOutgoingScale.Text}";
        }
    }
}