using TemperatureTask.Controller;
using TemperatureTask.Model.Scales;
using TemperatureTask.View.Interface;

namespace TemperatureTask.View;

public partial class TemperatureForm : Form, IView
{
    public List<IScale> Scales { get; set; } = [];

    private IScale _incomingScale;

    private IScale _outgoingScale;

    private readonly TemperatureController _controller = default!;

    public TemperatureForm(TemperatureController controller)
    {
        InitializeComponent();

        _controller = controller;
        _controller.ModelListener.ConversionResultSet += SetConversionResult;

        Scales = _controller.GetScales();

        comboBoxIncomingScale.Items.AddRange([.. Scales]);
        comboBoxOutgoingScale.Items.AddRange([.. Scales]);

        _incomingScale = Scales.First();
        comboBoxIncomingScale.SelectedItem = _incomingScale;

        _outgoingScale = Scales.Last();
        comboBoxOutgoingScale.SelectedItem = _outgoingScale;
    }

    public void SetIncomingScale(IScale incomingScale)
    {
        _incomingScale = incomingScale;
    }

    public void SetOutgoingScale(IScale outgoingScale)
    {
        _outgoingScale = outgoingScale;
    }

    public double GetTemperatureValue(string stringTemperature)
    {
        return Convert.ToDouble(stringTemperature);
    }

    public void SetConversionResult(double temperature)
    {
        labelResultValue.Text = $"{temperature} {_outgoingScale.GetResultScaleText()}";
    }

    public void ConvertTemperature()
    {
        try
        {
            if (_incomingScale is null)
            {
                throw new ArgumentNullException(nameof(_incomingScale));
            }

            if (_outgoingScale is null)
            {
                throw new ArgumentNullException(nameof(_outgoingScale));
            }

            _controller.ConvertTemperature(GetTemperatureValue(textBoxSetTemperatureValue.Text), _incomingScale, _outgoingScale);
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

    private void ComboBoxIncomingScaleSelectedIndexChanged(object sender, EventArgs e)
    {
        comboBoxIncomingScale = (ComboBox)sender;

        if (comboBoxIncomingScale is null)
        {
            throw new ArgumentNullException(nameof(comboBoxIncomingScale));
        }

        if (comboBoxIncomingScale.SelectedItem is null)
        {
            throw new ArgumentNullException(nameof(comboBoxIncomingScale.SelectedItem));
        }

        SetIncomingScale((IScale)comboBoxIncomingScale.SelectedItem);
    }

    private void ComboBoxOutgoingScaleSelectedIndexChanged(object sender, EventArgs e)
    {
        comboBoxOutgoingScale = (ComboBox)sender;

        if (comboBoxOutgoingScale is null)
        {
            throw new ArgumentNullException(nameof(comboBoxOutgoingScale));
        }

        if (comboBoxOutgoingScale.SelectedItem is null)
        {
            throw new ArgumentNullException(nameof(comboBoxOutgoingScale.SelectedItem));
        }

        SetOutgoingScale((IScale)comboBoxOutgoingScale.SelectedItem);
    }

    private void TextBoxSetTemperatureValueTextChanged(object sender, EventArgs e)
    {
        textBoxSetTemperatureValue = (TextBox)sender;

        if (textBoxSetTemperatureValue is null)
        {
            throw new ArgumentNullException(nameof(textBoxSetTemperatureValue));
        }

        if (textBoxSetTemperatureValue.Text is null)
        {
            throw new ArgumentNullException(nameof(textBoxSetTemperatureValue.Text));
        }

        GetTemperatureValue(textBoxSetTemperatureValue.Text);
    }

    private void ButtonConvertClick(object sender, EventArgs e)
    {
        ConvertTemperature();
    }
}