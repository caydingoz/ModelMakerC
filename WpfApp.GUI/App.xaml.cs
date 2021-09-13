using System.Windows;
using WpfApp.Infrastructure;

namespace WpfApp.GUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            PropertyTypes.InitializeDataTypes();
            FunctionTypes.InitializeFunctionTypes();
            base.OnStartup(e);
        }
    }
}
