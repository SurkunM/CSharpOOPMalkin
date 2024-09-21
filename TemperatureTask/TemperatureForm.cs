using TemperatureTask.Controller;
using TemperatureTask.Model;
using TemperatureTask.View;

namespace TemperatureTask;

public partial class TemperatureForm : Form
{
    private readonly TemperatureModel model;
    private readonly TemperatureView view;
    private readonly TemperatureController controller;

    public TemperatureForm()
    {
        InitializeComponent();

        view = new TemperatureView();
        model = new TemperatureModel();
        controller = new TemperatureController(model, view);

        view.Controller = controller;
        view.LabelResult = labelResultValue;

        comboBoxCurrentScale.SelectedIndexChanged += view.currentScaleComboBox_ScaledIndexChanged;
        comboBoxNewScale.SelectedIndexChanged += view.newScaleComboBox_SelectedIndexChanged;
        textBoxTemperatureValue.TextChanged += view.temperatureValueTextBox_TextChanged;

        buttonConvert.Click += view.convertButton_Click;
    }

    private void FormMain_Load(object sender, EventArgs e)
    {

    }
}