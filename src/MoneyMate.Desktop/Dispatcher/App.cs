using System.Windows;

namespace MoneyMate.Desktop
{
    public partial class App : Application
    {
        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            _logger.Error(e.Exception, "An unhandled exception just occurred: ");
            MessageBox.Show("An unhandled exception just occurred: " + e.Exception.Message, "Execption Sample", MessageBoxButton.OK, MessageBoxImage.Error);
            e.Handled = true;
        }
    }    
}
