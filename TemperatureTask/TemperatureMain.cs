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

            var view = new TemperatureForm();
            var model = new TemperatureModel(view);
            var controller = new TemperatureController(model);
            view.Controller = controller;

            Application.Run(view);
        }
    }
}