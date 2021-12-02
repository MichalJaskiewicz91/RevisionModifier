

using System;
using System.Windows;
using SimpleInjector;
using Task.Services;
using Task.ViewModel;
using Task.Views;

/// <summary>
/// A class needed for dependency injection
/// </summary>
static class Program
{
    [STAThread]
    static void Main()
    {
        var container = Bootstrap();

        // Any additional other configuration, e.g. of your desired MVVM toolkit.

        RunApplication(container);
    }

    private static Container Bootstrap()
    {
        // Create the container as usual.
        var container = new Container();

        // Register your types, for instance:
        container.Register<IRevisionProvider, RevisionProvider>();

        // Register your windows and view models:
        container.Register<MainWindow>();
        container.Register<MainWindowViewModel>();

        container.Verify();

        return container;
    }

    private static void RunApplication(Container container)
    {
        try
        {
            var app = new Task.Task();
           //app.InitializeComponent();
            var mainWindow = container.GetInstance<MainWindow>();
            app.Run(mainWindow);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
}