using TemperatureTask.Model.Scales;
using TemperatureTask.Model.Interfaces;

namespace TemperatureTask.View.Interface;

internal interface IView : IModelListener
{
    void SetIncomingScale(IScale incomingScale);

    void SetOutgoingScale(IScale outgoingScale);

    double GetTemperatureValue(string stringTemperature);

    void ConvertTemperature();
}