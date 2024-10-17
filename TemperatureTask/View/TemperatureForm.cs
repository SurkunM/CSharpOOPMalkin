using TemperatureTask.Controller;
using TemperatureTask.Model.Interfaces;
using TemperatureTask.Model.Scales;
using TemperatureTask.View.Interface;

namespace TemperatureTask.View;

public partial class TemperatureForm : Form, IView, IModelListener
{
    public TemperatureController Controller { private get; set; } = default!;

    private readonly List<IScale> _scales = [];

    public TemperatureForm()
    {
        InitializeComponent();

        _scales.Add(new CelsiusScale());
        _scales.Add(new FahrenheitScale());
        _scales.Add(new KelvinScale());

        comboBoxIncomingScale.Items.AddRange([.. _scales]);
        comboBoxOutgoingScale.Items.AddRange([.. _scales]);

        comboBoxIncomingScale.SelectedItem = _scales.First();
        comboBoxOutgoingScale.SelectedItem = _scales.Last();
    }

    public void ComboBoxIncomingScaleSelectedIndexChanged(object sender, EventArgs e)
    {
        comboBoxIncomingScale = (ComboBox)sender;
    }

    public void ComboBoxOutgoingScaleSelectedIndexChanged(object sender, EventArgs e)
    {
        comboBoxOutgoingScale = (ComboBox)sender;
    }

    public void TextBoxSetTemperatureValueTextChanged(object sender, EventArgs e)
    {
        textBoxSetTemperatureValue = (TextBox)sender;
    }

    public void ButtonConvertClick(object sender, EventArgs e)
    {
        try
        {
            if (textBoxSetTemperatureValue is null)
            {
                throw new ArgumentNullException(nameof(textBoxSetTemperatureValue));
            }

            if (comboBoxIncomingScale.SelectedItem is null)
            {
                throw new ArgumentNullException(nameof(comboBoxIncomingScale.SelectedItem));
            }

            if (comboBoxOutgoingScale.SelectedItem is null)
            {
                throw new ArgumentNullException(nameof(comboBoxOutgoingScale.SelectedItem));
            }

            Controller.ConvertTemperature(Convert.ToDouble(textBoxSetTemperatureValue.Text), (IScale)comboBoxIncomingScale.SelectedItem, (IScale)comboBoxOutgoingScale.SelectedItem);
        }
        catch (FormatException)
        {
            MessageBox.Show("Температура должна быть числом", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (ArgumentNullException)
        {
            MessageBox.Show("Введено пустое значение шкалы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    public void SetConversionResult(double temperature)
    {
        if (comboBoxOutgoingScale.SelectedItem is null)
        {
            throw new ArgumentNullException(nameof(comboBoxOutgoingScale.SelectedItem));
        }

        labelResultValue.Text = $"{temperature} {((IScale)comboBoxOutgoingScale.SelectedItem).GetResultScaleText()}";
    }
}