namespace TemperatureTask.View;

internal interface IView
{
    public void currentScaleComboBox_ScaledIndexChanged(object? sender, EventArgs? e);

    public void newScaleComboBox_SelectedIndexChanged(object? sender, EventArgs? e);

    public void temperatureValueTextBox_TextChanged(object? sender, EventArgs? e);

    public void convertButton_Click(object? sender, EventArgs? e);

    public void SetConversionResult(double temperature);
}