using app_models;
using BillingManagement.Business;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;

namespace BillingManagement.UI.ViewModels
{
    public class CustomerViewModel : BaseViewModel
    {
        readonly CustomersDataService customersDataService = new CustomersDataService();

        private ObservableCollection<Customer> customers;
        private Customer selectedCustomer;
        private string selectedCustomerCIs;

        public ObservableCollection<Customer> Customers
        {
            get => customers;
            private set
            {
                customers = value;
                OnPropertyChanged();
            }
        }

        public Customer SelectedCustomer
        {
            get => selectedCustomer;
            set
            {
                selectedCustomer = value;
                OnPropertyChanged();
            }
        }
        public string SelectedCustomerCIs
        {
            get
            {
                if (selectedCustomer != null)
                {
                    var CI = new StringBuilder();
                    foreach (var CIs in SelectedCustomer.ContactInfos)
                    {
                        CI.AppendLine(CIs.ContactType.ToString() + " : " + CIs.Contact.ToString());
                    }

                    return CI.ToString();
                }
                else
                    return "";
            }
            set
            {
                selectedCustomerCIs = value;
                OnPropertyChanged();
            }
        }
        public CustomerViewModel()
        {
            InitValues();
        }

        private void InitValues()
        {
            Customers = new ObservableCollection<Customer>(customersDataService.GetAll());
            Debug.WriteLine(Customers.Count);
        }

    }
}
