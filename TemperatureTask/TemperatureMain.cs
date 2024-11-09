using TemperatureTask.Controller;
using TemperatureTask.Model;
using TemperatureTask.View;

namespace TemperatureTask
{
    internal static class TemperatureMain
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var model = new TemperatureModel();
            var controller = new TemperatureController(model);
            var view = new TemperatureForm(controller);

            Application.Run(view);
        }
    }
}