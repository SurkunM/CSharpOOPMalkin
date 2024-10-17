namespace TemperatureTask.View.Interface;

internal interface IView
{
    void ComboBoxIncomingScaleSelectedIndexChanged(object sender, EventArgs e);

    void ComboBoxOutgoingScaleSelectedIndexChanged(object sender, EventArgs e);

    void TextBoxSetTemperatureValueTextChanged(object sender, EventArgs e);

    void ButtonConvertClick(object sender, EventArgs e);
}