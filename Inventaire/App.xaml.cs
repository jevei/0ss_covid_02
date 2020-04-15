using BillingManagement.UI.ViewModels;
using System.Windows;

namespace Inventaire
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        MainView _window;

        public App()
        {
            CustomerViewModel vm = new CustomerViewModel();
            InvoiceViewModel ivm = new InvoiceViewModel();
            //_window = new MainView(vm, ivm);
            _window = new MainView();
            _window.Show();
        }
    }
}
