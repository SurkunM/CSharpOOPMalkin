namespace TemperatureTask.View;

internal interface IView
{
    public void IncomingScaleComboBoxSelectedIndexChanged(object? sender, EventArgs? e);

    public void OutgoingScaleComboBoxSelectedIndexChanged(object? sender, EventArgs? e);

    public void TemperatureValueTextBoxTextChanged(object? sender, EventArgs? e);

    public void ConvertButtonClick(object? sender, EventArgs? e);

    public void SetConversionResult(double temperature);
}