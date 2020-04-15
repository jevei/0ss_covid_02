using app_models;
using BillingManagement.UI.ViewModels;
using System.Windows;
using System.Windows.Data;

namespace Inventaire
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainView : Window
    {
        CustomerViewModel _vm;
        InvoiceViewModel _ivm;

        public MainView(/*CustomerViewModel vm, InvoiceViewModel ivm*/)
        {
            InitializeComponent();
            DataContext = new MainViewModel();
            /*_vm = vm;
            DataContext = _vm;
            _ivm = ivm;*/
        }


        /*private void CustomerNew_Click(object sender, RoutedEventArgs e)
        {
            Customer temp = new Customer() { Name = "Undefined", LastName = "Undefined" };
            _vm.Customers.Add(temp);
            _vm.SelectedCustomer = temp;            
        }

        private void CustomerDelete_Click(object sender, RoutedEventArgs e)
        {
            int currentIndex = _vm.Customers.IndexOf(_vm.SelectedCustomer);

            if (currentIndex > 0)
                currentIndex--;

            _vm.Customers.Remove(_vm.SelectedCustomer);

            lvCustomers.SelectedIndex = currentIndex;

        }*/

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }
    }
}
